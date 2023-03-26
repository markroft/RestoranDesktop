using RestoranDesktopApp.Forms;
using System.Security.Principal;

namespace RestoranDesktopApp
{
    internal static class Program
    {
       
        
        static void Main()
        {
           
            ApplicationConfiguration.Initialize();
            Application.Run(new WelcomePage());


        }
    }
}