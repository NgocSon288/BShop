using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Entities
{
    public class Product : Auditable
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public decimal Price { get; set; }

        public decimal? Promotion { get; set; }

        public decimal Description { get; set; }

        public string Content { get; set; }

        public bool IsFreeship { get; set; }

        public bool IsInstallment { get; set; }

        public int ViewCount { get; set; }

        public float Rating { get; set; }

        public Brand Brand { get; set; }

        public List<Parameter> Parameters { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<Comment> Comments { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
