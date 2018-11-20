//This class takes point data and takes six screenshot of the locaion.
//screeshot 1 and 2 -  takes a point screenshot with and without other layers
//screeshot 3 and 4 -  takes a zoomed full object screenshot with and without other layers
//screeshot 5 and 6 -  takes a full screen shot of all objects on layer with and without other layers. only done once per layer,
//so first layer object is the only object layer screenshotted for SS5


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

//autocad assemblies
using acApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;

//Imaging
using System.Drawing.Imaging;
using System.Drawing;

namespace DataCollection
{
    class Screenshot
    {
        //public static void Focus(Double Handle, Double Xstart, Double Xend, Double Ystart, Double Yend, Double Radius, String Type, string Layer,string DocName)
        public static void Focus()
        {
            //ScreenShotToFile(acApp.Application.MainWindow, "c:\\main-window.png", 0, 0, 0, 0);

            Document Doc = Application.DocumentManager.MdiActiveDocument;

            // Works around what looks to be a refresh problem with the Application window
            Doc.Window.WindowState = Window.State.Normal;

            // Get the position of the Document window
            //System.Windows.Point ptDoc = new System.Windows.Point();

            // Get the size of the Document window
            System.Windows.Size szDoc = new System.Windows.Size();

            ScreenShotToFile(acApp.Application.DocumentManager.MdiActiveDocument.Window, "c:\\ELEC Project\\docwindow.bmp",
                (int)(szDoc.Height / 2), (int)(szDoc.Height / 2), (int)(szDoc.Width / 2), (int)(szDoc.Width / 2));
        }

        private static void ScreenShotToFile(Autodesk.AutoCAD.Windows.Window wd, string filename, int top, int bottom, int left, int right)
        {
            //Read the window points

            System.Windows.Point ConvertPT = wd.DeviceIndependentLocation;
            System.Windows.Size ConvertSZ = wd.DeviceIndependentSize;

            System.Drawing.Point pt = new System.Drawing.Point();
            System.Drawing.Size sz = new System.Drawing.Size();

            //check to make sure double is small enough for int and then convert
            if ((int)wd.DeviceIndependentLocation.X < 2147483647)
            {
                pt.X = (int)wd.DeviceIndependentLocation.X;
            }
            else
            {
                Application.ShowAlertDialog("\nScreenshot.cs   Line 53  Double too large for Int ");
                Environment.Exit(0);
            }

            if ((int)wd.DeviceIndependentLocation.Y < 2147483647)
            {
                pt.Y = (int)wd.DeviceIndependentLocation.Y;
            }
            else
            {
                Application.ShowAlertDialog("\nScreenshot.cs   Line 64  Double too large for Int ");
                Environment.Exit(0);
            }
            //Size
            if ((int)wd.DeviceIndependentSize.Width < 2147483647)
            {
                sz.Width = (int)wd.DeviceIndependentSize.Width;
            }
            else
            {
                Application.ShowAlertDialog("\nScreenshot.cs   Line 73  Double too large for Int ");
                Environment.Exit(0);
            }

            if ((int)wd.DeviceIndependentSize.Height < 2147483647)
            {
                sz.Height = (int)wd.DeviceIndependentSize.Height;
            }
            else
            {
                Application.ShowAlertDialog("\nScreenshot.cs   Line 82  Double too large for Int ");
                Environment.Exit(0);
            }


            pt.X += left;
            pt.Y += top;
            sz.Height -= top + bottom;
            sz.Width -= left + right;

            // Set the bitmap object to the size of the screen
            Bitmap bmp = new Bitmap(sz.Width,  sz.Height, PixelFormat.Format32bppArgb);
            using (bmp)
            {
                // Create a graphics object from the bitmap

                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    // Take a screenshot of our window

                    gfx.CopyFromScreen(pt.X, pt.Y, 0, 0, sz, CopyPixelOperation.SourceCopy);

                    // Save the screenshot to the specified location

                    bmp.Save(filename);//, ImageFormat.Bmp

                    bmp.Dispose();
                }
            }
        }
    }
}

