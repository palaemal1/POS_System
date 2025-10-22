using Model.Entities;
using Model;
using Repository.IRepositories;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class ProductRepository:GenericRepository<Products>,IProductRepository
    {
        public ProductRepository(DataContent context) : base(context) { }
    }
}
