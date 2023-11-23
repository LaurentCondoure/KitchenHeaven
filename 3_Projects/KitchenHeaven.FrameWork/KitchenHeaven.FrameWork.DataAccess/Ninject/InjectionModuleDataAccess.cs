using Ninject.Modules;

using KitchenHeaven.FrameWork.DataAccess.Factories;
using KitchenHeaven.FrameWork.DataAccess.UOW;

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
