using System.Collections.Generic;
using FoodAdmin.Dto.Sample;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        private ISampleService _sampleService;

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet("samples")]
        public List<SampleDto> GetSamples()
        {
            var storedSamples = _sampleService.GetSamples();

            if (storedSamples.Count > 0)
            {
                return storedSamples;
            }

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
            return _sampleService.GetSample(sampleId);
        }

        [HttpPost("sample")]
        public SavedSampleInfo SaveSample([FromBody] SampleDto sample)
        {
            SampleDto savedSampleDto = _sampleService.SaveSample(sample);

            return new SavedSampleInfo
            {
                SavedSampleId = savedSampleDto.SampleId,
                SavedDescription = savedSampleDto.Description
            };
        }
    }
}
