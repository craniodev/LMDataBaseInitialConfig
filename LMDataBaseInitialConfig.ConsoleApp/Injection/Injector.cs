using LMDataBaseInitialConfig.ConsoleApp.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Injection
{

    /// <summary>
    /// Singleton design pattern
    /// http://www.dofactory.com/net/singleton-design-pattern
    /// </summary>
    public class Injector : IInjector
    {
        private static Injector _instance;
        private ServiceCollection serviceCollection;
        private ServiceProvider serviceProvider;

        // Constructor is 'protected'
        protected Injector()
        {

            // create service collection
            serviceCollection = new ServiceCollection();
            InjectorConfiguration.ConfigureServices(serviceCollection);

            // create service provider
            serviceProvider = serviceCollection.BuildServiceProvider();


        }

        public static Injector Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Injector();
            }

            return _instance;
        }

        public T GetService<T>()
        {
            return serviceProvider.GetService<T>();
        }


    }

}
