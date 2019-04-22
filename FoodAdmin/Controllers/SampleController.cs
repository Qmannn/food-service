using System.Collections.Generic;
using Food.Core.Domain.Entities;
using Food.Core.Domain.Services.Finders;
using FoodAdmin.Domain.Services.Savers;
using FoodAdmin.Dto.Sample;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        private ISampleService _sampleService;
        //private IDailySampleSaver _dailySampleSaver;
        //private IDailySampleFactory _dailySampleFactory; 

        public SampleController(ISampleService sampleService/*, IDailySampleSaver dailySampleSaver, IDailySampleFactory dailySampleFactory*/)
        {
            _sampleService = sampleService;
            //_dailySampleSaver = dailySampleSaver;
            //_dailySampleFactory = dailySampleFactory;
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

        public void ChangeSamplePartName(int sampleId, int samplePartId, string newPartNmae)
        {
            //DailySample dailySample = _dailySampleFactory.GetDailySample(sampleId);
            //foreach (var part in dailySample.Parts)
            //{
            //    if (part.PartId == samplePartId)
            //    {
            //        part.PartName = newPartNmae;
            //    }
            //}

            ////DailySample dailySample = new DailySample
            ////{
            ////    SampleId = 50,
            ////    SampleName = "Name",
            ////    Parts = new List<DailySamplePart> {
            ////            new DailySamplePart{
            ////                PartId = 2,
            ////                PartName = "555"
            ////            }
            ////        }
            ////};

            //DailySample savedSample = _dailySampleSaver.Save(dailySample);
        }
    }
}
