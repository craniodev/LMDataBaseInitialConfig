using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.SqlHelper
{
    public interface ISqlHelper
    {

        SqlTable GetTable(string name);

    }


}
