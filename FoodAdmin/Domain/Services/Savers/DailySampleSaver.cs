using Food.Core.Domain.Entities;
using Food.Core.Domain.Services.Finders;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAdmin.Domain.Services.Savers
{
    public class DailySampleSaver : IDailySampleSaver
    {
        private readonly IRepository<Sample> _repository;
        private readonly ISamplePartsSaver _samplePartsSaver;
        private readonly IDailySampleFactory _dailySampleFactory;

        public DailySampleSaver(IRepository<Sample> repository, ISamplePartsSaver samplePartsSaver, IDailySampleFactory dailySampleFactory)
        {
            _repository = repository;
            _samplePartsSaver = samplePartsSaver;
            _dailySampleFactory = dailySampleFactory;
        }

        public DailySample Save(DailySample dailySample)
        {
            Sample sample = _repository.GetItem(dailySample.SampleId) ?? new Sample();
            sample.Name = dailySample.SampleName;

            _repository.Save(sample);

            foreach (var part in dailySample.Parts)
            {
                _samplePartsSaver.SavePart(part);
            }

            return _dailySampleFactory.GetDailySample(sample.Id);
        }
    }
}
