using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Entities
{
    public class BrandImage
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public string Path { get; set; }

        public string Alt { get; set; } 

        public Brand Brand { get; set; }
    }
}
