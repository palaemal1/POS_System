using Model.Entities;
using Model;
using Repository.IRepositories;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    
    public class ProductRepository:GenericRepository<Products>,IProductRepository
    {
        private readonly DataContent _context;
        public ProductRepository(DataContent context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<object>> DisplayProduct()
        {
            var product = _context.Products.Where(x => x.ActiveFlag == true);
            var category = _context.Categories.Where(x => x.ActiveFlag == true);
            var data = await (from p in product
                              join c in category on p.CategoryId equals c.CategoryId.ToString()
                              select new
                              {
                                  productName = p.ProductName,
                                  price = p.Price,
                                  cost = p.Cost,
                                  description = p.Description,
                                  qty = p.QuantityInStock,
                                  reorderLevel = p.ReorderLevel,
                                  sku = p.SKU,
                                  categoryName = c.CategoryName,
                                  categoryCode = c.CategoryCode,
                                  createdBy = p.CreatedBy,
                                  createdAt = p.CreatedAt,
                                  updatedBy = p.UpdatedBy,
                                  updatedAt = p.UpdatedAt
                              }
                            ).ToListAsync();
            return data;
        }
    }
}
