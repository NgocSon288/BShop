using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Utilities.Exceptions
{
    public class EShopException : Exception
    {
        // StatusCode Http: 200, 201, 400, 404...
        public int Status { get; set; } = 200;

        public EShopException(int status = 200)
        {
            Status = status;
        }

        public EShopException(string message, int status = 200)
            : base(message)
        {
            Status = status;
        }

        public EShopException(string message, Exception inner, int status = 200)
            : base(message, inner)
        {
            Status = status;
        }

        public EShopException(Exception ex, int status = 200) : base(ex.Message)
        {
            Status = status;
        }
    }
}
