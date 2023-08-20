using Microsoft.AspNetCore.Http;
using ShopCenter.Application.DTOs.Common;
using ShopCenter.Application.DTOs.Products;
using ShopCenter.Domain.Models.Products;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IProductService : IAsyncDisposable
    {
        #region Filters

        Task<FilterProductDTO> FilterProductsAsync(FilterProductDTO filter);

        #endregion

        #region product 
        Task<CreateProductResult> CreateProduct(CreateProductDTO product, IFormFile productImage, long sellerId);
        #endregion
        #region product categories

        Task<List<ProductCategory>> GetAllProductCategoriesByParentId(long? parentId);
        Task<List<ProductCategory>> GetAllActiveProductCategories();

        #endregion


        #region product gallery

        Task<List<ProductGallery>> GetAllProductGalleries(long productId);

        Task<List<ProductGallery>> GetAllProductGalleriesInSellerPanel(long productId, long userId);


        #endregion




        Task<bool> AcceptSellerProduct(long productId);
        Task<bool> RejectSellerProduct(RejectItemDTO reject);
        Task<EditProductDTO> GetProductForEdit(long productId);
        Task<EditProductResult> EditSellerProduct(EditProductDTO product, string userId, IFormFile productImage);
        Task RemoveAllProductSelectedCategories(long productId);
        Task RemoveAllProductSelectedColors(long productId);
        Task AddProductSelectedColors(long productId, List<CreateProductColorDTO> colors);
        Task AddProductSelectedCategories(long productId, List<long> selectedCategories);


    }
}