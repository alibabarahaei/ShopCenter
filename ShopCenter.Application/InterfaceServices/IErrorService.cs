using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IErrorService<TError>
    {
        public void ErrorHanling(List<TError> errors);
    }
}
