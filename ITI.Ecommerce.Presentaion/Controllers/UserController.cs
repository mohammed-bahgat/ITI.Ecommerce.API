using DTOs;
using ITI.Ecommerce.Models;
using ITI.Ecommerce.Presentaion.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Ecommerce.Presentaion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserManager<Customer> UserManager;
        SignInManager<Customer> SignInManager;
        RoleManager<IdentityRole> RoleManager;

        public UserController(UserManager<Customer> _UserManager,
            SignInManager<Customer> _SignInManager,
            RoleManager<IdentityRole> _roleManager
        )
         {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
            RoleManager = _roleManager; 
           
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            DateTime Date = DateTime.Now;
          
            Customer user = new Customer()
            {
                UserName = model.UserName,
                Email = model.Email,
                Address = model.Address,
                MobileNumber = model.MobileNumber
                   ,
                DateEntered = Date
            };

            IdentityResult result
                     = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded == false)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                await UserManager.AddToRoleAsync(user,"User");
                
                return Ok("Done");
            }

            
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            
                var user = await UserManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound("Not Found User");
            }
            else
            {
                var result = await SignInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    var loggedUser = new LoggedInModel()
                    {
                        Id=user.Id,
                        UserName=user.UserName
                    };
                    return Ok(loggedUser);
                }
                else
                {
                    return NotFound("Not Valid Email Or Password");
                }
            }

          
        }
    }
}
