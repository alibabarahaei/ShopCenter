﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopCenter.Application.DTOs.Common;
using ShopCenter.Application.DTOs.Paging;
using ShopCenter.Application.DTOs.Products;
using ShopCenter.Application.Extensions;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Application.Utilities;
using ShopCenter.Domain.InterfaceRepositories.Base;
using ShopCenter.Domain.Models.Products;

namespace ShopCenter.Application.Services
{
    public class ProductService : IProductService
    {
        #region constructor

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<ProductSelectedCategory> _productSelectedCategoryRepository;
        private readonly IGenericRepository<ProductColor> _productColorRepository;

        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<ProductCategory> productCategoryRepository, IGenericRepository<ProductSelectedCategory> productSelectedCategoryRepository, IGenericRepository<ProductColor> productColorRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productSelectedCategoryRepository = productSelectedCategoryRepository;
            _productColorRepository= productColorRepository;
        }

        #endregion

        #region filters

        public async Task<FilterProductDTO> FilterProductsAsync(FilterProductDTO filter)
        {
            var query = _productRepository.GetQuery().AsQueryable();

            #region state

            switch (filter.FilterProductState)
            {
                case FilterProductState.All:
                    break;
                case FilterProductState.Active:
                    query = query.Where(s => s.IsActive && s.ProductAcceptanceState == ProductAcceptanceState.Accepted);
                    break;
                case FilterProductState.NotActive:
                    query = query.Where(s => !s.IsActive && s.ProductAcceptanceState == ProductAcceptanceState.Accepted);
                    break;
                case FilterProductState.Accepted:
                    query = query.Where(s => s.ProductAcceptanceState == ProductAcceptanceState.Accepted);
                    break;
                case FilterProductState.Rejected:
                    query = query.Where(s => s.ProductAcceptanceState == ProductAcceptanceState.Rejected);
                    break;
                case FilterProductState.UnderProgress:
                    query = query.Where(s => s.ProductAcceptanceState == ProductAcceptanceState.UnderProgress);
                    break;
            }

            #endregion

            #region filter

            if (!string.IsNullOrEmpty(filter.ProductTitle))
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.ProductTitle}%"));

            if (filter.SellerId != null)
                query = query.Where(s => s.SellerId == filter.SellerId);

            #endregion

            #region paging

            var pager = Pager.Build(filter.PageId, await query.CountAsync(), filter.TakeEntity, filter.HowManyShowPageAfterAndBefore);
            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetProducts(allEntities).SetPaging(pager);
        }

        #endregion

        #region products

        public async Task<CreateProductResult> CreateProduct(CreateProductDTO product, IFormFile productImage, long sellerId)
        {
            if (productImage == null) return CreateProductResult.HasNoImage;

            var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(productImage.FileName);

            var res = productImage.AddImageToServer(imageName, SD.ProductImageImageServer, 150, 150, SD.ProductThumbnailImageImageServer);

            if (res)
            {
                // create product
                var newProduct = new Product
                {
                    Title = product.Title,
                    Price = product.Price,
                    ShortDescription = product.ShortDescription,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    SellerId = sellerId,
                    ImageName = imageName,
                    ProductAcceptOrRejectDescription = "اطلاعاتی وارد نشده است"
                    
                    
                };

                await _productRepository.AddEntity(newProduct);
                await _productRepository.SaveChanges();

                // create product categories
                var productSelectedCategories = new List<ProductSelectedCategory>();

                foreach (var categoryId in product.SelectedCategories)
                {
                    productSelectedCategories.Add(new ProductSelectedCategory
                    {
                        ProductCategoryId = categoryId,
                        ProductId = newProduct.Id
                    });
                }

                await _productSelectedCategoryRepository.AddRangeEntities(productSelectedCategories);
                await _productSelectedCategoryRepository.SaveChanges();

                // create product colors
                var productSelectedColors = new List<ProductColor>();

                foreach (var productColor in product.ProductColors)
                {
                    productSelectedColors.Add(new ProductColor
                    {
                        ColorName = productColor.ColorName,
                        Price = productColor.Price,
                        ProductId = newProduct.Id
                    });
                }

                await _productColorRepository.AddRangeEntities(productSelectedColors);
                await _productSelectedCategoryRepository.SaveChanges();

                return CreateProductResult.Success;
            }

            return CreateProductResult.Error;
        }

        #endregion


        #region product categories

        public async Task<List<ProductCategory>> GetAllProductCategoriesByParentId(long? parentId)
        {
            if (parentId == null || parentId == 0)
            {
                return await _productCategoryRepository.GetQuery()
                    .AsQueryable()
                    .Where(s => !s.IsDelete && s.IsActive && s.ParentId == null)
                    .ToListAsync();
            }

            return await _productCategoryRepository.GetQuery()
                .AsQueryable()
                .Where(s => !s.IsDelete && s.IsActive && s.ParentId == parentId)
                .ToListAsync();
        }

        public async Task<List<ProductCategory>> GetAllActiveProductCategories()
        {
            return await _productCategoryRepository.GetQuery().AsQueryable()
                .Where(s => s.IsActive && !s.IsDelete).ToListAsync();
        }

        public async Task<bool> AcceptSellerProduct(long productId)
        {
            var product = await _productRepository.GetEntityById(productId);
            if (product != null)
            {
                product.ProductAcceptanceState = ProductAcceptanceState.Accepted;
                product.ProductAcceptOrRejectDescription = $"محصول مورد نظر در تاریخ {DateTime.Now.ToShamsi()} مورد تایید سایت قرار گرفت";
                _productRepository.EditEntity(product);
                await _productRepository.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<bool> RejectSellerProduct(RejectItemDTO reject)
        {
            var product = await _productRepository.GetEntityById(reject.Id);
            if (product != null)
            {
                product.ProductAcceptanceState = ProductAcceptanceState.Rejected;
                product.ProductAcceptOrRejectDescription = reject.RejectMessage;
                _productRepository.EditEntity(product);
                await _productRepository.SaveChanges();

                return true;
            }

            return false;
        }

        public async Task<EditProductDTO> GetProductForEdit(long productId)
        {
            var product = await _productRepository.GetEntityById(productId);
            if (product == null) return null;

            return new EditProductDTO
            {
                Id = productId,
                Description = product.Description,
                ShortDescription = product.ShortDescription,
                Price = product.Price,
                IsActive = product.IsActive,
                Title = product.Title,
                ImageName = product.ImageName,
                ProductColors = await _productColorRepository
                    .GetQuery().AsQueryable()
                    .Where(s => !s.IsDelete && s.ProductId == productId)
                    .Select(s => new CreateProductColorDTO { Price = s.Price, ColorName = s.ColorName }).ToListAsync(),
                SelectedCategories = await _productSelectedCategoryRepository.GetQuery().AsQueryable()
                    .Where(s => s.ProductId == productId).Select(s => s.ProductCategoryId).ToListAsync()
            };
        }

        #endregion

        #region dispose

        public async ValueTask DisposeAsync()
        {
            await _productCategoryRepository.DisposeAsync();
            await _productRepository.DisposeAsync();
            await _productSelectedCategoryRepository.DisposeAsync();
        }

        #endregion
    }
}