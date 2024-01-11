using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace RevitAddin.Icon.Example.Revit
{
    public class RibbonImageThemeSelector : IDisposable
    {
        private readonly UIControlledApplication application;
        private List<RibbonItem> ribbonItems = new List<RibbonItem>();
        public RibbonImageThemeSelector(UIControlledApplication application)
        {
            this.application = application;
            this.application.ThemeChanged += Application_ThemeChanged;
        }

        internal void AddRibbonItem(IList<RibbonItem> ribbonItems)
        {
            foreach (var ribbonItem in ribbonItems)
            {
                AddRibbonItem(ribbonItem);
            }
        }

        public void AddRibbonItem(RibbonItem ribbonItem)
        {
            ribbonItems.Add(ribbonItem);
        }

        public void UpdateImages()
        {
            foreach (var ribbonItem in ribbonItems)
            {
                UpdateImageTheme(ribbonItem);
            }
        }

        private static string ReplaceLastOccurrence(string source, string find, string replace)
        {
            int place = source.LastIndexOf(find);
            if (place == -1)
                return source;

            string result = source.Remove(place, find.Length).Insert(place, replace);
            return result;
        }

        private void UpdateImageTheme(RibbonItem ribbonItem)
        {
            const string ICO = ".ico";
            const string ICO_DARK = "-dark.ico";

            var theme = UIThemeManager.CurrentTheme;
            if (ribbonItem is RibbonButton ribbonButton)
            {
                if (ribbonButton.LargeImage is BitmapSource source)
                {
                    var sourceString = source.ToString().ToLowerInvariant();
                    if (theme == UITheme.Dark)
                    {
                        if (ReplaceLastOccurrence(sourceString, ICO, ICO_DARK).GetBitmapSource() is BitmapSource darkSource)
                        {
                            ribbonButton.SetLargeImage(darkSource);
                        }
                    }

                    if (theme == UITheme.Light)
                    {
                        if (ReplaceLastOccurrence(sourceString, ICO_DARK, ICO).GetBitmapSource() is BitmapSource lightSource)
                        {
                            ribbonButton.SetLargeImage(lightSource);
                        }
                    }
                }
            }

        }

        private void Application_ThemeChanged(object sender, Autodesk.Revit.UI.Events.ThemeChangedEventArgs e)
        {
            UpdateImages();
        }

        public void Dispose()
        {
            this.application.ThemeChanged -= Application_ThemeChanged;
        }


    }

}