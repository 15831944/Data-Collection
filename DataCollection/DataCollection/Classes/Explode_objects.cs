//Finds block and explodes them

//using Autodesk.AutoCAD.ApplicationServices;
//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.AutoCAD.Runtime;
//using Autodesk.AutoCAD.EditorInput;
//using System.Collections.Generic;
//using Autodesk.AutoCAD.EditorInput;

//namespace DataCollection.Classes
//{
//    class Explode_Objects
//    {


//        public static void Explode_Blocks()
//        {
//            //Get the current document and databases in those documents
//            Document Doc = Application.DocumentManager.MdiActiveDocument;
//            Database db = Doc.Database;
//            Editor ed = Doc.Editor;

//            using (Transaction Trans = db.TransactionManager.StartTransaction())
//            {

//                //Create the filter and look for blocks (insert)
//                TypedValue[] acTypValAr = new TypedValue[2];
//                acTypValAr.SetValue(new TypedValue((int)DxfCode.Start, "INSERT"), 0);

//                // Assign the filter criteria to a SelectionFilter object
//                SelectionFilter acSelFtr = new SelectionFilter(acTypValAr);

//                // Request for objects to be selected in the drawing area
//                PromptSelectionResult acSSPrompt;
//                acSSPrompt = ed.GetSelection(acSelFtr);

//                // If the prompt status is OK, objects were selected
//                if (acSSPrompt.Status == PromptStatus.OK)
//                {
//                    SelectionSet acSSet = acSSPrompt.Value;
//                    foreach (ObjectId filt in acSSet)
//                    {
//                        //open the block for read
//                        BlockTableRecord CurBlock_r = Trans.GetObject(filt, OpenMode.ForRead) as BlockTableRecord;

//                        //open the block for write
//                        BlockTableRecord CurBlock_w = Trans.GetObject(filt, OpenMode.ForRead) as BlockTableRecord;

//                        //Explode the block
//                        DBObjectCollection acDBObjColl = new DBObjectCollection();
//                        CurBlock_r.Explode(acDBObjColl);

//                        foreach (Entity acEnt in acDBObjColl)
//                        {
//                            // Add the new object to the block table record and the transaction
//                            acBlkTblRec.AppendEntity(acEnt);
//                            acTrans.AddNewlyCreatedDBObject(acEnt, true);
//                        }

//                    }

//                    Application.ShowAlertDialog("Number of objects selected: " +
//                                                acSSet.Count.ToString());
//                }
//                else
//                {
//                    Application.ShowAlertDialog("Number of blocks selected: 0");
//                }
//            }
//        }
//    }
//}
