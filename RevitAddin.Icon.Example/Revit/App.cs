using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System.IO;
using System.Linq;

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
                    .SetLargeImage($"Resources/Images/Cube-{icon}-Light.tiff");
            }

            ribbonPanel.AddSlideOut();

            foreach (var icon in icons)
            {
                ribbonPanel.RowLargeStackedItems(
                    ribbonPanel.CreatePushButton<Commands.Command>(icon)
                        .SetLargeImage($"Resources/Images/Cube-{icon}-Light.tiff")
                        .SetShowText(),
                    ribbonPanel.CreatePushButton<Commands.Command>(icon)
                        .SetLargeImage($"Resources/Images/Box-{icon}-Light.tiff")
                        .SetShowText()
                );
            }

            foreach (var icon in icons)
            {
                ribbonPanel.RowStackedItems(
                    ribbonPanel.CreatePushButton<Commands.Command>(icon)
                        .SetLargeImage($"Resources/Images/Cube-{icon}-Light.tiff")
                        .SetShowText(),
                    ribbonPanel.CreatePushButton<Commands.Command>(icon)
                        .SetLargeImage($"Resources/Images/Box-{icon}-Light.tiff")
                        .SetShowText()
                );
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