using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AoLv2
{
    public partial class _4InsertTransaksi : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tokoBukuu;Integrated Security=True;");

        DataTable dataTable = new DataTable();
        SqlCommand cmd;
        SqlDataReader dr;
        public _4InsertTransaksi()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }

        public string GenerateID()
        {
            string connectionString = (@"Data Source=.\SQLEXPRESS;Initial Catalog=tokoBukuu;Integrated Security=True;");
            string query = "SELECT TOP 1 OrderID FROM Orders ORDER BY OrderID DESC";
            string id = "OD";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string lastID = reader.GetString(0);
                    string subString = lastID.Substring(2, 3);
                    int intID = int.Parse(subString) + 1;
                    id += intID.ToString("D3");
                }
                else
                {
                    id += "001";
                }

                reader.Close();
            }

            return id;
        }
        public void fetchDataCustomer()
        {
            string sql = "SELECT * FROM Customers";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboCustomer.Items.Add(dr["Name"]);
            }
            con.Close();
        }

        public void GetCustomerName(string customerName)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tokoBukuu;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE Name=@customerName", con);
            cmd.Parameters.AddWithValue("@customerName", customerName);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string temp_Id = dr["CustomerID"].ToString();
                txtCustomerID.Text = temp_Id;
            }

            con.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustomerName(comboCustomer.Text);
        }

       

        public void fillData()
        {
            DataGridTransaction.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridTransaction.Columns.Add(colBut);

            DataGridTransaction.Columns[0].ReadOnly = true;
            DataGridTransaction.Columns[1].ReadOnly = true;
            DataGridTransaction.Columns[2].ReadOnly = true;

            con.Close();
        }


        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES (@OrderID, @CustomerID, @OrderDate)", con);
            cmd.Parameters.AddWithValue("@OrderID", GenerateID());
            cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
            DateTime orderDate = DateTime.Parse(DatePicker.Text);
            cmd.Parameters.AddWithValue("@OrderDate", orderDate);


            cmd.ExecuteNonQuery();
            con.Close();
            DataGridTransaction.Columns.Clear();
            dataTable.Clear();

            fillData();
        }

        public void DeleteData()
        {
            string t0 = txtOrderID.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Orders WHERE OrderID = @t0;";
            cmd.Parameters.AddWithValue("@t0", t0);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridTransaction.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }


        public void ClearInsert()
        {
            txtOrderID.Text = "";
            txtCustomerID.Text = "";
            comboCustomer.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        public string GetCustomerID(string id)
        {
            string customerName = "";

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tokoBukuu;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerID=@customerId", con);
            cmd.Parameters.AddWithValue("@customerId", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                customerName = dr["Name"].ToString();
            }

            con.Close();

            return customerName;
        }



        public void ViewData()
        {
            int selectedIndex = DataGridTransaction.CurrentCell.RowIndex;
            txtOrderID.Text = DataGridTransaction.Rows[selectedIndex].Cells[0].Value.ToString();
            txtCustomerID.Text = DataGridTransaction.Rows[selectedIndex].Cells[1].Value.ToString();
            comboCustomer.Text = GetCustomerID(txtCustomerID.Text);
            DatePicker.Value = Convert.ToDateTime(DataGridTransaction.Rows[selectedIndex].Cells[2].Value);
        }

        private void _4InsertTransaksi_Load(object sender, EventArgs e)
        {
            fetchDataCustomer();
            fillData();
        }

        private void DataGridTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                ViewData();
            }
        }

       
    }
}
