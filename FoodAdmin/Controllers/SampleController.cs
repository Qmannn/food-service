using System;
using System.Collections.Generic;
using FoodAdmin.Dto.Sample;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        [HttpGet("samples")]
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
        
        [HttpGet("sample")]
        public SampleDto GetSample(int sampleId)
        {
            return new SampleDto
            {
                SampleId = sampleId,
                Name = "Пример для редактирования",
                Description = $"Получено с BE {DateTime.Now}"
            };
        }
        
        [HttpPost("sample")]
        public SavedSampleInfo SaveSample([FromBody] SampleDto sample)
        {
            return new SavedSampleInfo
            {
                SavedSampleId = sample.SampleId,
                SavedDescription = sample.Description
            };
        }
    }
}
