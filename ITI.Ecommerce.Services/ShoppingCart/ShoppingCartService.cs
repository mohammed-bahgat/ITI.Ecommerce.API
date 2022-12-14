using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ITI.Ecommerce.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _context ;

        //Edit Constructor
        public ShoppingCartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task add(ShoppingCartDto shoppingCartDto)
        {


            List<Product> li = new List<Product>();

            //add Product in ProductList in Shopping Cart
            List<Product> products = new List<Product>();

            foreach (var productDto in shoppingCartDto.productList)
            {
                Product Prod = new Product()
                {
                    NameAR = productDto.NameAR,
                    NameEN = productDto.NameEN,
                    Description = productDto.Description,
                    CategoryID = productDto.CategoryID,
                    Quantity = productDto.Quantity,
                    UnitPrice = productDto.UnitPrice,
                    Discount = productDto.Discount,
                    TotalPrice = productDto.TotalPrice,

                    Brand=productDto.Brand,
                    IsDeleted = productDto.IsDeleted,
                };
                li.Add(Prod);


                    Brand = productDto.Brand,
                    IsDeleted = false,
                };
                products.Add(product);

            }
            //Order order = new Order()
            //{
            //    OrderDate = shoppingCartDto.order.OrderDate,
            //    ID = shoppingCartDto.order.ID
            //};
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                ProductId = shoppingCartDto.ProductId,
                UnitPrice = shoppingCartDto.UnitPrice,
                Quantity = shoppingCartDto.Quantity,
                Discount = shoppingCartDto.Discount,
                
                Total = shoppingCartDto.Total,
                NameAR = shoppingCartDto.NameAR,
                NameEN = shoppingCartDto.NameEN,
                IsDeleted = false,
                //Order= order,
                productList = li
                

            };

            ShoppingCart shoppingCart = new ShoppingCart()
            {
                ProductId = shoppingCartDto.ProductId,
                UnitPrice = shoppingCartDto.UnitPrice,
                Quantity = shoppingCartDto.Quantity,
                Discount = shoppingCartDto.Discount,
                Total = shoppingCartDto.Total,
                NameAR = shoppingCartDto.NameAR,
                NameEN = shoppingCartDto.NameEN,
                IsDeleted = false,
            };
            await _context.ShoppingCarts.AddAsync(shoppingCart);
            _context.SaveChanges();

        }

        //public async Task add(ShoppingCartDT shoppingCartDT)
        //{
        //    List<Product> productList = new List<Product>();
        //    //add Product in ProductList in Shopping Cart
        //    foreach (var productDT in shoppingCartDT.productList)
        //    {
        //        Product product = new Product()
        //        {
        //            NameAR = productDT.NameAR,
        //            NameEN = productDT.NameEN,
        //            Description = productDT.Description,
        //            CategoryID = productDT.CategoryID,
        //            Quantity = productDT.Quantity,
        //            UnitPrice = productDT.UnitPrice,
        //            Discount = productDT.Discount,
        //            TotalPrice = productDT.TotalPrice,
        //            IsDeleted = productDT.IsDeleted,
        //            Brand = productDT.Brand
        //        };
        //        //shoppingCart.productList.Add(product);
        //        productList.Add(product);
        //    }

        //    ShoppingCart shoppingCart = new ShoppingCart()
        //    {
        //        ProductId = shoppingCartDT.ProductId,
        //        UnitPrice = shoppingCartDT.UnitPrice,
        //        Quantity = shoppingCartDT.Quantity,
        //        Discount = shoppingCartDT.Discount,
        //        Total = shoppingCartDT.Total,
        //        NameAR = shoppingCartDT.NameAR,
        //        NameEN = shoppingCartDT.NameEN,
        //        IsDeleted = shoppingCartDT.IsDeleted,
        //        productList = productList
        //    };

        //    await _context.ShoppingCarts.AddAsync(shoppingCart);
        //    _context.SaveChanges();

        //}

        public void Delete(ShoppingCartDto shoppingCartDto)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                ProductId = shoppingCartDto.ProductId,
                UnitPrice = shoppingCartDto.UnitPrice,
                Quantity = shoppingCartDto.Quantity,
                Discount = shoppingCartDto.Discount,
                Total = shoppingCartDto.Total,
                NameAR = shoppingCartDto.NameAR,
                NameEN = shoppingCartDto.NameEN,
                IsDeleted = true
            };
            _context.Update(shoppingCart);
            _context.SaveChanges();
        }
        public void DeleteCart(int id)
        {
            var cart = _context.ShoppingCarts.FirstOrDefault(i => i.ID == id);
            if (cart == null)
            {
                throw new Exception("not found");
            }
            else
            {
                cart.IsDeleted = true;
                _context.Update(cart);
                _context.SaveChanges();
            }
        }
        public async Task<IEnumerable<ShoppingCartDto>> GetAll()
        {
            List<ShoppingCartDto> shoppingCartes = new List<ShoppingCartDto>();
            var carts = await _context.ShoppingCarts.Where(o => o.IsDeleted == false).ToListAsync();

            foreach (var cart in carts)
            {
                ShoppingCartDto shoppingCartDto = new ShoppingCartDto();

                shoppingCartDto.ID = cart.ID;
                shoppingCartDto.ProductId = cart.ProductId;
                shoppingCartDto.UnitPrice = cart.UnitPrice;
                shoppingCartDto.Quantity = cart.Quantity;
                shoppingCartDto.Discount = cart.Discount;
                shoppingCartDto.Total = cart.Total;
                shoppingCartDto.IsDeleted = cart.IsDeleted;
                shoppingCartes.Add(shoppingCartDto);
            }

            return shoppingCartes;
        }

        public async Task<ShoppingCartDto> GetById(int id)
        {
            var item = await _context.ShoppingCarts.SingleOrDefaultAsync(i => i.ID == id);

            if (item == null)
            {
                throw new Exception("not found");
            }
            else
            {
                ShoppingCartDto shoppingCartDto = new ShoppingCartDto()
                {
                    ID = item.ID,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    Discount = item.Discount,
                    Total = item.Total,
                    IsDeleted = item.IsDeleted,

                };
                return shoppingCartDto;


            }
        }

        public void Update(ShoppingCartDto shoppingCartDto)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                ProductId = shoppingCartDto.ProductId,
                UnitPrice = shoppingCartDto.UnitPrice,
                Quantity = shoppingCartDto.Quantity,
                Discount = shoppingCartDto.Discount,
                Total = shoppingCartDto.Total,
                NameAR = shoppingCartDto.NameAR,
                NameEN = shoppingCartDto.NameEN,
                IsDeleted = shoppingCartDto.IsDeleted
            };
            _context.Update(shoppingCart);
            _context.SaveChanges();
        }

        public void UpdateCart(int id ,ShoppingCartDto shoppingCartDto)
        {
            var cart = _context.ShoppingCarts.FirstOrDefault(i => i.ID == id);
            if (cart == null)
            {
                throw new Exception("not found");
            }
            else
            {
                cart.ID = id;
                cart.ProductId = shoppingCartDto.ProductId;
                cart.UnitPrice = shoppingCartDto.UnitPrice;
                cart.Quantity = shoppingCartDto.Quantity;
                cart.Discount = shoppingCartDto.Discount;
                cart.Total = shoppingCartDto.Total;
                cart.NameAR = shoppingCartDto.NameAR;
                cart.NameEN = shoppingCartDto.NameEN;
                cart.IsDeleted = false;

                //foreach (var productDto in cart.productList)
                //{
                //    Product product = new Product()
                //    {
                //        NameAR = productDto.NameAR,
                //        NameEN = productDto.NameEN,
                //        Description = productDto.Description,
                //        CategoryID = productDto.CategoryID,
                //        Quantity = productDto.Quantity,
                //        UnitPrice = productDto.UnitPrice,
                //        Discount = productDto.Discount,
                //        TotalPrice = productDto.TotalPrice,
                //        IsDeleted = productDto.IsDeleted,
                //    };
                //}
             }
            _context.Update(cart);
            _context.SaveChanges();
        }
    }
}
