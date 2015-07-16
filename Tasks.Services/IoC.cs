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
            IoC.Init((kernel) =>
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                //kernel.Bind<ICategoryRepository>().To<CategoryRepository>().InTransientScope();
                //kernel.Bind<ITaskRepository>().To<TaskRepository>().InTransientScope();
                //kernel.Bind<ISubTaskRepository>().To<SubTaskRepository>().InTransientScope();
            });
        }

    }

}