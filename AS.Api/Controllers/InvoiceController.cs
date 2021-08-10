using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AS.BL.IServices;
using AutoMapper;
using AS.Api.Dtos;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IBaseService<Invoice> _invoiceService;
        private IMapper _mapper;

        public InvoiceController(IBaseService<Invoice> _invoiceService, IMapper mapper)
        {
            this._invoiceService = _invoiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var invoices = _invoiceService.GetAll();
            return new OkObjectResult(invoices);
        }
        
        [HttpGet, Route("{Id}")]
        public IActionResult Get(int Id)
        {

            //we want to find the product by id and load the category        
            var invoices = _invoiceService.Get(x => x.InvoiceId == Id, i => i.customer);
            if (!invoices.Any())
            {
                return new NoContentResult();
            }
            var reslut = JsonConvert.SerializeObject(invoices.First(), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return new OkObjectResult(reslut);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InvoiceDto invoiceDto)
        {
            Invoice invoice = _mapper.Map<Invoice>(invoiceDto);

            _invoiceService.Create(invoice);
            return CreatedAtAction(nameof(Get), new { id = invoice.InvoiceId }, invoice);
        }

        // PUT: api/Product/5       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InvoiceDto invoiceDto)
        {
            if (invoiceDto != null)
            {
                Invoice invoice = _invoiceService.Get(x => x.InvoiceId == id).First();
                if (invoice == null)
                {
                    return new NoContentResult();
                }
                _mapper.Map(invoiceDto, invoice);
                _invoiceService.Update(invoice);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var products = _invoiceService.Get(x => x.InvoiceId == id);
            if (!products.Any())
            {
                return new NoContentResult();
            }
            _invoiceService.Delete(products.First());
            return new OkResult();
        }
    }
}