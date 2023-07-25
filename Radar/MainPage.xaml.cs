using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows;
using Xamarin.Essentials;
using System.Runtime.InteropServices.ComTypes;

namespace Radar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void loadButton_Clicked(object sender, EventArgs e)
        {
           // String file;
            var file = await FilePicker.PickAsync();
            try
            {


                if (file != null)
                {
                    fileName.Text = file.FileName;
                }
               // var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);

                if (file != null && file.FileName.EndsWith("txt", StringComparison.OrdinalIgnoreCase))
                {
                    var content = System.IO.File.ReadAllText(file.FullPath);
                   // ID.Text = content;
                    List<String> splitString =  new List<string>();
                    splitString = content.Split(new char[] { ',' }).ToList();
                    ID.Text = splitString[0];
                    Time.Text = splitString[1];
                    Azimuth.Text = splitString[2];
                    Elevation.Text = splitString[3];
                }
            }
            catch { 
            
            }
            
        }
    }
}
