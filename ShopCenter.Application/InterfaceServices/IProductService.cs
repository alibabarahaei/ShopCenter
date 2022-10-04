using ShopCenter.Application.DTOs.Products;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IProductService : IAsyncDisposable
    {
        #region products

        Task<FilterProductDTO> FilterProductsAsync(FilterProductDTO filter);

        #endregion
    }
}