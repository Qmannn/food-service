using System.Collections.Generic;
using Food.Core.Domain.Entities;

namespace Food.Core.Domain.Services.Finders
{
    public interface IDailySampleFactory
    {
        DailySample CreateDailySample(int sampleId, List<int> partIds);
        DailySample GetDailySample(int sampleId);
    }
}