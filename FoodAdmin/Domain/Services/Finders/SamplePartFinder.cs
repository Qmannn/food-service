using Food.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAdmin.Domain.Services.Finders
{
    public class SamplePartFinder : ISamplePartFinder
    {
        public List<DailySamplePart> GetDailySampleParts(List<int> partIds)
        {
            return new List<DailySamplePart>
            {
                new DailySamplePart
                {
                    PartId = 50,
                    PartName = "Name"
                },

                new DailySamplePart
                {
                    PartId = 55,
                    PartName = "Name1"
                }
            };
        }

        public List<DailySamplePart> GetDailySampleParts(int sampleId)
        {
            throw new NotImplementedException();
        }
    }
}
