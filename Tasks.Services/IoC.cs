using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.DataAccess.Infrastructure;
using Tasks.DataAccess.Repositories;

namespace Tasks.Services
{
    public class IoC
    {
        private static Lazy<IKernel> _kernel = new Lazy<IKernel>(() => new StandardKernel());
        private static Boolean _isInit = false;

        private static IKernel Kernel
        {
            get { return _kernel.Value; }
        }

        public static object Get(Type objectType)
        {
            return Kernel.Get(objectType);
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        public static void Init(Action<IKernel> initLogic)
        {
            if (initLogic != null)
                initLogic(Kernel);
        }

        public static void Reset()
        {
            _kernel = new Lazy<IKernel>(() => new StandardKernel());
        }

        public static void Init()
        {
            if (_isInit) return;
            IoC.Init((kernel) =>
            {
                kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>().InSingletonScope();
            });
            _isInit = true;
        }
    }
}