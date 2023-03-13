using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AoLv2.ConnectionHelper;
using System.Data.SqlClient;
namespace AoLv2
{
    public partial class InsertInvoices : Form
    {
        SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
        DataTable dataTable = new DataTable();
        SqlCommand cmd;
        SqlDataReader dr;
        public InsertInvoices()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Invoices", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }

        public void fillData()
        {
            DataGridInvoices.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridInvoices.Columns.Add(colBut);

            DataGridInvoices.Columns[0].ReadOnly = true;
            DataGridInvoices.Columns[1].ReadOnly = true;
            DataGridInvoices.Columns[2].ReadOnly = true;
            DataGridInvoices.Columns[3].ReadOnly = true;


            // dua kode dibawah ini buat menghapus default column & row di datagrid
            DataGridInvoices.AllowUserToAddRows = false;
            DataGridInvoices.RowHeadersVisible = false;
            DisableViewAndButton();
            con.Close();
            fixSearchBug();
        }

        public void fetchDataOrder()
        {
            string sql = "SELECT * FROM Orders";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboOrderID.Items.Add(dr["OrderID"]);
            }
            con.Close();
        }

        public string GenerateID()
        {
            string prefix = "TRD"; // ganti dengan tiga huruf awalan yang diinginkan
            string query = "SELECT TOP 1 InvoiceID FROM Invoices WHERE LEFT(InvoiceID, 3) = @prefix ORDER BY InvoiceID DESC";
            string id = "";

            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@prefix", prefix);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string lastID = reader.GetString(0);
                    string subString = lastID.Substring(3, 3);
                    int intID = int.Parse(subString) + 1;
                    id = prefix + intID.ToString("D3");
                }
                else
                {
                    id = prefix + "001";
                }

                reader.Close();
            }

            return id;
        }

        public void FillCustomerName(string orderID, TextBox textBox)
        {
            string query = "SELECT C.Name FROM Customers C INNER JOIN Orders O ON C.CustomerID = O.CustomerID WHERE O.OrderID = @orderID";

            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderID", orderID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string customerName = reader.GetString(0);
                    textBox.Text = customerName;
                }
                else
                {
                    textBox.Text = "";
                }

                reader.Close();
            }
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Invoices VALUES (@InvoiceID, @OrderID, @Amount, @IssuedDate)", con);
            cmd.Parameters.AddWithValue("@InvoiceID", txtInvoiceID.Text);
            cmd.Parameters.AddWithValue("@OrderID", comboOrderID.Text);
            int amount = Convert.ToInt32(txtAmount.Text.Replace(",", ""));
            cmd.Parameters.AddWithValue("@Amount", amount);
            DateTime tanggalKeluarBuku = DateTime.Parse(txtInvoiceDate.Text);
            cmd.Parameters.AddWithValue("@IssuedDate", tanggalKeluarBuku);
            

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridInvoices.Columns.Clear();
            dataTable.Clear();

            fillData();
            ClearInsert();
        }

        public void DeleteData()
        {
            string temp = txtInvoiceID.Text;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Invoices WHERE InvoiceID = @t0;";
            cmd.Parameters.AddWithValue("@t0", temp);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridInvoices.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void ViewData()
        {
            ButtonUpdateDeleteEnable();

            int selectedIndex = DataGridInvoices.CurrentCell.RowIndex;

            txtInvoiceID.Text = DataGridInvoices.Rows[selectedIndex].Cells[0].Value.ToString();
            comboOrderID.Text = DataGridInvoices.Rows[selectedIndex].Cells[1].Value.ToString();
            txtAmount.Text = DataGridInvoices.Rows[selectedIndex].Cells[2].Value.ToString();
            DateTime dateValues;
            if (DateTime.TryParse(DataGridInvoices.Rows[selectedIndex].Cells[3].Value.ToString(), out dateValues))
            {
                txtInvoiceDate.Value = dateValues;
            }


        }

        public void CalculateAmount()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                string query = @"SELECT SUM(Books.Price * OrderItems.Quantity) AS TotalAmount 
                         FROM Orders 
                         INNER JOIN OrderItems ON Orders.OrderID = OrderItems.OrderID 
                         INNER JOIN Books ON OrderItems.BookID = Books.BookID 
                         WHERE Orders.OrderID = @OrderID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", comboOrderID.Text);

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    decimal amount = Convert.ToDecimal(result);
                    txtAmount.Text = amount.ToString("N0");
                }
                else
                {
                    txtAmount.Text = "0";
                }
            }
        }

        private void InsertInvoices_Load(object sender, EventArgs e)
        {
            fetchDataOrder();
            txtInvoiceID.Text = GenerateID();
            fillData();
        }

        public void ButtonUpdateDeleteEnable()
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        public void ClearInsert()
        {
            txtInvoiceID.Text = GenerateID();
            comboOrderID.Text = "";
            txtOrder.Text = "";
            txtAmount.Text = "";
            txtInvoiceDate.Value = DateTime.Now;
        }

        public void fixSearchBug()
        {
            txtSearch.Text = "TRD001";
            txtSearch.Text = "";
        }
        public void DisableViewAndButton()
        {
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void comboOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCustomerName(comboOrderID.Text, txtOrder);
            CalculateAmount();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
            txtInvoiceID.Text = GenerateID();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            txtInvoiceID.Text = GenerateID();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
        }


        private void DataGridInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridInvoices.Columns[e.ColumnIndex].Name == "")
            {
                ViewData();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
