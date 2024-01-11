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
        private static RibbonImageThemeSelector ribbonImageThemeSelector;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonImageThemeSelector = new RibbonImageThemeSelector(application);

            var icons = new[] { "Grey", "Red", "Yellow", "Green", "Cyan", "Blue", "Purple", "Pink", "Brown" };

            ribbonPanel = application.CreatePanel("RevitAddin.Icon.Example");
            foreach (var icon in icons)
            {
                ribbonPanel.CreatePushButton<Commands.Command>(icon)
                    .SetLargeImage($"Resources/Images/Cube-{icon}.ico");
            }

            ribbonImageThemeSelector.AddRibbonItem(ribbonPanel.GetRibbonItems());

            ribbonImageThemeSelector.UpdateImages();

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            ribbonImageThemeSelector?.Dispose();
            return Result.Succeeded;
        }
    }

}