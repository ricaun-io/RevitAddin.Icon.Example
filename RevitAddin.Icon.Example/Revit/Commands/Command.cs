using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace RevitAddin.Icon.Example.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIThemeManager.CurrentTheme = UIThemeManager.CurrentTheme == UITheme.Light ? UITheme.Dark : UITheme.Light;

            return Result.Succeeded;
        }
    }
}
