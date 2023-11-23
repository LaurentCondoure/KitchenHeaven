
using Ninject.Modules;

using KitchenHeaven.FrameWork.Service.Interfaces;
using KitchenHeaven.FrameWork.Service.Services;

namespace KitchenHeaven.FrameWork.Service.NInject
{
    internal class InjectionModuleService : NinjectModule
    {
        public override void Load()
        {

            Kernel.Bind<IMealService>().To<MealService>();

            Kernel.Bind<IMenuService>().To<MenuService>();

            Kernel.Bind<IRestaurantService>().To<RestaurantService>();


        }
    }
}
