using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

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

        public IActionResult create()
        {
            return View();
        }

        [HttpPost] // como o "IActionResult Create" por padrão usa o método GET, usamos a annotation "[HttpPost]" para converter o método para POST
        [ValidateAntiForgeryToken] // Previne contra ataques CSRF
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); // "RedirectToAction" direciona a requisição para a ação especificada como argumento. Nesse caso é a ação "Index"
                                                    //"nameof" aponta para a propriedade independente se esta mudar de nome
        }
    }
}
