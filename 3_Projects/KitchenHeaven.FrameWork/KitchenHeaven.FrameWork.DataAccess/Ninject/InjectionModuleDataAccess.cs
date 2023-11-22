using Ninject.Modules;

using KitchenHeaven.FrameWork.DataAccess.DataAccess;
using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.UOW;
using KitchenHeaven.FrameWork.DataAccess.Factories;

namespace KitchenHeaven.FrameWork.DataAccess.Ninject
{
    public class InjectionModuleDataAccess : NinjectModule
    {
        public override void Load()
        {

            Kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            Kernel.Bind<IAPIAcessFactory>().To<APIAccessFactory>();


        }
    }
}
