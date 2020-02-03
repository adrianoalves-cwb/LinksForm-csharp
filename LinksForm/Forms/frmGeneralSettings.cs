using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            //left = left + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            //GETTING THE TOP MOST SETTINGS AND UPDATING THE CHECK BOX
            getTopMostCheckBoxSettings();

            //GETTING THE WAITFORNETWORK SETTINGS AND UPDATING THE CHECK BOX
            getWaitForNetworkSettings();

            //GETTING THE APPLICATION STARTUP CONFIGURATION
            getStartLinksWhenWindowsIsStarted();
        }

        #region "BUTTONS"

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

            #endregion

            #region "WAIT FOR NETWORK MINUTES"

            if (chkWaitForNetwork.Checked == true)
            {
                Settings.Default["ApplicationWaitForNetworkMinutes"] = cmbWaitForNetwork.Text;
                Settings.Default["ApplicationWaitForNetwork"] = "true";
            }
            else
            {
                Settings.Default["ApplicationWaitForNetworkMinutes"] = "1";
                Settings.Default["ApplicationWaitForNetwork"] = "false";
            }


            #endregion

            #region "WINDOWS STARTUP"

            //GETTING THE APPLICATION PATH FROM THE APPLICATION SETTINGS. 
            string ApplicationPath = Settings.Default["ApplicationPath"].ToString();
            
            //GETTING THE USER THAT IS LOGGED TO THE COMPUTER
            string username = Environment.UserName;

            //CHECKING IF THE APPLICATION CAN ACCESS THE VOLVO SHARED NETWORK FOLDER
            if (Directory.Exists(ApplicationPath))
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (chkStartup.Checked == true)
                    {
                        //CHECKING IF THE FILE ALREADY EXISTS IN THE FOLDER
                        if (File.Exists("C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + "LinksStartup.appref-ms"))
                        {
                            //DELETING THE SHORTCUT FILE
                            File.Delete("C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + "LinksStartup.appref-ms");

                            //COPYING THE SHORTCUT FILE TO THE WINDOWS STARTUP FOLDER
                            File.Copy(ApplicationPath + "LinksStartup.appref-ms",
                            "C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + "LinksStartup.appref-ms");

                        }
                        else
                        {
                            //COPY THE SHORTCUT FILE TO THE WINDOWS STARTUP FOLDER
                            File.Copy(ApplicationPath + "LinksStartup.appref-ms",
                            "C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + "LinksStartup.appref-ms");

                        }

                        Settings.Default["StartLinksWhenWindowsIsStarted"] = "true";
                    }
                    else
                    {

                        //DELETING THE SHORTCUT FILE
                        File.Delete("C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + "LinksStartup.appref-ms");

                        Settings.Default["StartLinksWhenWindowsIsStarted"] = "false";
                    }
                }
                else
                {
                    MessageBox.Show("Error: Unable to get the Windows logged user.", "Links", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Unable to set the configuration. The Volvo Network is unavalable.", "Links", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            #endregion

            //SAVING THE CHANGES MADE BY THE USER
            Settings.Default.Save();

            this.Close();
        }

        #endregion

        #region "METHODS AND FUNCTIONS"

        //GETTING THE TOPMOST SETTINGS AND UPDATING THE CHECKBOX
        private void getTopMostCheckBoxSettings()
        {
            if (Settings.Default["TopMost"].ToString() == "true")
            {
                chkTopMost.Checked = true;
            }else
            {
                chkTopMost.Checked = false;
            }
        }

        private void getWaitForNetworkSettings()
        {
            if (Settings.Default["ApplicationWaitForNetwork"].ToString() == "true")
            {
                cmbWaitForNetwork.Text = Settings.Default["ApplicationWaitForNetworkMinutes"].ToString();
                chkWaitForNetwork.Checked = true;
            }else
            {
                chkWaitForNetwork.Checked = false;
                cmbWaitForNetwork.Text = "1";
            }
            
        }

        private void getStartLinksWhenWindowsIsStarted()
        {
            if (Settings.Default["StartLinksWhenWindowsIsStarted"].ToString() == "true")
            {
                chkStartup.Checked = true;
            }
            else
            {
                chkStartup.Checked = false;
            }
        }
        #endregion

        private void chkWaitForNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWaitForNetwork.Checked == true)
            {
                cmbWaitForNetwork.Enabled = true;
            }
            else
            {
                cmbWaitForNetwork.Enabled = false;
            }
        }
    }
}
