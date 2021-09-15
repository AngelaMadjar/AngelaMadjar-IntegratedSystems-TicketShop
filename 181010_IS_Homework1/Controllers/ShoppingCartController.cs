using _181010_IS_Homework1.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;


namespace _181010_IS_Homework1.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCartService;

        public ShoppingCartController(IShoppingCart shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            //This is the same code as in the action AddToShoppingCart in the TicketsController
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = _shoppingCartService.getShoppingCartInfo(userId);

            return View(model);
        }

        public IActionResult DeleteFromShoppingCart(Guid id) //if we call this action in the Index view with shash '/', the input argument has to be named 'id'
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _shoppingCartService.deleteProductFromShoppingCart(userId, id);

            //I can add an if/else block to handle the case when the result is false
            return RedirectToAction(nameof(Index));
            
        }


        public IActionResult OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _shoppingCartService.orderNow(userId);

            return RedirectToAction(nameof(Index));
        }

    }

}

