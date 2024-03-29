﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BL;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServicies _productServicies;
        private readonly IMapper _mapper;

        public ProductController(IProductServicies productBase, IMapper mapper)
        {
            _productServicies = productBase;
            _mapper = mapper;
        }

        public IActionResult Index(int id)
        {
            var product = _mapper.Map<ProductViewModel>(_productServicies.AllProducts().FirstOrDefault(x => x.Id == id));
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
