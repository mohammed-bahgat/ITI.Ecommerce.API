using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductRate { get; set; }

        //Navigation property
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
