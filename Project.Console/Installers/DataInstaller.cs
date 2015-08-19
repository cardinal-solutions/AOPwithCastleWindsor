using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Project.Aop.Aspects;
using Project.Core.Interfaces;
using Project.Data;

namespace Project.Console.Installers
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var isProd = ConfigurationManager.AppSettings["IsProduction"] == "True";
            container.Register(Component.For<ExceptionAspect>());
            container.Register(Component.For<TimingAspect>());

            var iProjData = Component.For<IProjectData>().ImplementedBy<ProjectDataLocal>();
            iProjData.Interceptors(typeof(ExceptionAspect));

            if (isProd)
            {
                iProjData.Interceptors(typeof(TimingAspect));
            }

            container.Register(iProjData);
        }
    }
}
//public void Install(IWindsorContainer container, IConfigurationStore store)
//{
//    container.Register(Component.For<IProjectData>()
//        .ImplementedBy<ProjectDataLocal>());
//}


//combine all interceptors in one place for easy registration later
//var interceptors = new[]
//{
//                typeof(ExceptionAspect),
//                typeof(TimingAspect)
//            };