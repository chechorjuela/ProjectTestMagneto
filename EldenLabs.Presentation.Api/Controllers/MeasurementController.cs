using EldenLabs.Application.Core.Dto;
using EldenLabs.Application.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EldenLabs.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var response = await _measurementService.GetAllMeasurenment();
            return Ok(response);
        }

        [HttpGet("GetAllByUserId/{id}")]
        public async Task<IActionResult> GetAllByUserId([FromRoute] int id)
        {
            var response = await _measurementService.GetAllMeasurenmentByUser(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MeasurementRequestDto measurement)
        {
            var response = await _measurementService.CreateMeasurement(measurement);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] MeasurementRequestDto measurement)
        {
            var response = await _measurementService.UpdateMeasurement(id, measurement);
            return Ok(response);
        }


    }
}
