using System.Collections.Generic;
using FoodAdmin.Service;
using FoodAdmin.Dto.ContainerDto;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class ContainerController : Controller
    {
        private IContainerService _containerService;

        public ContainerController(IContainerService containerService)
        {
            _containerService = containerService;
        }

        [HttpGet("containers")]
        public List<ContainerDto> GetContainers()
        {
            var storedContainers = _containerService.GetContainers();
            return storedContainers;
        }

        [HttpGet("container")]
        public ContainerDto GetContainer(int containerId)
        {
            return _containerService.GetContainer(containerId);
        }

        [HttpPost("container")]
        public ContainerDto SaveContainer([FromBody] ContainerDto container)
        {
            ContainerDto savedContainerDto = _containerService.SaveContainer(container);

            return new ContainerDto
            {
                Id = savedContainerDto.Id,
                Name = savedContainerDto.Name,
                Price = savedContainerDto.Price,
            };
        }

        [HttpPost("remove")]
        public void RemoveContainers(int Id)
        {
            _containerService.RemoveContainer(Id);
        }
    }
}