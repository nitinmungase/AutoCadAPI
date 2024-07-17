using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Autocad API Namespaces
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

#endregion

namespace DrawObject
{
    public class DrawObject
    {
        [CommandMethod("DrawLine")]
        public void DrawLine()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor edt = doc.Editor;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt = trans.GetObject(db.BlockTableId , OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    /// Send a Message to the user
                    edt.WriteMessage("Drawing a Line Object");

                    ///Create Points for Line
                    Point3d pt1 = new Point3d(0, 0, 0);
                    Point3d pt2 = new Point3d(100, 100, 0);

                    ///Create Line Using Points
                    Line ln = new Line(pt1,pt2);

                    ///Colour line with ColorIndex
                    ln.ColorIndex= 1;

                    ///AppendEntity to BlockTableRecord
                    btr.AppendEntity(ln);

                    ///AddNewlyCreatedDBObject
                    trans.AddNewlyCreatedDBObject(ln, true);

                    ///Commit Trnasaction
                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    edt.WriteMessage(ex.Message);
                    trans.Abort();
                }

            }

        }
    }
}
