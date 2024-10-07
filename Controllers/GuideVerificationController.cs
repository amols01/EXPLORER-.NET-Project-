using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideVerificationController : ControllerBase
    {
        private readonly IGuideVerificationService _verificationService;

        public GuideVerificationController(IGuideVerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GuideVerification request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _verificationService.CreateVerificationAsync(request);
            if (result)
            {
                return CreatedAtAction(nameof(GetById), new { aadharNumber = request.AadharNumber }, request);
            }
            return StatusCode(500, "An error occurred while creating the verification.");
        }

        [HttpGet("{aadharNumber}")]
        public async Task<IActionResult> GetById(string aadharNumber)
        {
            var verification = await _verificationService.GetVerificationByIdAsync(aadharNumber);
            if (verification == null)
            {
                return NotFound();
            }
            return Ok(verification);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var verifications = await _verificationService.GetAllVerificationsAsync();
            return Ok(verifications);
        }

        [HttpPut("{aadharNumber}")]
        public async Task<IActionResult> Update(string aadharNumber, [FromBody] GuideVerification request)
        {
            if (request == null || request.AadharNumber != aadharNumber || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var exists = await _verificationService.GetVerificationByIdAsync(aadharNumber);
            if (exists == null)
            {
                return NotFound();
            }

            var result = await _verificationService.UpdateVerificationAsync(request);
            if (result)
            {
                return NoContent();
            }
            return StatusCode(500, "An error occurred while updating the verification.");
        }

        [HttpDelete("{aadharNumber}")]
        public async Task<IActionResult> Delete(string aadharNumber)
        {
            var exists = await _verificationService.GetVerificationByIdAsync(aadharNumber);
            if (exists == null)
            {
                return NotFound();
            }

            var result = await _verificationService.DeleteVerificationAsync(aadharNumber);
            if (result)
            {
                return NoContent();
            }
            return StatusCode(500, "An error occurred while deleting the verification.");
        }
    }
}
