using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ShopTARge23.Core.Domain;
using ShopTARge23.ApplicationServices.Services;
using Xunit;

namespace ShopTARge23.SpaceshipsTest
{
    public class SpaceShipsTest : TestBase
    {

        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            //Arrange
            SpaceshipDto dto = new();
            dto.Name = "TestName";
            dto.Typename = "Moonship";
            dto.BuiltDate = DateTime.Now;
            dto.Crew = 6;
            dto.EnginePower = 30;
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(dto);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_GetBydSpaceship_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("173d934d-6446-4a36-a200-515ea63d1795");
            Guid guid = Guid.Parse("173d934d-6446-4a36-a200-515ea63d1795");

            await Svc<ISpaceshipsServices>().DetailAsync(guid);

            Assert.Equal(databaseGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            SpaceshipDto spaceship = MockSpaceshipData();


            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship.Id);

            Assert.Equal(result, addSpaceship);
        }

        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "TestName",
                Typename = "Moonship",
                BuiltDate = DateTime.Now.AddDays(-10),
                Crew = 2,
                EnginePower = 30,
                CreatedAt = DateTime.Now.AddDays(-1),
                ModifiedAt = DateTime.Now.AddDays(-1),

            };

            return spaceship;
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var spaceship1 = await Svc<ISpaceshipsServices>().Create(spaceship);
            var spaceship2 = await Svc<ISpaceshipsServices>().Create(spaceship);

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)spaceship2.Id);

            Assert.NotEqual(result.Id, spaceship1.Id);

        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("173d934d-6446-4a36-a200-515ea63d1795");

            SpaceshipDto dto = MockSpaceshipData();
            Spaceship spaceship = new();

            spaceship.Id = Guid.Parse("173d934d-6446-4a36-a200-515ea63d1795");
            spaceship.Name = "TestName";
            spaceship.Typename = "Mars ship";
            spaceship.BuiltDate = DateTime.Now.AddDays(-10);
            spaceship.Crew = 2;
            spaceship.EnginePower = 30;
            spaceship.CreatedAt = DateTime.Now.AddDays(-1);
            spaceship.ModifiedAt = DateTime.Now.AddDays(-1);

            await Svc<ISpaceshipsServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);

        }

        private SpaceshipDto MockUpdateSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "TestName",
                Typename = "Moonship",
                BuiltDate = DateTime.Now.AddDays(-10),
                Crew = 2,
                EnginePower = 30,
                CreatedAt = DateTime.Now.AddDays(-1),
                ModifiedAt = DateTime.Now,

            };

            return spaceship;
        }
    }
}
