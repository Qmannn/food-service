using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAdmin.Dto.PageName;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("Samples")]
        public List<SampleDto> GetSamples()
        {
            return new List<SampleDto>
            {
                new SampleDto
                {
                    SampleId = 10,
                    Name = "Test1",
                    Description = "First description"
                },
                new SampleDto
                {
                    SampleId = 15,
                    Name = "Test2",
                    Description = "Description"
                },
            };
        }

    }
}
