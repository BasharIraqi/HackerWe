using HackerWe.Entities;
using HackerWe.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackerWe.UI
{
    public partial class BorrowingUserControl : UserControl
    {
        Borowing borowing;

        public event Action<Borowing> BorrowingSaved;

        public BorrowingUserControl()
        {
            InitializeComponent();
        }

        private void BorrowingUserControl_Load(object sender, EventArgs e)
        {
            Reset();
            dtpBorrowingDate.MaxDate = DateTime.Now.AddDays(2);

            cmbBooks.DataSource = Library.RelevantBooks;
            cmbBooks.DisplayMember = "Name";

            cmbClients.DataSource = Library.Clients;
            cmbClients.DisplayMember = "FullName";
        }

        private void dtpBorrowingDate_ValueChanged(object sender, EventArgs e)
        {
            borowing.BorowingDate = dtpBorrowingDate.Value;
            lblDueReturningdate.Text = borowing.DueReturningDate.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbClients.SelectedItem == null)
            {
                lblClientValidMessage.Text = "This is must";
                return;
            }
            borowing.Client = (Client)cmbClients.SelectedItem;
            borowing.Book = cmbBooks.SelectedItem as Book;

            Library.Borowings.Add(borowing);
            Library.SaveBorrowings();

            //1. Message to the lll
            lblMessages.Text = "Saved sucesseded";

            //2. Reset fields
            Reset();
            //3. Send mail to client
            BorrowingSaved(borowing);
        }

        private void Reset()
        {
            borowing=new Borowing();
            
            lblClientValidMessage.Text = string.Empty;

            dtpBorrowingDate.MinDate = DateTime.Now;
            dtpBorrowingDate.Value = DateTime.Now;
            //foreach (Control ctl in this.Controls)
            //{
            //    if(typeof(ComboBox) == ctl.GetType())
            //        (ctl as ComboBox).SelectedIndex = 0;
            //    ctl.ResetText();
            //}
        }

        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClients.SelectedItem != null)
                lblClientValidMessage.Text = "";
        }

        private void dtpBorrowingDate_Enter(object sender, EventArgs e)
        {
            lblMessages.Text = "";
        }
    }
}
