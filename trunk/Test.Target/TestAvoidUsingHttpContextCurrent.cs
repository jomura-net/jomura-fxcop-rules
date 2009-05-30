using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Test.Target
{
    public static class TestAvoidUsingHttpContextCurrent
    {
        public static void Test()
        {
            string machineName = HttpContext.Current.Server.MachineName;
            System.Diagnostics.Debug.WriteLine(machineName);
        }
    }
}
