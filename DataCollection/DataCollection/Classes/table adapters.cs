//Goes through each layer passed to the class and sorts out each object on that layer/s.
//It then stores all the layer names for later to find non-indicated layer name.
//Stores all layers in a database using table adapters.

//using Autodesk.AutoCAD.ApplicationServices;
//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.AutoCAD.Runtime;
//using Autodesk.AutoCAD.EditorInput;
//using System.Collections.Generic;

//namespace SPADataCollection
//{
//    class CollectInfo
//    {
//        public static void LayerInfoGrab(List<string> LayName, string LayerType, string DocName)
//        {
//            //link to the current document and databases
//            Document Doc = Application.DocumentManager.MdiActiveDocument;
//            Database db = Doc.Database;
//            Editor ed = Doc.Editor;

//            using (Transaction Trans = db.TransactionManager.StartTransaction())
//            {
//                //Open the block table open for read
//                BlockTable Btr = Trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

//                //Open the model space database for read
//                BlockTableRecord BtrModel = Trans.GetObject(Btr[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;

//                //Step through the objects and find any on the layer we want
//                foreach (object SPAobject in BtrModel)
//                {
//                    //Test the object for block type
//                    if (SPAobject is Line)
//                    {
//                        //Add data to the table
//                        SPADataSet SPADataSet = new SPADataSet();
//                        SPADataSetTableAdapters.SPATableTableAdapter SPATable = new SPADataSetTableAdapters.SPATableTableAdapter();
//                        SPATable.Insert(null, LayName, DocName, "Line", null, null, null, null, null, null, null);
//                    }

//                    if (SPAobject is Circle)
//                    {
//                        //Add data to the table
//                        SPADataSet SPADataSet = new SPADataSet();
//                        SPADataSetTableAdapters.SPATableTableAdapter SPATable = new SPADataSetTableAdapters.SPATableTableAdapter();
//                        SPATable.Insert(, LayName, DocName, "Circle",,,,,,, null);
//                    }

//                    if (SPAobject is Arc)
//                    {
//                        //Add data to the table
//                        SPADataSet SPADataSet = new SPADataSet();
//                        SPADataSetTableAdapters.SPATableTableAdapter SPATable = new SPADataSetTableAdapters.SPATableTableAdapter();
//                        SPATable.Insert(, LayName, DocName, "Arc",,,,,,, null);


//                    }

//                    if (SPAobject is MText)
//                    {
//                        //Add data to the table
//                        SPADataSet SPADataSet = new SPADataSet();
//                        SPADataSetTableAdapters.SPATableTableAdapter SPATable = new SPADataSetTableAdapters.SPATableTableAdapter();
//                        SPATable.Insert(, LayName, DocName, "MText",,,,,,, null);
//                    }

//                    if (SPAobject is Leader)
//                    {
//                        //Add data to the table
//                        SPADataSet SPADataSet = new SPADataSet();
//                        SPADataSetTableAdapters.SPATableTableAdapter SPATable = new SPADataSetTableAdapters.SPATableTableAdapter();
//                        SPATable.Insert(, LayName, DocName, "Leader",,,,,,, null);
//                    }

//                    if (SPAobject is MLeader)
//                    {
//                        //Add data to the table
//                        SPADataSet SPADataSet = new SPADataSet();
//                        SPADataSetTableAdapters.SPATableTableAdapter SPATable = new SPADataSetTableAdapters.SPATableTableAdapter();
//                        SPATable.Insert(, LayName, DocName, "MLeader",,,,,,, null);
//                    }

//                    if (SPAobject is Ellipse)
//                    {
//                        //Add data to the table
//                        SPADataSet SPADataSet = new SPADataSet();
//                        SPADataSetTableAdapters.SPATableTableAdapter SPATable = new SPADataSetTableAdapters.SPATableTableAdapter();
//                        SPATable.Insert(, LayName, DocName,,,,,,,, null);
//                    }
//                }

//                // Create a TypedValue array to define the filter criteria
//                TypedValue[] acTypValAr = new TypedValue[2];
//                acTypValAr.SetValue(new TypedValue((int)DxfCode.Start, "INSERT"), 1);
//                acTypValAr.SetValue(new TypedValue((int)DxfCode.LayerName, LayName), 2);


//                //Finalise transaction
//                Trans.Commit();

//            }


//        }
//    }
//}
