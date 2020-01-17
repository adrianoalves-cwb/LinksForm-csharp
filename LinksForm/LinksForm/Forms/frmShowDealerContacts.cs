using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Links.Model;
using LinksForm.DAL;

namespace Links.Forms
{
    public partial class frmShowDealerContacts : Form
    {
        private DataTable dtDealerContacts = new DataTable();
        private List<DealerContact> dealerContactList = new List<DealerContact>();
        int GlobalDealerId = 0;

        public frmShowDealerContacts(int MainDealerId, string DealerName, string Branch, string CNPJ, string CTDI, int CountryId)
        {
            InitializeComponent();

            dealerContactList = DALHelpers.GetDealerContactByDealerId(MainDealerId);

            dtDealerContacts.Columns.Add("DealerContactId", typeof(string));
            dtDealerContacts.Columns.Add("MainDealerId", typeof(string));
            dtDealerContacts.Columns.Add("Description", typeof(string));
            dtDealerContacts.Columns.Add("Department", typeof(string));
            dtDealerContacts.Columns.Add("Phone", typeof(string));
            dtDealerContacts.Columns.Add("CellPhone", typeof(string));
            dtDealerContacts.Columns.Add("Email", typeof(string));

            if (MainDealerId > 0)
            {
                GlobalDealerId = MainDealerId;
                this.Text = "Dealer Contacts for: " + DealerName;

                if (CountryId == 55)
                {
                    grpDealer.Text = "Branch Specific Details: " + Branch;

                    txtCNPJ.Text = CNPJ;
                    txtCTDI.Text = CTDI;

                    this.Height = 348;
                }

                loadDealerContacts(MainDealerId);
            }
        }

        private void loadDealerContacts(int DealerId)
        {
            var dealerContactList = new List<DealerContact>();

            dealerContactList = DALHelpers.GetDealerContactByDealerId(DealerId);

            dgvDealerContacts.DataSource = null;
            dgvDealerContacts.Rows.Clear();
            dtDealerContacts.Clear();

            foreach (DealerContact dealerContact in dealerContactList)
            {

                //dtDealerContacts.Columns.Add("DealerContactId", typeof(string));
                //dtDealerContacts.Columns.Add("MainDealerId", typeof(string));
                //dtDealerContacts.Columns.Add("Description", typeof(string));
                //dtDealerContacts.Columns.Add("Department", typeof(string));
                //dtDealerContacts.Columns.Add("Phone", typeof(string));
                //dtDealerContacts.Columns.Add("CellPhone", typeof(string));
                //dtDealerContacts.Columns.Add("Email", typeof(string));

                dtDealerContacts.Rows.Add(
                    dealerContact.DealerContactId.ToString(),
                    dealerContact.MainDealerId.ToString(),
                    dealerContact.Description.ToString(),
                    dealerContact.Department.ToString(),
                    dealerContact.Phone.ToString(),
                    dealerContact.CellPhone.ToString(),
                    dealerContact.Email.ToString()
                    );
            }

            dgvDealerContacts.DataSource = dtDealerContacts;

            dgvDealerContacts.Columns[0].Visible = false;
            dgvDealerContacts.Columns[1].Visible = false;

            dgvDealerContacts.Columns[2].Width = 140;
            dgvDealerContacts.Columns[3].Width = 100;
            dgvDealerContacts.Columns[4].Width = 100;
            dgvDealerContacts.Columns[5].Width = 100;
            dgvDealerContacts.Columns[6].Width = 180;

            dgvDealerContacts.Sort(dgvDealerContacts.Columns["Description"], ListSortDirection.Ascending);

            dgvDealerContacts.ClearSelection();
        }
    }
}
