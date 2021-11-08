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
    public partial class BooksUserControl : UserControl
    {
        Book books;

        public event Action<Book> BookSave;
        public BooksUserControl()
        {
            InitializeComponent();
        }

        private void BooksUserControl_Load(object sender, EventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Library.Books.Add(new Book { Name = textBox1.Text, NumberOfCopies = short.Parse(textBox2.Text) });
            BookSave(books);
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Library.IfBookBorrowingUpSixMonths(int.Parse(textBox3.Text)))
                label6.Text = "Borrowing Out Of Range !!!!!";
            else
                label6.Text = "In Range";
        }
    }
}
