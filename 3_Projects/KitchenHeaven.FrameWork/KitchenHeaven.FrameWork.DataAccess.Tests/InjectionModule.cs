using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenHeaven.FrameWork.DataAccess.Tests
{
    internal class InjectionModule : NinjectModule
    {
        public override void Load()
        {

            //Kernel.Bind<IAPIAccessFactory>().To<APIAccessFactory>();
        }
    }
}
