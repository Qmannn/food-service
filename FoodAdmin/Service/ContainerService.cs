using Food.EntityFramework;
using Food.EntityFramework.Entities;
using FoodAdmin.Dto.ContainerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAdmin.Service
{
    public class ContainerService : IContainerService
    {
        private readonly IRepository<Container> _containerRepository;

        public ContainerService(IRepository<Container> containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public List<ContainerDto> GetContainers()
        {
            List<Container> containers = _containerRepository.All.ToList();
            return containers.ConvertAll(Convert);
        }

        private ContainerDto Convert(Container container)
        {
            return new ContainerDto
            {
                Id = container.Id,
                Name = container.Name,
                Price = container.Price
            };
        }

        public void RemoveContainer(int containerId)
        {
            _containerRepository.Delete(containerId);
        }

        public ContainerDto GetContainer(int containerId)
        {
            if (containerId == 0)
            {
                return CreateContainer();
            }

            Container container = _containerRepository.GetItem(containerId);
            ContainerDto containerDto = null;

            if (container != null)
            {
                return Convert(container);
            }

            return containerDto;
        }

        public ContainerDto CreateContainer()
        {
            return new ContainerDto
            {
                Id = 0,
                Name = "Container",
                Price = 0
            };
        }

        public ContainerDto SaveContainer(ContainerDto containerDto)
        {
            Container container = _containerRepository.GetItem(containerDto.Id) ?? new Container();
            container.Name = containerDto.Name;
            container.Price = containerDto.Price;

            container = _containerRepository.Save(container);

            return Convert(container);
        }
    }
}
