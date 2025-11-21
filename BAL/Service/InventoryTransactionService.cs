using BAL.IService;
using Model;
using Model.DTO;
using Model.Entities;
using Repository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    internal class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly DataContent _content;
        public InventoryTransactionService(IUnitofWork unitofWork, DataContent content)
        {
            _unitofWork = unitofWork;
            _content = content;
        }

        public async Task AddInventoryTransaction(AddInventoryTransactionDTO input)
        {
            var data = new InventoryTransactions()
            {
                ProductId = input.productId,
                QtyChange = input.qtyChange,
                TransactionType = input.transactionType,
                ActiveFlag = input.activeFlag,
                CreatedAt = input.createdDate,
                CreatedBy = input.createdBy
            };
            await _unitofWork.InventoryTransaction.Add(data);
            await _unitofWork.SaveChangesAsync();
        }
    }
}
