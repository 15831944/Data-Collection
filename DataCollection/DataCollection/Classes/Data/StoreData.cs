//Goes through each layer passed to the class and sorts out each object on that layer/s.
//It then stores all the layer names for later to find non-indicated layer name.
//Stores all layers in a database using table adapters.

using Autodesk.AutoCAD.ApplicationServices;
using Aapp = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System.Collections.Generic;

using System.Windows.Forms;

namespace DataCollection.Classes.Data
{
    class CollectInfo
    {
        public static void LayerInfoGrab(IEnumerable<string> LayName, string LayerType, string DocName)
        {
            //link to the current document and databases
            Document Doc = Aapp.DocumentManager.MdiActiveDocument;
            Database db = Doc.Database;
            Editor ed = Doc.Editor;

            using (Transaction Trans = db.TransactionManager.StartTransaction())
            {
                //Open the block table open for read
                BlockTable Btr = Trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                //Open the model space database for read
                BlockTableRecord BtrModel = Trans.GetObject(Btr[BlockTableRecord.ModelSpace],OpenMode.ForRead) as BlockTableRecord;

                //Open the model space database for write
                BlockTableRecord BtrModelWrite = Trans.GetObject(Btr[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                ///////////////////////////////////////////////////////////////////////////////////
                //explode all objects in the model space
                foreach (ObjectId ReadObject in BtrModel)
                {
                    //Open the DBobject
                    var dbObj = Trans.GetObject(ReadObject, OpenMode.ForRead);

                    //Check to see if the object is a polyline
                    var rxClassPline = RXClass.GetClass(typeof(Polyline));
                    //Test the object for entity type
                    if (ReadObject.ObjectClass.IsDerivedFrom(rxClassPline))
                    {
                        //Open the DBobject
                        Polyline Pline = (Polyline)Trans.GetObject(ReadObject, OpenMode.ForRead);

                        //Collect exploded object parts with this
                        using (DBObjectCollection acDBObjColl = new DBObjectCollection())
                        {
                            //Explode the object
                            Pline.Explode(acDBObjColl);

                            //save each new entity from the exploded object
                            foreach (Entity acEnt in acDBObjColl)
                            {
                                // Add the new object to the block table record and the transaction
                                BtrModelWrite.AppendEntity(acEnt);
                                Trans.AddNewlyCreatedDBObject(acEnt, true);
                            }
                        }

                    }


                    var rxClassBref = RXClass.GetClass(typeof(BlockReference));
                    //Test the object for block type
                    if (ReadObject.ObjectClass.IsDerivedFrom(rxClassBref))
                    {
                        //Open the DBobject
                        BlockReference Bref = (BlockReference)Trans.GetObject(ReadObject, OpenMode.ForRead);

                        //Collect exploded object parts with this
                        using (DBObjectCollection acDBObjColl = new DBObjectCollection())
                        {
                            Bref.Explode(acDBObjColl);

                            //save each new entity from the exploded object
                            foreach (Entity acEnt in acDBObjColl)
                            {
                                //Add the new objects to the block table record and the transaction
                                BtrModelWrite.AppendEntity(acEnt);
                                Trans.AddNewlyCreatedDBObject(acEnt, true);
                            }
                        }

                    }
                }
                ///////////////////////////////////////////////////////////////////////



                //Step through the objects and find any on the layer we want
                foreach (ObjectId ReadObject in BtrModel)
                {
                    foreach (string LayerName in LayName)
                    {
                        var rxClassline = RXClass.GetClass(typeof(Line));
                        //Test the object for block type
                        if (ReadObject.ObjectClass.IsDerivedFrom(rxClassline))
                        {
                            //Open the DBobject
                            Line line = (Line)Trans.GetObject(ReadObject, OpenMode.ForRead);

                            //Check the Dbobject belings to a layer we are intersted in
                            if (line.Layer==LayerName)
                            {
                                //Add data to the table
                                DataConnection.ExcelConnect(line.Handle.Value, line.StartPoint.X, line.EndPoint.X,
                                    line.StartPoint.Y, line.EndPoint.Y, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, line.Angle, 
                                    "Line", line.Color.Red, line.Color.Blue, line.Color.Green, LayerName, DocName, line.Thickness, 
                                    line.Linetype, line.Length);

                                //If the layer type is a property boundary send the info to also confirm the screen shot is near a road
                                if (LayerType == "Pboundary")
                                {
                                    Form Psort = new Imaging.SortpBoundaryImages();
                                }
                                //Else just take screenshots
                                else
                                {
                                    Imaging.LineImages.Initiate(db, ed, ReadObject, LayerType, LayerName);
                                }
                            }
                        }

                        var rxClass_Circle = RXClass.GetClass(typeof(Circle));
                        //Test the object for block type
                        if (ReadObject.ObjectClass.IsDerivedFrom(rxClass_Circle))
                        {
                            //Open the DBobject
                            Circle circle = (Circle)Trans.GetObject(ReadObject, OpenMode.ForRead);

                            //Check the Dbobject belings to a layer we are intersted in
                            if (circle.Layer == LayerName)
                            {
                                //Add data to the table 
                                DataConnection.ExcelConnect( circle.Handle.Value, double.NaN, double.NaN,
                                    double.NaN, double.NaN, circle.Center.X, circle.Center.Y, double.NaN, double.NaN, circle.Radius, double.NaN, "Circle", circle.Color.Red,
                                    circle.Color.Blue, circle.Color.Green, LayerName, DocName, circle.Thickness, circle.Linetype, double.NaN);
                            }

                        }

                        var rxClass_Arc = RXClass.GetClass(typeof(Arc));
                        //Test the object for block type
                        if (ReadObject.ObjectClass.IsDerivedFrom(rxClass_Arc))
                        {
                            //Open the DBobject
                            Arc arc = (Arc)Trans.GetObject(ReadObject, OpenMode.ForRead);

                            //Check the Dbobject belings to a layer we are intersted in
                            if (arc.Layer == LayerName)
                            {
                                //Add data to the table 
                                DataConnection.ExcelConnect(arc.Handle.Value, arc.StartPoint.X, arc.EndPoint.X,
                                    arc.StartPoint.Y, arc.EndPoint.Y, double.NaN, double.NaN, arc.StartAngle, arc.EndAngle, double.NaN, double.NaN, "Arc", arc.Color.Red,
                                    arc.Color.Blue, arc.Color.Green, LayerName, DocName, arc.Thickness, arc.Linetype,arc.Length);
                            }
                        }

                        var rxClass_Ellipse = RXClass.GetClass(typeof(Ellipse));
                        //Test the object for block type
                        if (ReadObject.ObjectClass.IsDerivedFrom(rxClass_Ellipse))
                        {
                            //Open the DBobject
                            Ellipse ellipse = (Ellipse)Trans.GetObject(ReadObject, OpenMode.ForRead);

                            //Check the Dbobject belings to a layer we are intersted in
                            if (ellipse.Layer == LayerName)
                            {
                                //Add data to the table 
                                DataConnection.ExcelConnect(ellipse.Handle.Value, ellipse.MinorAxis.X, ellipse.MinorAxis.Y,
                                    ellipse.MajorAxis.X, ellipse.MajorAxis.Y, ellipse.Center.X, ellipse.Center.Y, ellipse.StartAngle, ellipse.EndAngle, ellipse.MajorRadius, ellipse.MinorRadius,
                                    "Ellipse", ellipse.Color.Red, ellipse.Color.Blue, ellipse.Color.Green, LayerName, DocName, double.NaN, ellipse.Linetype,double.NaN);
                            }
                        }
                    }

                }


                

                //Finalise transaction
                Trans.Commit();

            }


        }
    }
}
