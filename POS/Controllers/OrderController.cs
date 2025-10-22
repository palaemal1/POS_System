﻿using BAL.IService;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Model.Entities;
using Repository.IUnitOfWork;

namespace POS.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IOrderService _orderService;
        public OrderController(IUnitofWork unitofWork,IOrderService orderService)
        {
            _unitofWork = unitofWork;
            _orderService = orderService;
        }

        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder()
        {
           var data= await _orderService.GetAllOrder();
            return Ok(new ResponseModel { Data = data });
        }

        [HttpPost("NewOrder")]
        public async Task<IActionResult> newOrder(AddNewOrder input)
        {

            await _orderService.AddOrder(input);
            return Ok("Order successfully");
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderDTO input)
        {
            await _orderService.UpdateOrder(id, input);
            return Ok("Update successfully");
        }

        [HttpGet("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteOrder(id);
            return Ok("Delete successfully");
        }
    }
}
