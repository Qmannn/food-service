using Food.Core.Domain.Entities;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using FoodAdmin.Domain.Services.Finders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Core.Domain.Services.Finders
{
    class DailySampleFactory : IDailySampleFactory
    {
        private readonly IRepository<Sample> _sampleRepository;
        private readonly ISamplePartFinder _samplePartFinder;

        public DailySampleFactory(IRepository<Sample> sampleRepository, ISamplePartFinder samplePartFinder)
        {
            _sampleRepository = sampleRepository;
            _samplePartFinder = samplePartFinder;
        }

        public DailySample CreateDailySample(int sampleId, List<int> partIds)
        {
            Sample sample = _sampleRepository.GetItem(sampleId);

            List<DailySamplePart> parts = _samplePartFinder.GetDailySampleParts(partIds);

            return new DailySample
            {
                SampleId = sample.Id,
                SampleName = sample.Name,
                Parts = parts
            };
        }

        public DailySample GetDailySample(int sampleId)
        {
            Sample sample = _sampleRepository.GetItem(sampleId);

            List<DailySamplePart> parts = _samplePartFinder.GetDailySampleParts(sampleId);

            return new DailySample
            {
                SampleId = sample.Id,
                SampleName = sample.Name,
                Parts = parts
            };
        }
    }
}
