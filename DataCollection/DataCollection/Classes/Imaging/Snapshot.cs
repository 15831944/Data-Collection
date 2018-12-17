using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System.Threading;

namespace DataCollection.Classes.Imaging
{
    class Snapshot
    {
        public static void SnapEnds(Editor ed, Database db, ObjectId lineObj, String LayerType, int LayOff)
        {
            //Add points to the LayerType string for later sorting
            if (LayOff == 1)
            {
                LayerType = LayerType + " points";
            }
            else
            {
                LayerType = LayerType + " points LayOn";
            }

            using (Transaction Trans = db.TransactionManager.StartTransaction())
            {
                Line line = (Line)Trans.GetObject(lineObj, OpenMode.ForRead);
                //Setup point extents
                Point3d pMin = new Point3d(line.StartPoint.X - (line.Length /8), line.StartPoint.Y - (line.Length /8), 0);
                Point3d pMax = new Point3d(line.StartPoint.X + (line.Length /8), line.StartPoint.Y + (line.Length /8), 0);
                //Point3d pCenter = new Point3d(line.StartPoint.X, line.StartPoint.Y, 0);

                //Setup the line for a screenshot focused at the end of start line
                Imaging.ObjectZoom.ZoomWin(ed, pMin, pMax);
                //Zoom.ZoomPoint(pMin, pMax, pCenter, 0);
                //ed.Regen();
                Thread.Sleep(1000);
                ed.WriteMessage("2\n");

                //Take a screen shot of the start point
                Screenshot.Snap(LayerType,0);
                ObjectZoom.ZoomWin(ed, pMin, pMax);
                //Screenshot.Snap(LayerType, 0);
                //ObjectZoom.ZoomWin(ed, pMin, pMax);
                Screenshot.Snap(LayerType,1);

                //    Trans.Commit();
                //}
                //using (Transaction Trans = db.TransactionManager.StartTransaction())
                //{
                //    Line line = (Line)Trans.GetObject(lineObj, OpenMode.ForRead);

                //Setup point extents
                Point3d pMinEnd = new Point3d(line.EndPoint.X - (line.Length / 8), line.EndPoint.Y - (line.Length / 8), 0);
                Point3d pMaxEnd = new Point3d(line.EndPoint.X + (line.Length / 8), line.EndPoint.Y + (line.Length / 8), 0);
                //Point3d pCenter = new Point3d(line.EndPoint.X, line.EndPoint.Y, 0);

                //Setup the line for a screenshot focused at the end of start line
                //Imaging.Camera.Zoom(pMinEnd, pMaxEnd, new Point3d() , 1);
                Imaging.ObjectZoom.ZoomWin(ed, pMinEnd, pMaxEnd);
                Screenshot.Snap(LayerType, 0);
                ObjectZoom.ZoomWin(ed, pMinEnd, pMaxEnd);
                //ed.WriteMessage("2\n");
                //Thread.Sleep(1000);
                ed.Regen();
                Thread.Sleep(1000);

                //Take a screen shot of the start point
                Screenshot.Snap(LayerType,1);

                Trans.Commit();
            }
        }



        public static void SnapWhole(Editor ed, Database db, ObjectId lineObj, String LayerType)
        {
            //Add object string to the LayerType string for later sorting
            LayerType = LayerType + " object";

            using (Transaction Trans = db.TransactionManager.StartTransaction())
            {
                Line line = (Line)Trans.GetObject(lineObj, OpenMode.ForRead);
                //Setup point extents
                Point3d pMin = new Point3d(line.StartPoint.X, line.StartPoint.Y, 0);
                Point3d pMax = new Point3d(line.StartPoint.X, line.StartPoint.Y, 0);
                //Point3d pCenter = new Point3d(line.StartPoint.X, line.StartPoint.Y, 0);

                //Setup the line for a screenshot focused at the end of start line
                Imaging.ObjectZoom.ZoomWin(ed, pMin, pMax);
                //Zoom.ZoomPoint(pMin, pMax, pCenter, 0);
                //ed.Regen();
                Thread.Sleep(1000);
                ed.WriteMessage("2\n");

                //Take a screen shot of the start point
                Screenshot.Snap(LayerType, 0);
                ObjectZoom.ZoomWin(ed, pMin, pMax);
                Screenshot.Snap(LayerType, 1);

                //    Trans.Commit();
                //}
                //using (Transaction Trans = db.TransactionManager.StartTransaction())
                //{
                //    Line line = (Line)Trans.GetObject(lineObj, OpenMode.ForRead);

                //Setup point extents
                Point3d pMinEnd = new Point3d(line.EndPoint.X, line.EndPoint.Y, 0);
                Point3d pMaxEnd = new Point3d(line.EndPoint.X, line.EndPoint.Y, 0);
                //Point3d pCenter = new Point3d(line.EndPoint.X, line.EndPoint.Y, 0);

                //Setup the line for a screenshot focused at the end of start line
                //Imaging.Camera.Zoom(pMinEnd, pMaxEnd, new Point3d() , 1);
                Imaging.ObjectZoom.ZoomWin(ed, pMinEnd, pMaxEnd);
                //ed.WriteMessage("2\n");
                //Thread.Sleep(1000);
                ed.Regen();
                Thread.Sleep(1000);

                //Take a screen shot of the start point
                Screenshot.Snap(LayerType, 1);

                Trans.Commit();
            }
        }
    }
}
