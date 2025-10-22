using Model;
using Model.Entities;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class CategoryRepository:GenericRepository<Categories>,ICategoryRepository
    {
        public CategoryRepository(DataContent context) : base(context) { }
    }
}
