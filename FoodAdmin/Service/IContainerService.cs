using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAdmin.Dto.ContainerDto;

namespace FoodAdmin.Service
{
    public interface IContainerService
    {
        List<ContainerDto> GetContainers();
        void RemoveContainer(int containerId);
        ContainerDto GetContainer(int containerId);
        ContainerDto SaveContainer(ContainerDto containerDto);
    }
}