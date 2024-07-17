using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region AutoCad API Namespaces
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
#endregion

namespace HelloCADAPI
{
    public class HelloCad
    {
        [CommandMethod("HelloAutocad")]
        public void HelloAutoCadFromCSharap()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor edt = doc.Editor;

            edt.WriteMessage("Hello Autocad From C Sharp");
        }

        [CommandMethod("HelloACAD")]
        public void HelloAutocad()
        {
            Application.ShowAlertDialog("Hello Auto Cad From C Sharp");
        }
    }
}
