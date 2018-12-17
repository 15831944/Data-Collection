//Count the files in the folder needed and returns a path to store the image

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace DataCollection.Classes.Data
{
    class ImageCount
    {
        public static int ImageSum(String LayerType)
        {
            String path;

            int fileCount;

            switch (LayerType)
            {
                case "Water":

                    //Set the path
                    path = @"C:\ELEC Project\Water\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Water points":

                    path = @"C:\ELEC Project\Water points\";

                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Water object":

                    path = @"C:\ELEC Project\Water object\";

                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Sewer":

                    //Set the path
                    path = @"C:\ELEC Project\Sewer\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Sewer points":

                    path = @"C:\ELEC Project\Sewer points\";

                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Sewer object":

                    path = @"C:\ELEC Project\Sewer object\";

                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Drain":

                    //Set the path
                    path = @"C:\ELEC Project\Drain\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Drain points":

                    path = @"C:\ELEC Project\Drain points\";

                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Drain object":

                    path = @"C:\ELEC Project\Drain object\";

                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Bkerb":

                    //Set the path
                    path = @"C:\ELEC Project\Bkerb\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Ikerb":

                    //Set the path
                    path = @"C:\ELEC Project\Ikerb\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Pboundary":

                    //Set the path
                    path = @"C:\ELEC Project\Pboundary\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Sboundary":

                    //Set the path
                    path = @"C:\ELEC Project\Sboundary\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "Hydrant":

                    //Set the path
                    path = @"C:\ELEC Project\Hydrant\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "HVpole":

                    //Set the path
                    path = @"C:\ELEC Project\HVpole\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                case "PboundaryIntrest":

                    //Set the path
                    path = @"C:\ELEC Project\PboundaryIntrest\";

                    // Will Retrieve count of all files in directry and sub directries
                    fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                    break;

                default:
                    fileCount = -1;
                    break;

            }

            return (fileCount+1);
        }
    }
}
