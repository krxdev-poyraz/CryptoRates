using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChangeRates
{

    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            int idNumbers = 0;            
            int max = 5000;
            string stringMax = Convert.ToString(max);
            string fullInfo = "https://web-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?start=1&limit=" + stringMax + "&sort=market_cap&sort_dir=desc&convert=USD&cryptocurrency_type=all&aux=circulating_supply,max_supply,total_supply";
            string fullInfoJson = new WebClient().DownloadString(fullInfo);
            dynamic stuff = JObject.Parse(fullInfoJson);
            int maxMoney = stuff.data.Count;
            try
            {
                File.Delete("id.txt");
            }
            catch
            {

            }
            
            StreamWriter sw = new StreamWriter("id.txt");
            while (idNumbers < maxMoney)
            {                
                sw.WriteLine(stuff.data[idNumbers].id);
                Console.WriteLine(stuff.data[idNumbers].id);
                idNumbers++;                
            }
            sw.Close();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

          
    }
}
