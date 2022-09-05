using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Application.Services
{
    public class ErrorService<TError>:IErrorService<TError>
    {
        public void ErrorHanling(List<TError> errors)
        {
            
        }
    }
}
