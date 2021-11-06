using EShop.ViewModels.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels.AppUsers
{
    public class AppUserSearchRequest : PagingParameters
    {
        public string Name { get; set; }
    }
}
