using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AS.BL.IServices;
using AutoMapper;
using AS.Api.Dtos;

namespace AS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBaseService<Customer> _customerService;
        private IMapper _mapper;

        public CustomerController(IBaseService<Customer> _customerService, IMapper mapper)
        {
            this._customerService = _customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetAll();
            return new OkObjectResult(customers);
        }

        [HttpGet, Route("{Id}")]
        public IActionResult Get(int Id)
        {
            //we want to find the product by id and load the category        
            var customer = _customerService.Get(x => x.CustomerId == Id);
            if (!customer.Any())
            {
                return new NoContentResult();
            }
            return new OkObjectResult(customer.First());
        }

        [HttpGet("SearchByName/{Name}")]
        public IActionResult SearchByName(string name)
        {
            //we want to find the product by id and load the category        
            var customer = _customerService.Get(x => x.CustomerName.Contains(name));
            if (!customer.Any())
            {
                return new NoContentResult();
            }
            return new OkObjectResult(customer);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);

            _customerService.Create(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
        }

        // PUT: api/Customer/5       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto customerDto)
        {
            if (customerDto != null)
            {
                Customer cust = _customerService.Get(x => x.CustomerId == id).First();
                if (cust == null)
                {
                    return new NoContentResult();
                }
                _mapper.Map(customerDto, cust);
                _customerService.Update(cust);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var products = _customerService.Get(x => x.CustomerId == id);
            if (!products.Any())
            {
                return new NoContentResult();
            }
            _customerService.Delete(products.First());
            return new OkResult();
        }
    }
}