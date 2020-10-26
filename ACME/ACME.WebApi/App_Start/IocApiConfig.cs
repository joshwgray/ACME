using ACME.Core.IOC;
using ACME.DAL;
using ACME.DAL.Interfaces;
using ACME.WebApi.Controllers;
using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http.Dependencies;

namespace ACME.WebApi.App_Start
{
    public class IocApiConfig : IocCore
    {
        private static bool _isInitialized;
        private static readonly object _locker = new object();
        private static IocApiConfig _instance;
        private readonly IContainer _container;

        public IocApiConfig()
        {
            var builder = new ContainerBuilder();
            Setup(builder);
            SetupControllers(builder);
            SetupWebApi(builder);
            
            _container = builder.Build();
        }

        private void SetupWebApi(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(typeof(PersonController).Assembly);
            builder.Register((t) => new AutofacWebApiDependencyResolver(_container)).As<IDependencyResolver>();
        }

        private void SetupControllers(ContainerBuilder builder)
        {
            builder.RegisterType<PersonController>();
            builder.RegisterType<EmployeeController>();
        }

        #region Initialize

        public static IocApiConfig Instance
        {
            get
            {
                if (_isInitialized) return _instance;
                lock (_locker)
                {
                    if (!_isInitialized)
                    {
                        _instance = new IocApiConfig();
                        _isInitialized = true;
                    }
                }
                return _instance;
            }
        }

        public IContainer Container
        {
            get { return _container; }
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        #endregion

        #region Overrides of IocCoreBase

        protected override IGeneralUnitOfWork GetGeneralUnitOfWork(IComponentContext arg)
        {
            return new GeneralUnitOfWork();
        }

        #endregion
    }
}