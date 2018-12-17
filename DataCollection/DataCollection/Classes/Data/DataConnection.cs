//Makes a data connection to Excel to store data on the next empty row

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;

using XL=Microsoft.Office.Interop.Excel;

namespace DataCollection.Classes.Data
{
    class DataConnection
    {
        public static void ExcelConnect(float Handle, Double Xstart, Double Xfinish, Double Ystart, Double Yfinish,
            Double Xcenter, Double Ycenter, Double startAngle, Double endAngle,
            Double Radius, Double Angle, String Shape, int RColour, int BColour, int GColour,
            String LayerName, String DrawingName, Double lineThickness, String lineType, Double lineLength)
        { 
            XL.Application EApp = new XL.Application();
            XL.Workbook EWorkbook = EApp.Workbooks.Open(@"C:\ELEC Project\CivilData.xlsx");
            XL.Worksheet CivilData = EWorkbook.Sheets["CivilData"];

            //Find Next blank row
            var LastRow = CivilData.Range["A1"].End[XL.XlDirection.xlDown].Row;
            var NewRow = LastRow + 1;
            if (LastRow < 1048100)
            {
                //Add data to the row under each column
                CivilData.Range["A" + NewRow].Value = Handle;

                CivilData.Range["B" + NewRow].Value = Xstart;

                CivilData.Range["C" + NewRow].Value = Xfinish;

                CivilData.Range["D" + NewRow].Value = Ystart;

                CivilData.Range["E" + NewRow].Value = Yfinish;

                CivilData.Range["F" + NewRow].Value = Xcenter;

                CivilData.Range["G" + NewRow].Value = Ycenter;

                CivilData.Range["H" + NewRow].Value = startAngle; 

                CivilData.Range["I" + NewRow].Value = endAngle;

                CivilData.Range["J" + NewRow].Value = Radius;

                CivilData.Range["K" + NewRow].Value = Angle;

                CivilData.Range["L" + NewRow].Value = Shape;

                CivilData.Range["M" + NewRow].Value = RColour;

                CivilData.Range["N" + NewRow].Value = BColour;

                CivilData.Range["O" + NewRow].Value = GColour;

                CivilData.Range["P" + NewRow].Value = LayerName;

                CivilData.Range["Q" + NewRow].Value = DrawingName;

                CivilData.Range["R" + NewRow].Value = lineThickness;

                CivilData.Range["S" + NewRow].Value = lineType;

                CivilData.Range["T" + NewRow].Value = lineLength;

                EWorkbook.Save();
            }
            else
            {
                Application.ShowAlertDialog("\nSheet out of rows ");
            }
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //Stop popup
            EApp.DisplayAlerts = false;
            //Save workbook
            EWorkbook.Save();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            System.Runtime.InteropServices.Marshal.ReleaseComObject(CivilData);

            //close and release
            EWorkbook.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(EWorkbook);

            //quit and release
            EApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(EApp);
        }
    }
}
