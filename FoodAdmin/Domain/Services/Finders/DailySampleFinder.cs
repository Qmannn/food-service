using Food.Core.Domain.Entities;
using Food.Core.Domain.Services.Finders;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAdmin.Domain.Services.Finders
{
    public class DailySampleFinder
    {
        private readonly ISamplePartFinder _samplePartFinder;
        private readonly IDailySampleFactory _dailySampleFactory;

        public DailySampleFinder(IDailySampleFactory dailySampleFactory, ISamplePartFinder samplePartFinder)
        {
            _dailySampleFactory = dailySampleFactory;
            _samplePartFinder = samplePartFinder;
        }

        public DailySample GetDailySample(int sampleId)
        {
            List<DailySamplePart> dailySampleParts = _samplePartFinder.GetDailySampleParts(sampleId);

            return _dailySampleFactory.CreateDailySample(sampleId, dailySampleParts.ConvertAll(item => item.PartId));
        }
    }
}
