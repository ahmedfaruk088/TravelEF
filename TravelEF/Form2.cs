using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelEF
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        TravelEFEntities db = new TravelEFEntities();
        private void Form2_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.LocationCity =txtCity.Text;
            location.LocationCountry =txtCountry.Text;
            location.LocationPrice = decimal.Parse(txtPrice.Text);
            location.LocationCapasity= byte.Parse(nudCapacity.Value.ToString()) ;
            location.DayNight= txtDayNight.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deleteValues = db.Location.Find(id);
            db.Location.Remove(deleteValues);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValues = db.Location.Find(id);
            updateValues.LocationCity = txtCity.Text;
            updateValues.LocationCountry = txtCountry.Text;
            updateValues.LocationPrice = decimal.Parse(txtPrice.Text);
            updateValues.LocationCapasity = byte.Parse(nudCapacity.Value.ToString()) ;
            updateValues.DayNight = txtDayNight.Text;
            updateValues.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges() ;
            MessageBox.Show("Güncelleme işlemi başarılı.");
        }
    }
}
