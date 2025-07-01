using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Session06.ApplicationServices.Dtos.ProductDtos;
using Session06.ApplicationServices.Services.Contracts;

namespace Session06.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllProductsAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,ProductDescription,UnitPrice")] ProductCreate productCreate)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProductAsync(productCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(productCreate);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var productDetail = await _productService.GetProductByIdAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            var productUpdate = new ProductUpdate
            {
                Id = productDetail.Id,
                ProductName = productDetail.ProductName,
                ProductDescription = productDetail.ProductDescription,
                UnitPrice = productDetail.UnitPrice
            };
            return View(productUpdate);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductName,ProductDescription,UnitPrice")] ProductUpdate productUpdate)
        {
            if (id != productUpdate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productService.UpdateProductAsync(productUpdate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productUpdate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productUpdate);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product != null)
            {
                var productDelete = new ProductDelete();
                productDelete.Id = id;
                _productService.DeleteProductAsync(productDelete);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _productService.Equals(id) != null;
        }
    }
}
