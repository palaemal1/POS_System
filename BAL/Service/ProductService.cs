﻿using BAL.IService;
using Model.DTO;
using Model;
using Model.Entities;
using Repository.IUnitOfWork;


namespace BAL.Service
{
    internal class ProductService : IProductService
    {
        private readonly IUnitofWork _unitOfWork;

        private readonly DataContent _context;
        public ProductService(IUnitofWork unitOfWork, DataContent context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAllProduct()
        {
            var data = await _unitOfWork.Product.GetByCondition(x=>x.ActiveFlag==false || x.ActiveFlag == null );
            return data;
        }

        
        public async Task AddProduct(AddProductDTO input)
        {
          
            var data = new Products()
            {
                ProductName = input.productName,
                SKU=input.sku,
                Description=input.description,
                Price=input.price,
                Cost=input.cost,
                QuantityInStock=input.quantityInStock,
                CategoryId=input.categoryId,
                ReorderLevel=input.reorderLevel,
                CreatedBy=input.createdBy,
                ActiveFlag=input.activeFlag,
                
            };
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            await _unitOfWork.Product.Add(data);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task UpdateProduct(Guid id, UpdateProductDTO input)
        {
            var data = (await _unitOfWork.Product.GetByCondition(x => x.ProductId == id)).FirstOrDefault();
            if (data != null)
            {
                data.ProductName = input.productName;
                data.SKU = input.sku;
                data.Description = input.description;
                data.Price = input.price;
                data.Cost = input.cost;
                data.QuantityInStock = input.quantityInStock;
                data.CategoryId = input.categoryId;
                data.ReorderLevel = input.reorderLevel;
                data.ActiveFlag = input.activeFlag;
                data.UpdatedBy = input.updatedBy;
                data.UpdatedAt = input.updateDate;

            }
            _unitOfWork.Product.Update(data);
            await _unitOfWork.SaveChangesAsync();
        }
       
        public async Task DeleteProduct(Guid id)
        {
            var data = (await _unitOfWork.Product.GetByCondition(x => x.ProductId == id )).FirstOrDefault();
            if (data != null)
            {
                data.ActiveFlag = false;
            }
            _unitOfWork.Product.Update(data);
            await _unitOfWork.SaveChangesAsync();
        }

        
       

    }
}
