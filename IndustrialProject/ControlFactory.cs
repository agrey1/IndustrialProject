using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace IndustrialProject
{
    class ControlFactory
    {
        private TrafficSample sample;

        public ControlFactory(TrafficSample sample)
        {
            this.sample = sample;
        }

        public Label labelFactory(bool AutoSize, Point Location, string Name, Size Size, int TabIndex, string Text)
        {
            Label lbltoreturn = new Label();
            lbltoreturn.AutoSize = AutoSize;
            lbltoreturn.Location = Location;
            lbltoreturn.Name = Name;
            lbltoreturn.Size = Size;
            lbltoreturn.TabIndex = TabIndex;
            lbltoreturn.Text = Text;
            return lbltoreturn;
        }

        public GroupBox groupboxFactory(List<Control> Controls, Point Location, string Name, Size Size, int TabIndex, bool TabStop, string Text)
        {
            GroupBox grpboxtoreturn = new GroupBox();
            Controls.ForEach(ctrl => grpboxtoreturn.Controls.Add(ctrl));
            grpboxtoreturn.Location = Location;
            grpboxtoreturn.Name = Name;
            grpboxtoreturn.Size = Size;
            grpboxtoreturn.TabIndex = TabIndex;
            grpboxtoreturn.TabStop = TabStop;
            grpboxtoreturn.Text = Text;
            return grpboxtoreturn;
        }

        public WebBrowser webbrowserFactory(Point Location, Size MinimumSize, string Name, Size Size, int TabIndex)
        {
            WebBrowser webtoreturn = new WebBrowser();
            webtoreturn.Location = Location;
            webtoreturn.MinimumSize = MinimumSize;
            webtoreturn.Name = Name;
            webtoreturn.Size = Size;
            webtoreturn.TabIndex = TabIndex;
            return webtoreturn;
        }

        public Chart chartFactory(ChartArea ChartArea, string ChartAreaName, Legend Legend, string LegendName, Point Location, string Name, Series Series, string SeriesName, Size Size, int TabIndex, string Text)
        {
            Chart charttoreturn = new Chart();
            //Set everything we need to set
            ChartArea.Name = ChartAreaName;
            charttoreturn.ChartAreas.Add(ChartArea);
            Legend.Name = LegendName;
            charttoreturn.Legends.Add(Legend);
            charttoreturn.Location = Location;
            charttoreturn.Name = Name;
            Series.ChartArea = ChartAreaName;
            Series.Legend = LegendName;
            Series.Name = SeriesName;
            charttoreturn.Series.Add(Series);
            charttoreturn.Size = Size;
            charttoreturn.TabIndex = 9;
            charttoreturn.Text = Text;
            //Return the chart
            return charttoreturn;
        }

        public ListView listviewFactory(Point Location, string Name, Size Size, int TabIndex, bool UseCompatibleStageImageBehaviour)
        {
            ListView listviewtoreturn = new ListView();
            //Set everything
            listviewtoreturn.Location = Location;
            listviewtoreturn.Name = Name;
            listviewtoreturn.Size = Size;
            listviewtoreturn.TabIndex = TabIndex;
            listviewtoreturn.UseCompatibleStateImageBehavior = UseCompatibleStageImageBehaviour;
            //Return the object
            return listviewtoreturn;
        }

        public RichTextBox richtextboxFactory(Point Location, string Name, Size Size, int TabIndex, string Text)
        {
            RichTextBox txtboxtoreturn = new RichTextBox();
            //Set everything
            txtboxtoreturn.Location = Location;
            txtboxtoreturn.Name = Name;
            txtboxtoreturn.Size = Size;
            txtboxtoreturn.TabIndex = TabIndex;
            txtboxtoreturn.Text = Text;
            //Return the object
            return txtboxtoreturn;
        }
    }
}
