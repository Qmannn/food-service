using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Core.Domain.Entities
{
    public class DailySample
    {
        public int SampleId { get; set; }
        public string SampleName { get; set; }
        public List<DailySamplePart> Parts { get; set; }
    }
}
