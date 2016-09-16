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
    public partial class Help_About : Form
    {
        public Help_About()
        {
            InitializeComponent();
        }

        private void Help_About_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        
        private void Help_About_Load(object sender, EventArgs e)
        {
            String aboutText = ""; //Initialise the text 
            String aboutTitle = ""; //Initialise the title

            aboutTitle = String.Format("{0,90}\n\n", "STAR DUNDEE PACKET RECORDER"); // Gives values to the title
            aboutText = "\nStart of the description";  // Gives value to the bulk of the description


            richTextBoxAbout.Text = aboutTitle + aboutText; // Add the about text to the textbox


        }

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Setting the dialog of the form to ok in order to close it          
        }
    }
}
