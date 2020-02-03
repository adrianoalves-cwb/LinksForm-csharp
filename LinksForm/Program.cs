using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Links.Properties;

namespace LinksForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            #region "CHECKING IF THERE IS ANOTHER INSTANCE OF THE APPLICATION RUNNING"
            Mutex mutex = new Mutex(false, appGuid);
            if (!mutex.WaitOne(0, false))
            {
                MessageBox.Show("The application is already running!", "Links",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            GC.Collect();
            GC.KeepAlive(mutex);

            #endregion

            #region "CHECKING FOR THE VOLVO NETWORK CONNECTION"

            //THE APPLICATION WILL CHECK FOR THE NETWORK CONNECTION ON THE STARTUP BECAUSE WHEN WORKING FROM HOME, PULSE CAN TAKE A FEW MINUTES TO CONNECT
            //TO AVOID ERRORS, IF THE APPLICATION IS UNABLE TO CONNECT TO THE VOLVO NETWORK IT WILL KEEP CHECKING FOR THE DURATION IN MINUTES THAT WAS SET IN THE GENERAL SETTINGS

            //Getting the application path form the Application Settings
            string ApplicationPath = Settings.Default["ApplicationPath"].ToString();

            bool IsNetworkAvailable = false;

            //Setting for how many minutes the application should check for the network connection. This information is retrieved from the Application Settings
            int waitForNetworkMinutes = Convert.ToInt32(Settings.Default["ApplicationWaitForNetworkMinutes"].ToString());

            //Getting the current DateTime
            DateTime systemDate = DateTime.Now;

            //Add the minutes set in the variable waitForNetworkMinutes
            TimeSpan timeToADD = new TimeSpan(0, 0, waitForNetworkMinutes, 0);

            //Combining the DateTimes
            DateTime timeCombined = systemDate.Add(timeToADD);

            do
            {
                // Checking if the application can access the Volvo shared network folder
                if (Directory.Exists(ApplicationPath))
                {
                    IsNetworkAvailable = true;
                }
                else // The Volvo network folder is unavailable
                {
                    //COMPARING THE CURRENT DATETIME WITH THE TIME SET ABOVE
                    if (DateTime.Now >= timeCombined)
                    {
                        DialogResult dialog = new DialogResult();

                        dialog = MessageBox.Show("The application is unable to load as the VOLVO NETWORK is unavailable. Click 'RETRY' to try to load the application again or click 'CANCEL' to close the application.", "Links - Unable to connect to the Volvo network!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                        if (dialog == DialogResult.Cancel)
                        {
                            //THE USER DECIDED TO END THE APPLICATION
                            Environment.Exit(1);
                        }
                        else
                        {
                            //THE USER DECIDED TO KEEP TRYING TO CONNECT TO THE VOLVO NETWORK
                            //RESETING THE WAITING FOR THE NETWORK MINUTES
                            systemDate = DateTime.Now;
                            timeCombined = systemDate.Add(timeToADD);
                        }
                    }
                }

            } while (IsNetworkAvailable == false);

            #endregion

            if (IsNetworkAvailable == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLinks());
            }
        }

        //Single Instance appGuid
        private static string appGuid = "0de4e393-b58d-4098-9104-bc960cd9e8d9";
    }
}
