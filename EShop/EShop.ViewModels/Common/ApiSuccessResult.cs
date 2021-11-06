using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T result)
        {
            IsSuccessed = true;
            Result = result;
        }

        public ApiSuccessResult()
        {
            IsSuccessed = true; 
        }
    }
}