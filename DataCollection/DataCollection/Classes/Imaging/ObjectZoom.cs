using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using AutoCAD;

namespace DataCollection.Classes.Imaging
{
    class ObjectZoom
    {
        public static void ZoomWin(Editor ed, Point3d min, Point3d max)
        {
            Point2d min2d = new Point2d(min.X, min.Y);
            Point2d max2d = new Point2d(max.X, max.Y);

            ViewTableRecord view = new ViewTableRecord
            {
                CenterPoint = min2d + ((max2d - min2d) / 2.0),
                Height = max2d.Y - min2d.Y,
                Width = max2d.X - min2d.X
            };
            ed.SetCurrentView(view);
        }

        // Zoom via COM

        private static void ZoomWin2(Editor ed, Point3d min, Point3d max)
        {
            AcadApplication app = (AcadApplication)Application.AcadApplication;

            double[] lower = new double[3] { min.X, min.Y, min.Z };
            double[] upper = new double[3] { max.X, max.Y, max.Z };

            app.ZoomWindow(lower, upper);
        }

        // Zoom by sending a command

        public static void ZoomWin3(Editor ed, Point3d min, Point3d max)
        {
            string lower = min.ToString().Substring(1,min.ToString().Length - 2);
            string upper = max.ToString().Substring(1,max.ToString().Length - 2);

            string cmd = "_.ZOOM _W " + lower + " " + upper + " ";

            // Call the command synchronously using COM

            AcadApplication app = (AcadApplication)Application.AcadApplication;

            app.ActiveDocument.SendCommand(cmd);

            // Could also use async command calling:
            //ed.Document.SendStringToExecute(
            //  cmd, true, false, true
            //);
        }
    }
}
