//Not in use only for refrence incase
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataCollection.Classes
//{
//    class Search_code
//    {
//        //Step through the layers and find any objects on the layer we want using a search for blocks and explode them
//                foreach (string LayerName in LayName)
//                {
//                    // Create a TypedValue array to define the filter criteria
//                    TypedValue[] acTypValAr = new TypedValue[2];
//        acTypValAr.SetValue(new TypedValue((int) DxfCode.Start, "INSERT"), 0);
//                    acTypValAr.SetValue(new TypedValue((int) DxfCode.LayerName, LayerName), 1);

//                    // Assign the filter criteria to a SelectionFilter object
//                    SelectionFilter acSelFtr = new SelectionFilter(acTypValAr);

//        // Request for objects to be selected in the drawing area
//        PromptSelectionResult acSSPrompt = ed.GetSelection(acSelFtr);

//    }
//}
//}
