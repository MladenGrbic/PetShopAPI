using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Data.Interfaces;
using PetShop.Models.UserModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PetShop.Controllers
{
    [Authorize]
    [ApiController]
    public class NotLoggedInUserAPIController : ControllerBase
    {
        private  IProductShow _productData;
        public NotLoggedInUserAPIController(IProductShow productData)
        {
            _productData = productData;
        }

        [HttpGet]
        [Route("api/Products")]
        public IActionResult GetAllProductsFunction()
        {
            return Ok(_productData.GetAllProducts());
        }

        [HttpGet]
        [Route("api/Product/{id}")]
        public IActionResult GetSingleProductFunction(Guid ID)
        {
            var singleProduct = _productData.GetProductByID(ID);
            if (singleProduct != null)
            {
                return Ok(singleProduct);
            }
            else return NotFound("Product isn't found");
        }

        [HttpGet]
        [Route("api/Product/{search}")]
        public IActionResult SearchBarFunction(string search)
        {
            return Ok(_productData.SearchBar(search));
        }

        [HttpPost]
        [Route("api/registerNew")]
        public IActionResult AddNewUserFunction(string username, string password, string nameAndSurname, string telephoneNumber, UserAdressModel adress)
        {
            adress.UserAdressID = Guid.NewGuid();
            var checker =_productData.AddNewUser(username, password, nameAndSurname, telephoneNumber, adress);
            if (checker != null)
                return Ok(checker);
            else
                return NotFound("Username already exists");
        }

    }
}
