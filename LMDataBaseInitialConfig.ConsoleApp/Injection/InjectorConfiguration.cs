using LMDataBaseInitialConfig.ConsoleApp.Config;
using LMDataBaseInitialConfig.ConsoleApp.File;
using LMDataBaseInitialConfig.ConsoleApp.Service;
using LMDataBaseInitialConfig.ConsoleApp.Sql;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Injection
{



    public static class InjectorConfiguration
    {

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddTransient<IScriptConfigGeneratorService, ScriptConfigGeneratorService>();
            serviceCollection.AddTransient<IConfigHelpter, ConfigHelpter>();
            serviceCollection.AddTransient<IFileHelper, File.FileHelper>();
            serviceCollection.AddTransient<ISqlHelper, Sql.SqlHelper>();
            serviceCollection.AddTransient<GenCommand, GenCommand>();


        }


    }

}
