using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        // Nota: O método abaixo demonstra bem o MVC acontecendo (ver próximos comentários)
        public IActionResult Index() // O método dentro do controlador...
        {
            var list = _sellerService.FindAll(); // ...chama o model
            return View(list); // ...que encaminha os dados para a view
        }
    }
}
