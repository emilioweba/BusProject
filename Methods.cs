using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Application
{
    static class Methods
    {
        public static string getBusDescription(KmlFile kml)
        {
            string name = "";

            foreach (var item in kml.Root.Flatten().OfType<Document>())
            {
                name = item.Name;
            }

            return name;
        }

        public static DbGeography ConvertLatLonToDbGeography(double longitude, double latitude)
        {
            var point = string.Format("POINT({1} {0})", latitude, longitude);
            return DbGeography.FromText(point);
        }

        public static KmlFile OpenFile(string filename, Label lblMessage)
        {
            KmlFile file;
            try
            {
                using (FileStream stream = File.Open(filename, FileMode.Open))
                {
                    file = KmlFile.Load(stream);
                }
            }
            catch (Exception ex)
            {
                Methods.DisplayMessage(lblMessage, ex.GetType() + "\n" + ex.Message, Color.Red);
                return null;
            }

            if (file.Root == null)
            {
                Methods.DisplayMessage(lblMessage, "Unable to find any recognized Kml in the specified file.", Color.Red);
                return null;
            }
            return file;
        }

        public static void DisplayMessage(Label lblMessage, string message, Color color)
        {
            lblMessage.ForeColor = color;
            lblMessage.Text = message;
        }

    }
}
