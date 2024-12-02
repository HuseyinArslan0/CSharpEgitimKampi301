using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities2 db = new EgitimKampiEfTravelDbEntities2();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();

            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();

            lblGuideCount.Text = db.Guide.Count().ToString();

            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).Value.ToString("F2");

            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price).Value.ToString("F2") + " ₺";

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId)
                .Select(y => y.Country).FirstOrDefault();

            lblCappadociaTourCapacity.Text = db.Location.Where(x => x.City=="Kapadokya")
                .Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkeyCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var romeGuideId = db.Location.Where(x => x.City.Contains("Roma")).Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId)
                .Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity== maxCapacity)
                .Select(y => y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceTour.Text = db.Location.Where(x => x.Price == maxPrice)
                .Select(y => y.City).FirstOrDefault().ToString();

            var guideIdAhmetKaplan = db.Guide.Where(x => x.GuideName=="Ahmet" & x.GuideSurname =="Kaplan").
                Select(y => y.GuideId).FirstOrDefault();
            lblAhmetKaplanTourCount.Text = db.Location.Where(x => x.GuideId==guideIdAhmetKaplan).Count().ToString();
 

        }

    }
}
