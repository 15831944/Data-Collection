//Compiles data from curent drawing and stores in an Excel sheet for using in nueral networks

//          Coded by Daniel Gilliland

//          06/01/2018

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using System.Collections.Generic;

[assembly: CommandClass(typeof(DataCollection.Layers))]

namespace DataCollection
{
   public class Layers
    {
        [CommandMethod("CivilData")]

        public static void Main()
        {
            //Get the current document and databases in those documents
            Document Doc = Application.DocumentManager.MdiActiveDocument;
            Database db = Doc.Database;
            Editor ed = Doc.Editor;

            //Global Vars
            List<string> LayersTotal = new List<string>();

            //Get drawing name
            string DocName = Doc.Name;
            
                        //Get water layer name//
            Application.ShowAlertDialog("\nSelect a water layers: ");
            var LayerName = GetLayers.GetLayerName();

            DataCollection.CollectInfo.LayerInfoGrab(LayerName, "Water", DocName);

            //Add water layers to the overall list
            LayersTotal.AddRange(LayerName);


                        //Get sewer layer name//
            Application.ShowAlertDialog("\nSelect a sewer layers: ");
            LayerName = GetLayers.GetLayerName();

            DataCollection.CollectInfo.LayerInfoGrab(LayerName, "Sewer", DocName);

            //Add sewer layers to the overall list
            LayersTotal.AddRange(LayerName);

                        //Get drain layer name//
            Application.ShowAlertDialog("\nSelect a drain layers: ");
            LayerName = GetLayers.GetLayerName();

            DataCollection.CollectInfo.LayerInfoGrab(LayerName, "Drain", DocName);

            //Add drain layers to the overall list
            LayersTotal.AddRange(LayerName);

                        //Get kerb back layer name//
            Application.ShowAlertDialog("\nSelect a back kerb layers: ");
            LayerName = GetLayers.GetLayerName();

            DataCollection.CollectInfo.LayerInfoGrab(LayerName, "Bkerb", DocName);

            //Add kerbback layers to the overall list
            LayersTotal.AddRange(LayerName);

                        //Get inverted kerb layer name//
            Application.ShowAlertDialog("\nSelect a inverted layers: ");

            LayerName = GetLayers.GetLayerName();

            DataCollection.CollectInfo.LayerInfoGrab(LayerName, "Ikerb", DocName);

            //Add inverted kerb layers to the overall list
            LayersTotal.AddRange(LayerName);

            //Get property boundary layer name//
            Application.ShowAlertDialog("\nSelect a property boundary layers: ");

            LayerName = GetLayers.GetLayerName();

            DataCollection.CollectInfo.LayerInfoGrab(LayerName, "Pboundary", DocName);

            //Add property boundary layers to the overall list
            LayersTotal.AddRange(LayerName);

                        //Get stage boundary layer name//
            Application.ShowAlertDialog("\nSelect a stage boundary layers: ");

            LayerName = GetLayers.GetLayerName();

            DataCollection.CollectInfo.LayerInfoGrab(LayerName, "Sboundary", DocName);

            //Add stage boundary layers to the overall list
            LayersTotal.AddRange(LayerName);

            //Get hydrant layer name//
            Application.ShowAlertDialog("\nSelect a hydrant: ");
            LayerName = GetLayers.GetLayerName();

        }
    }
}
