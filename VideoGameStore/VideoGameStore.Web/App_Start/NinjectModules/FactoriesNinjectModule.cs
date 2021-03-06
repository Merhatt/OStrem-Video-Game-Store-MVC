﻿using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Utils.Factories;
using VideoGameStore.Utils.Factories.Contracts;
using VideoGameStore.Utils.Pagings;
using VideoGameStore.Utils.Pagings.Contracts;
using VideoGameStore.Web.Models.Factories;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.App_Start.NinjectModules
{
    public class FactoriesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IGameFactory>().To<GameFactory>().InSingletonScope();
            this.Kernel.Bind<IGameInfoViewModelFactory>().To<GameInfoViewModelFactory>().InSingletonScope();
            this.Kernel.Bind<ICheckBoxModelFactory>().To<CheckBoxModelFactory>().InSingletonScope();
            this.Kernel.Bind<ISuportedPlatformModelFactory>().To<SuportedPlatformModelFactory>().InSingletonScope();
            this.Kernel.Bind<IReviewModelFactory>().To<ReviewModelFactory>().InSingletonScope();
            this.Kernel.Bind<IUserModelFactory>().To<UserModelFactory>().InSingletonScope();
            this.Kernel.Bind<IGamesPageViewModelFactory>().To<GamesPageViewModelFactory>().InSingletonScope();
            this.Kernel.Bind<IAddGameViewModelFactory>().To<AddGameViewModelFactory>().InSingletonScope();
            this.Kernel.Bind<IReviewFactory>().To<ReviewFactory>().InSingletonScope();
            this.Kernel.Bind<ICartViewModelFactory>().To<CartViewModelFactory>().InSingletonScope();
            this.Kernel.Bind(typeof(IPageServiceFactory<>)).To(typeof(PageServiceFactory<>)).InSingletonScope();
            this.Kernel.Bind<IGameModelFactory>().To<GameModelFactory>().InSingletonScope();
        }
    }
}