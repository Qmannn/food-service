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
    }
}
