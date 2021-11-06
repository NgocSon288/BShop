using EShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Entities
{
    public class Order : Auditable
    {
        public int Id { get; set; }

        public Guid? AppUserId { get; set; }

        public int PaymentMethodId { get; set; }

        public int OrderStatusId { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Message { get; set; }

        public AppUser AppUser { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
