using System.Collections.Generic;
using FoodAdmin.Dto.Sample;

namespace FoodAdmin.Service
{
    public interface ISampleService
    {
        SampleDto GetSample( int sampleId );
        List<SampleDto> GetSamples();
        SampleDto SaveSample( SampleDto sampleDto );
    }
}