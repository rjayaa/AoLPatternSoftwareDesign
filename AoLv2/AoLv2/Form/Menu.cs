using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AoLv2.Insertion;
namespace AoLv2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertCustomer customer = new InsertCustomer();
            customer.Show();
            customer.FormClosed += Menu_FormClosed;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            InsertOrderItems customer = new InsertOrderItems();
            customer.Show();
            customer.FormClosed += Menu_FormClosed;
        }
        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertOrders customer = new InsertOrders();
            customer.Show();
            customer.FormClosed += Menu_FormClosed;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertBuku buku = new InsertBuku();
            buku.Show();
            buku.FormClosed += Menu_FormClosed;
        }
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

    }
}
