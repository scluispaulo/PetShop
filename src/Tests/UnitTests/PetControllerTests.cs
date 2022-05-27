using Application.Controllers;
using Application.DTOs;
using Application.Mapper;
using AutoMapper;
using Domain.Entities;
using Moq;
using Service.Interfaces;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace UnitTests
{
    public class PetControllerTests
    {
        private readonly PetController _petController;
        private readonly Mock<IPetService> _service = new Mock<IPetService>();
        private readonly Mock<IAccommodationService> _accommodationService = new Mock<IAccommodationService>();
        
        public PetControllerTests()
        {
            var mapperProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
            var mapper = new Mapper(configuration);

            _petController = new PetController(_service.Object, mapper, _accommodationService.Object);
        }

        [Fact]
        public async Task GetPetById_ShouldReturnPet_WhenPetExists()
        {
            var petId = 1;
            Pet petExp = new Pet { Id = petId, Name = "Jade" };
            _service.Setup(x => x.GetPetById(petId, false)).ReturnsAsync(petExp);

            var response = await _petController.GetPetById(petId);

            response.Result.As<Microsoft.AspNetCore.Mvc.OkObjectResult>().Value.As<PetDTO>().Id.Should().Be(petId);
        }

        [Fact]
        public async Task GetPetById_ShouldReturnNotFound_WhenPetNotExists()
        {
            var nonExistentPetId = 111;
            
            var response = await _petController.GetPetById(nonExistentPetId);

            response.Result.As<Microsoft.AspNetCore.Mvc.NotFoundResult>().StatusCode.Should().Be(404);
        }
    }
}
