using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System.IO;

namespace RevitAddin.Icon.Example.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            var icons = new[] { "Grey", "Red", "Orange", "Yellow", "Green", "Cyan", "Blue", "Purple", "Pink", "Brown" };

            ribbonPanel = application.CreatePanel("RevitAddin.Icon.Example");
            foreach (var icon in icons)
            {
                ribbonPanel.CreatePushButton<Commands.Command>(icon)
                    .SetLargeImage($"Resources/Images/Cube-{icon}-Light.ico");
            }

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }

}