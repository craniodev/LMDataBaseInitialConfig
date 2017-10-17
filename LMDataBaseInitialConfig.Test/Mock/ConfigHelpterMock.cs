﻿using System;
using Xunit;
using Moq;
using LMDataBaseInitialConfig.ConsoleApp.Sql;
using LMDataBaseInitialConfig.ConsoleApp.File;
using LMDataBaseInitialConfig.ConsoleApp.Config;
using System.Collections.Generic;
using System.IO;
using LMDataBaseInitialConfig.ConsoleApp.Service;
using LMDataBaseInitialConfig.Test.Mock;

namespace LMDataBaseInitialConfig.Test.Mock
{
    public static class ConfigHelpterMock
    {

        public static string get_Json_ConfigHelpter_Load()
        {




            return MockHelper.GetJsonMock("ConfigHelpter_Load");
        }

        public static string get_Json_ConfigHelpter_Save()
        {




            return MockHelper.GetJsonMock("ConfigHelpter_Save");
        }


    }


}
