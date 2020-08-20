namespace Classbook.App.Infrastructure
{
    using System.Linq;
    using System.Threading.Tasks;
    using ElectronNET.API;

    public static class ElectronUtility
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
