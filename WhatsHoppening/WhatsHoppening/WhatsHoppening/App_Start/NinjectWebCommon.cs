[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WhatsHoppening.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WhatsHoppening.App_Start.NinjectWebCommon), "Stop")]

namespace WhatsHoppening.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using WhatsHoppening.Domain.Interfaces;
    using WhatsHoppening.Providers.LocationManager;
    using WhatsHoppening.Providers.Logger;
    using WhatsHoppening.Providers.PermissionsManager;
    using WhatsHoppening.Providers.PersistenceProvider;
    using WhatsHoppening.Providers.SessionManager;
    using WhatsHoppening.Providers.UserManager;
    using Providers.ClientStorage;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILocationManager>().To<MockedLocationManager>().InRequestScope();
            kernel.Bind<ILogger>().To<ConsoleLogger>().InRequestScope();
            kernel.Bind<IPermissionsManager>().To<MockedPermissionsManager>().InRequestScope();
            kernel.Bind<IPersistenceProvider>().To<MockedPersistenceProvider>().InRequestScope();
            kernel.Bind<ISessionManager>().To<CookieAndDbSessionManager>().InSingletonScope();
            kernel.Bind<IUserManager>().To<MockedUserManager>().InRequestScope();
            kernel.Bind<IClientStorageProvider>().To<CookieClientStorageProvider>().InSingletonScope();
        }        
    }
}
