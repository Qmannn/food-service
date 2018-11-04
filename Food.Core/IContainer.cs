using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Core
{
    public interface IContainer
    {
        public int ContainerId { get; }
        public string ContainerName { get; }
        public int ContainerCost { get; }
    }
}