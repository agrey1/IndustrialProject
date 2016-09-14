using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialProject
{
    public partial class LoadingForm : Form
    {
        public event EventHandler<EventArgs> Canceled;

        public LoadingForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> ea = Canceled;
            if (ea != null)
                ea(this, e);
        }

        public string Message
        {
            set { labelProgress.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar.Value = value; }
        } 
    }
}
