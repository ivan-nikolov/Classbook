namespace Classbook.App.Infrastructure.ElectronUtitlity
{
    using System.Linq;
    using System.Threading.Tasks;

    using ElectronNET.API;

    public class ElectronHelper
    {
        public class Window
        {
            public static void ElectronBootstrap()
            {
                if (HybridSupport.IsElectronActive)
                {

                    Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
                }
            }

            public static void ReloadWindow()
            {
                if (HybridSupport.IsElectronActive)
                {
                    Electron.WindowManager.BrowserWindows.FirstOrDefault()?.Reload();
                }
            }

            public static void CloseWidnow()
            {
                if (HybridSupport.IsElectronActive)
                {
                    Electron.WindowManager.BrowserWindows.FirstOrDefault()?.Close();
                }
            }
        }
    }
}
