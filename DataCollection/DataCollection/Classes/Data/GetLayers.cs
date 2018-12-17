using System;
using System.Collections.Generic;
//Gets the selected layer and determins the layer name

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace DataCollection.Classes.Data 
{
    class GetLayers
    {
        public static List<string> GetLayerName()
        {
            //link to the current document and databases
            Document Doc = Application.DocumentManager.MdiActiveDocument;
            Database db = Doc.Database;
            Editor ed = Doc.Editor;
            List<String> LayName = new List<string>();

            using (Transaction Trans = db.TransactionManager.StartTransaction())
            {
                // Request for objects to be selected in the drawing area
                PromptSelectionResult acSSPrompt = Doc.Editor.GetSelection();

                // If the prompt status is OK, objects were selected
                if (acSSPrompt.Status == PromptStatus.OK)
                {
                    SelectionSet acSSet = acSSPrompt.Value;

                    // Step through the objects in the selection set
                    foreach (SelectedObject acSSObj in acSSet)
                    {
                        // Check to make sure a valid SelectedObject object was returned
                        if (acSSObj != null)
                        {
                            // Open the selected object for read
                            Entity acEnt = Trans.GetObject(acSSObj.ObjectId,
                                                                OpenMode.ForRead) as Entity;

                            if (acEnt != null)
                            {
                                // Get the objects handle name
                                long layerHandle = acEnt.LayerId.Handle.Value;

                                //get the layer database
                                LayerTable Lyrtable = Trans.GetObject(db.LayerTableId,
                                    OpenMode.ForRead) as LayerTable;

                                //Roll through the table
                                foreach (ObjectId LayObjID in Lyrtable)
                                {
                                    //If the layer ID is found then stop at that layer

                                    if (layerHandle == LayObjID.Handle.Value)
                                    {
                                        //Read the layers name
                                        LayerTableRecord LyrTblRec = Trans.GetObject(LayObjID, OpenMode.ForRead) as LayerTableRecord;
                                        {
                                            //If Layname array contains the layer name already then dont put it in
                                            if (LayName.Contains(LyrTblRec.Name))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                LayName.Add(LyrTblRec.Name);
                                            }
                                        }
                                    
                                    }
                                }
                            }
                        }
                    }
                }
                Trans.Commit();
            }
            return LayName;

        }
    }
}
