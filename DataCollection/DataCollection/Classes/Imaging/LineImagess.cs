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
using System.Threading;

namespace DataCollection.Classes.Imaging
{
    class LineImages
    {
        public static void Initiate(Database db, Editor ed, ObjectId ReadObject, String LayerType, String LayerName)
        {
            using (Transaction Trans = db.TransactionManager.StartTransaction())
            {
                // Open the Layer table for read
                LayerTable acLyrTbl;
                acLyrTbl = Trans.GetObject(db.LayerTableId,
                                                OpenMode.ForRead) as LayerTable;

                //Turn off all layers but the one that is of intrest
                foreach (ObjectId layer in acLyrTbl)
                {
                    //Open the layer fo intrest
                    LayerTableRecord acLyrTblRec = Trans.GetObject(layer,
                        OpenMode.ForRead) as LayerTableRecord;

                    LayerTableRecord acLyrTblRecWrite = Trans.GetObject(layer,
                        OpenMode.ForWrite) as LayerTableRecord;

                    if (acLyrTblRecWrite.Name == LayerName)
                    {
                        // Turn the layer on
                        acLyrTblRecWrite.IsOff = false;
                        //acLyrTblRecWrite.IsFrozen = false;
                    }
                    else
                    {
                        // Turn the layer off
                        acLyrTblRecWrite.IsOff = true;
                        //acLyrTblRecWrite.IsFrozen = true;
                    }
                }

                //Screenshot
                Snapshot.SnapEnds(ed, db, ReadObject, LayerType, 0);

                //Turn on all layers
                foreach (ObjectId layer in acLyrTbl)
                {
                    //Open the layer fo intrest
                    LayerTableRecord acLyrTblRec = Trans.GetObject(layer,
                        OpenMode.ForRead) as LayerTableRecord;

                    LayerTableRecord acLyrTblRecWrite = Trans.GetObject(layer,
                        OpenMode.ForWrite) as LayerTableRecord;

                    //Turn all layers on
                    acLyrTblRecWrite.IsOff = false;
                    //acLyrTblRecWrite.IsFrozen = false;
                }

                //Screenshot with extras
                Snapshot.SnapEnds(ed, db, ReadObject, LayerType, 1);

            }
        }
    }
}
