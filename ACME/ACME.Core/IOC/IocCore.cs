using ACME.Core.Interfaces;
using ACME.Core.Managers;
using ACME.DAL.Interfaces;
using Autofac;

namespace ACME.Core.IOC
{
    public abstract class IocCore
    {
        protected void Setup(ContainerBuilder builder)
        {
            builder.Register(GetGeneralUnitOfWork).InstancePerLifetimeScope();
            SetupManagers(builder);
        }

        private static void SetupManagers(ContainerBuilder builder)
        {
            builder.RegisterType<PersonManager>().As<IPersonManager>();
            builder.RegisterType<EmployeeManager>().As<IEmployeeManager>();
        }

        protected abstract IGeneralUnitOfWork GetGeneralUnitOfWork(IComponentContext arg);
    }
}
