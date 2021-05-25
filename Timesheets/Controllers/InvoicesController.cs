using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController: TimesheetBaseController
    {
        private readonly IInvoiceManager _invoiceManager;
        
        public InvoicesController(IInvoiceManager invoiceManager)
        {
            _invoiceManager = invoiceManager;
        }
        
        /// <summary> Создает клиентский счет </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest invoiceRequest)
        {
            var id = await _invoiceManager.Create(invoiceRequest);
            return Ok(id);
        }
    }
}