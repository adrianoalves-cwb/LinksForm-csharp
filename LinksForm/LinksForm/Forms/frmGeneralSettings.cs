using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Links.Properties;
using LinksForm;

namespace Links.Forms
{
    public partial class frmGeneralSettings : Form
    {
        public frmGeneralSettings(int left, int top, int width, int height)
        {
            InitializeComponent();

            //SETTING THE FORM LOCATION
            left = left + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            //GETTING THE TOP MOST SETTINGS AND UPDATING THE CHECK BOX
            getTopMostCheckBoxSettings();
        }

        //GETTING THE TOPMOST SETTINGS AND UPDATING THE CHECKBOX
        private void getTopMostCheckBoxSettings()
        {

            if (Settings.Default["TopMost"].ToString() == "true")
            {
                chkTopMost.Checked = true;
            }
            else
            {
                chkTopMost.Checked = false;
            }
        }

        private void getWaitForNetworkSettings()
        {
            if (Settings.Default["ApplicationLoadingWaitTime"].ToString() == "true")
            {
                chkTopMost.Checked = true;
            }
            else
            {
                chkTopMost.Checked = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region "TOP MOST"

            //SAVING THE TOPMOST SETTINGS
            if (chkTopMost.Checked == true)
            {
                Settings.Default["TopMost"] = "true";
            }
            else
            {
                Settings.Default["TopMost"] = "false";
            }

            //SAVING THE CHANGES MADE BY THE USER
            Settings.Default.Save();

            #endregion
        }
    }
}
