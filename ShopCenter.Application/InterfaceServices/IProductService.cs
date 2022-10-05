using ShopCenter.Application.DTOs.Products;
using ShopCenter.Domain.Models.Products;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IProductService : IAsyncDisposable
    {
        #region products

        Task<FilterProductDTO> FilterProductsAsync(FilterProductDTO filter);

        #endregion
        #region product categories

        Task<List<ProductCategory>> GetAllProductCategoriesByParentId(long? parentId);

        #endregion
    }
}