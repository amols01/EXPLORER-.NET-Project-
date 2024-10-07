using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] Bill bill)
        {
            if (bill == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var createdBill = await _billService.CreateBillAsync(bill);
            return Ok(createdBill);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetAllBills()
        {
            var bills = await _billService.GetAllBillsAsync();
            return Ok(bills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById(int id)
        {
            var bill = await _billService.GetBillByIdAsync(id);
            if (bill == null)
            {
                return NotFound("Bill not found.");
            }
            return Ok(bill);
        }
    }
}