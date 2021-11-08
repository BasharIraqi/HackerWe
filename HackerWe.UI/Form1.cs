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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Timer timer = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 5000;
            timer.Tick += (object o, EventArgs argss) =>
            {
                lblMessages.Text = "";
                timer.Stop();
            };

            Library.ReadBooksFromJSON();
            Library.ReadClientsFromJSON();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            BooksUserControl booksUserControl = new BooksUserControl();

            booksUserControl.BookSave += (Book) =>
              {
                  MessageBox.Show("Book Successfully Saved");

              };
            booksUserControl.Parent = panel1;
            booksUserControl.Show();
            //Library.SaveBooks();
            Library.SaveBooksAsJSON();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BorrowingUserControl borrowingUserControl = new BorrowingUserControl();
            borrowingUserControl.BorrowingSaved += (borrowing) =>
            {
                lblMessages.Text = "Borowing saved successfully " + borrowing.Id;
                timer.Start();
            };
            borrowingUserControl.Parent = panel1;

            borrowingUserControl.Show();
        }
    }
}
