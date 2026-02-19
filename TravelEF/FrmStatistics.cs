using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelEF
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblCapacity.Text = db.Location.Sum(x => x.LocationCapasity).ToString();
            lblGuideNum.Text = db.Guide.Count().ToString();
            label6.Text = db.Location.Average(x => x.LocationCapasity).ToString();
            lblAveragePrice.Text = db.Location.Average(x => x.LocationPrice).ToString() + " ₺";
            int LastLocationId = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == LastLocationId).Select(y => y.LocationCountry.ToString()).FirstOrDefault();
            lblBerlinCapasity.Text = db.Location.Where(x => x.LocationCity == "Berlin").Select(y => y.LocationCapasity).FirstOrDefault().ToString();
            
            lblTurkiyeAverageCapasity.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapasity).ToString();
            var NYGuideId = db.Location.Where(x => x.LocationCity == "New York").Select(y => y.GuideId).FirstOrDefault();
            lblNYGuide.Text=db.Guide.Where(x=>x.GuideId == NYGuideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            var maxCapasity = db.Location.Max(x => x.LocationCapasity);
            lblMaxCapasity.Text = db.Location.Where(x => x.LocationCapasity == maxCapasity).Select(y => y.LocationCity + " : "+ y.LocationCapasity).FirstOrDefault().ToString();

            var MaxPrice =db.Location.Max(x=>x.LocationPrice);
            lblMaxPrice.Text = db.Location.Where(x => x.LocationPrice == MaxPrice).Select(y => y.LocationCity + " : " + y.LocationPrice).FirstOrDefault().ToString();

            var GuideaID = db.Guide.Where(x => x.GuideName == "Ahmed Faruk").Select(y=>y.GuideId).FirstOrDefault();
            lblAhmedTourCount.Text=db.Location.Where(x=>x.GuideId ==GuideaID).Count().ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        TravelEFEntities db = new TravelEFEntities();
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
