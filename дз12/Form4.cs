using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace дз12
{
    public partial class Form4 : Form
    {
        private List<Tuple<DateTime, double>> _data = new List<Tuple<DateTime, double>>()
        {
            Tuple.Create(new DateTime(2023, 3, 1, 9, 0, 0), 26.2),
            Tuple.Create(new DateTime(2023, 3, 1, 10, 0, 0), 27.5),
            Tuple.Create(new DateTime(2023, 3, 1, 11, 0, 0), 25.3),
            Tuple.Create(new DateTime(2023, 3, 1, 12, 0, 0), 28.6),
            Tuple.Create(new DateTime(2023, 3, 1, 13, 0, 0), 27.8),
            Tuple.Create(new DateTime(2023, 3, 1, 14, 0, 0), 26.9),
            Tuple.Create(new DateTime(2023, 3, 1, 15, 0, 0), 25.7),
        };
       
        public Form4()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Chart chart1 = new Chart();
            chart1.ChartAreas.Add("chartArea1");

            chart1.Series.Add("series1");
            //описує вигляд графіка 
            chart1.Series["series1"].ChartType = SeriesChartType.Column;
            // описує ширину колонок
            chart1.Series["series1"]["PixelPointWidth"] = "20";

            for (int i = 0; i < _data.Count; i++)
            {
                //додає точки до графіка
                chart1.Series["series1"].Points.AddXY(_data[i].Item1, _data[i].Item2);

                if (i > 0 && _data[i].Item2 < _data[i - 1].Item2)
                {
                    //колір точки графіка
                    chart1.Series["series1"].Points[i].Color = Color.Green;
                }
                else
                {
                    chart1.Series["series1"].Points[i].Color = Color.Black;
                }
            }
         
            chart1.Titles.Add("Dolar");

            chart1.Dock = DockStyle.Fill;
            this.Controls.Add(chart1);
        }

        
    }
}
