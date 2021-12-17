using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Data.Interfaces;
using PetShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace PetShop.Controllers
{
    [Authorize]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        private IAdmin _adminUsedData;
        public AdminAPIController(IAdmin adminUsedData)
        {
            _adminUsedData = adminUsedData;
        }


        [HttpGet]
        [Route("api/transactions")]
        public IActionResult GetAllTransactionsFunction()
        {
            return Ok(_adminUsedData.GetAllTransactions());
        }

        [HttpGet]
        [Route("api/adminProduct/{id}")]
        public IActionResult GetSingleProductFunction(Guid ID)
        {
            var singleCommand = _adminUsedData.GetProductByID(ID);
            if (singleCommand != null)
            {
                return Ok(singleCommand);
            }
            else return NotFound("Product isn't found");
        }

        [HttpGet]
        [Route("api/searchAdminProduct/{search}")]
        public IActionResult SearchBarFunction(string search)
        {
            return Ok(_adminUsedData.SearchBar(search));
        }

        [HttpPost]
        [Route("api/newProduct")]
        public IActionResult AddNewProductFunction(ProductModel newProduct, Guid categoryID)
        {
            newProduct.ProductId = Guid.NewGuid();
            return Ok(_adminUsedData.AddNewProduct(newProduct, categoryID));
        }

        [HttpDelete]
        [Route("api/deleteProduct/{id}")]
        public IActionResult DeleteProductFunction(Guid ID)
        {
            var singleProduct = _adminUsedData.GetProductByID(ID);
            if (singleProduct != null)
            {
                _adminUsedData.DeleteProduct(singleProduct);
                return Ok();
            }
            else return NotFound("Product isn't found");
        }

        [HttpPatch]
        [Route("api/editProduct/{id}")]
        public IActionResult EditProductFunction(ProductModel editedProduct)
        {
            var singleProduct = _adminUsedData.GetProductByID(editedProduct.ProductId);
            if (singleProduct != null)
            {
                _adminUsedData.ModifyExistingProduct(singleProduct);
                return Ok();
            }
            else return NotFound("Product isn't found");
        }

       
        
    }
}
