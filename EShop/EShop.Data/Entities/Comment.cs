using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Entities
{
    public class Comment : Auditable
    {
        public int Id { get; set; }

        public Guid AppUserId { get; set; }

        public int ProductId { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public float StarNumber { get; set; }

        public string Reason { get; set; }

        public string Description { get; set; }

        public AppUser AppUser { get; set; }

        public Product Product { get; set; }
    }
}
