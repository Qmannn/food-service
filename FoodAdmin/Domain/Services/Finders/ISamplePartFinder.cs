using System.Collections.Generic;
using Food.Core.Domain.Entities;

namespace FoodAdmin.Domain.Services.Finders
{
    public interface ISamplePartFinder
    {
        List<DailySamplePart> GetDailySampleParts(List<int> partIds);
        List<DailySamplePart> GetDailySampleParts(int sampleId);
    }
}