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

        [HttpPost("remove")]
        public void RemoveContainers(int Id)
        {
            _containerService.RemoveContainer(Id);
        }
    }
}