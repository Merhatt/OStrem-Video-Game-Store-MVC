﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Utils.Factories.Contracts;
using VideoGameStore.Utils.Pagings.Contracts;
using VideoGameStore.Web.Controllers;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Tests.Controllers.GamesPageControllerTests
{
    [TestFixture]
    public class GetPagesCountTests
    {
        [Test]
        public void ShouldGetModel()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categortServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            var controller = new GamesPageController(gameServicesMock.Object,
                categortServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                gameModelFactoryMock.Object);

            var allGames = new List<Game>()
            {
                new Game()
            };

            gameServicesMock.Setup(x => x.GetAll())
                .Returns(allGames);

            var pageServiceMock = new Mock<IPageService<Game>>();

            pageServiceFactoryMock.Setup(x => x.Create(It.IsAny<IEnumerable<Game>>(), It.IsAny<int>()))
                .Returns(pageServiceMock.Object);

            pageServiceMock.Setup(x => x.GetPage(It.IsAny<int>()))
                .Returns(allGames);

            GamesPageViewModel model = new GamesPageViewModel();

            gamesPageViewModelFactoryMock.Setup(x => x.Create(It.IsAny<IEnumerable<Game>>()))
                .Returns(model);

        
            //Act
            var view = controller.GetPagesCount() as JsonResult;

            //Assert
            Assert.NotNull(view);
            gameServicesMock.Verify(x => x.GetAll(), Times.Once());
        }
    }
}
