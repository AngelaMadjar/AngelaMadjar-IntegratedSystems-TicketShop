using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.Identity;
using _181010_IS_Homework1.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _181010_IS_Homework1.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ShopApplicationUser> userManager;

        public AdminController(IOrderService orderService, UserManager<ShopApplicationUser> userManager)
        {
            _orderService = orderService;
            this.userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllActiveOrders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            return _orderService.GetOrderDetails(model);
        }


        [HttpPost("[action]")]
        public bool ImportAllUsers(List<ShopApplicationUser> model)
        {
            bool status = true;

            foreach (var item in model)
            {
                var userCheck = userManager.FindByEmailAsync(item.Email).Result;
                
                if (userCheck == null)
                {
                    var user = new ShopApplicationUser
                    {
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        Name = item.Name,
                        Surname = item.Surname,
                        Address = item.Address,
                        EmailConfirmed = true,
                        PasswordHash = item.PasswordHash,
                        UserShoppingCart = new ShoppingCart()
                    };
                    // NOTE: Instead of having a DTO to pass the user's data, I use the default .NET core authentication and pass the data directly
                    //       so that I created another variable named Password in the ShopApplicationUser Class in both of the applications
                    var result = userManager.CreateAsync(user, item.Password).Result;

                    status = status && result.Succeeded;
                }
                else
                {
                    continue; // if user's email already exists, don't register the user
                }

            }

            return status;
        }
    }
}
