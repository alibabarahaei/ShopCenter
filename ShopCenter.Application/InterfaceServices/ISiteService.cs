using ShopCenter.Domain.Models.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.InterfaceServices
{
    public interface ISiteService : IAsyncDisposable
    {
        #region slider

        Task<List<Slider>> GetAllActiveSliders();

        #endregion
    }
}
