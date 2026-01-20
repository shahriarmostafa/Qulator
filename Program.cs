using Sim1Test.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sim1Test
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new Registration());
            //Application.Run(new UserInfo());
            //Application.Run(new Applications());
            //Application.Run(new AddContent());
            //Application.Run(new Contents());





        }
    }
}
