using BAL.IService;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Repository.IUnitOfWork;

namespace POS.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController:ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IUnitofWork unitofWork,IOrderItemService orderItemService)
        {
            _unitofWork = unitofWork;
            _orderItemService = orderItemService;
        }

        [HttpGet("GetAllOrderItem")]
        public async Task<IActionResult> GetOrderItem()
        {
            var data = await _orderItemService.GetAllOrderItem();
            return Ok(new ResponseModel { Data = data });
        }

        [HttpPost("AddOrderItem")]
        public async Task<IActionResult> AddOrderItem(AddNewOrderItem input)
        {
            await _orderItemService.AddOrderItem(input);
            return Ok("Add order item successfully");
        }

        [HttpPost("UpdateOrderItem")]
        public async Task<IActionResult> UpdateOrderItem(Guid id,UpdateOrderItemDTO input)
        {
            await _orderItemService.updateOrderItem(id, input);
            return Ok("Update order item successfully");
        }

        [HttpGet("DeleteOrderItem")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            await _orderItemService.DeleteOrderItem(id);
            return Ok("Delete order item successfully");
        }
    }
}
