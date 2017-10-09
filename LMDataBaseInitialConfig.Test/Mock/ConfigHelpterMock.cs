using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.Test.Mock
{
    public static class ConfigHelpterMock
    {

        public static string GetJson()
        {
            return "{\"connection_strings\":{\"con1\":\"conncetionstring1\",\"con2\":\"conncetionstring2\"},\"tables\":[{\"Name\":\"Table1\",\"Insert\":true,\"Update\":true,\"Delete\":true,\"Top\":1},{\"Name\":\"Table2\",\"Insert\":true,\"Update\":true,\"Delete\":true,\"Top\":2}]}";
        }

        
    }


}
