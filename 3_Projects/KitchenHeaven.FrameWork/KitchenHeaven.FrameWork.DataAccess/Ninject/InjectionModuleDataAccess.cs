using Ninject.Modules;

using KitchenHeaven.FrameWork.DataAccess.Factories;
using KitchenHeaven.FrameWork.DataAccess.UOW;

namespace KitchenHeaven.FrameWork.DataAccess.Ninject
{
    /// <summary>
    /// Register all bindings of KitchenHeaven.FrameWork.DataAccess in Ninject
    /// ex : Kernel.Load("KitchenHeaven.FrameWork.DataAccess.dll");
    /// </summary>
    public class InjectionModuleDataAccess : NinjectModule
    {
        public override void Load()
        {

            Kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            Kernel.Bind<IAPIAccessFactory>().To<APIAccessFactory>();//.WithConstructorArgument("options",);


        }
    }
}
