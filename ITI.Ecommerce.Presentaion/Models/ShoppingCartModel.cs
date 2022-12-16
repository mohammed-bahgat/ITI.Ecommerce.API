using DTOs;

namespace ITI.Ecommerce.Presentaion.Models
{
    public class ShoppingCartModel
    {
        public int? ID { get; set; }
  
        

        public ICollection<int> productListIds { get; set; }
    }
}
