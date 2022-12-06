using HenryScheinOneTest.Application.DTO;
using HenryScheinOneTest.Application.UseCases.Patients.Queries.GetReformattedPatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace HenryScheinOneTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReformatController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReformatController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("single-file")]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            if (file.Length <= 0) return BadRequest();

            var response = await _mediator.Send(new GetReformattedPatient() { Data = file });

            if (response.Success)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(response.Data);
                MemoryStream stream = new MemoryStream(byteArray);
                return File(stream, "text/csv");
            }

            return BadRequest(response);
        }
    }
}
