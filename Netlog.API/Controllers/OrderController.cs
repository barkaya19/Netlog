using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netlog.Data.Entities;
using Netlog.Service.IServices;
using System.Net;

namespace Netlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IOrderService _service;

        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
       [HttpPut]
       public async Task<IActionResult> OrderImport([FromQuery]string deliveryPerson, string plate)
       {

            var response = await  _service.OrderImportService(deliveryPerson, plate);
            return Ok(response);
       }
    }
}
