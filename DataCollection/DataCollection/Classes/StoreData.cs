//Goes through each layer passed to the class and sorts out each object on that layer/s.
//It then stores all the layer names for later to find non-indicated layer name.
//Stores all layers in a database using table adapters.

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using System.Collections.Generic;

namespace DataCollection
{
    class CollectInfo
    {
        public static void LayerInfoGrab(IEnumerable<string> LayName, string LayerType, string DocName)
        {
            //link to the current document and databases
            Document Doc = Application.DocumentManager.MdiActiveDocument;
            Database db = Doc.Database;
            Editor ed = Doc.Editor;

            using (Transaction Trans = db.TransactionManager.StartTransaction())
            {
                //Open the block table open for read
                BlockTable Btr = Trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                //Open the model space database for read
                BlockTableRecord BtrModel = Trans.GetObject(Btr[BlockTableRecord.ModelSpace],OpenMode.ForRead) as BlockTableRecord;

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
                                DataCollection.DataConnection.ExcelConnect(line.Handle.Value, line.StartPoint.X, line.EndPoint.X,
                                    line.StartPoint.Y, line.EndPoint.Y,double.NaN,double.NaN,"Line", line.Color.Red, line.Color.Blue,
                                    line.Color.Green, LayerName, line.Layer, DocName);
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
                                //DataCollection.DataConnection.ExcelConnect(circle.Handle.Value, circle.StartPoint.X, circle.EndPoint.X,
                                    //double.NaN, double.NaN, circle.Radius, circle., "Circle", circle.Color.Red, circle.Color.Blue,
                                    //circle.Color.Green, LayerName, circle.Layer, DocName);
                            }

                        }

                        if (ReadObject is Arc)
                        {
                            //Add data to the table
                        }

                        if (ReadObject is Ellipse)
                        {
                            //Add data to the table

                        }
                    }

                }


                

                //Finalise transaction
                Trans.Commit();

            }


        }
    }
}
