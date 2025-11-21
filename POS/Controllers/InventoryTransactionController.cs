using BAL.IService;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Repository.IUnitOfWork;

namespace POS.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryTransactionController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IInventoryTransactionService _inventoryTrasactionService;
        public InventoryTransactionController(IUnitofWork unitofWork, IInventoryTransactionService inventoryTrasactionService)
        {
            _unitofWork = unitofWork;
            _inventoryTrasactionService = inventoryTrasactionService;
        }

        [HttpPost("AddInventory")]
        public async Task<IActionResult> AddInventoryTransaction(AddInventoryTransactionDTO input)
        {
            await _inventoryTrasactionService.AddInventoryTransaction(input);
            return Ok("Add inventory successfully");
        }
    }
}
