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
using System.Text.RegularExpressions;
namespace AoLv2
{
    public partial class _3InsertPelanggan : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tokoBukuu;Integrated Security=True;");
        DataTable dataTable = new DataTable();
        public _3InsertPelanggan()
        {
            InitializeComponent();
        }
        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con))
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
            string query = "SELECT TOP 1 CustomerID FROM Customers ORDER BY CustomerID DESC";
            string id = "PN";

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

        public void fillData()
        {
            DataGridPelanggan.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridPelanggan.Columns.Add(colBut);

            DataGridPelanggan.Columns[0].ReadOnly = true;
            DataGridPelanggan.Columns[1].ReadOnly = true;
            DataGridPelanggan.Columns[2].ReadOnly = true;
            DataGridPelanggan.Columns[3].ReadOnly = true;
            DataGridPelanggan.Columns[4].ReadOnly = true;


            DisableViewAndButton();
            con.Close();
        }

        public void DisableViewAndButton()
        {
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void ButtonUpdateDeleteEnable()
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        public void ClearInsert()
        {
            txtIDPelanggan.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtTelepon.Text = "";
            txtEmail.Text = "";
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES (@CustomerID, @Name, @Address,@Phone, @Email)", con);
            cmd.Parameters.AddWithValue("@ID_Pelanggan", GenerateID());
            cmd.Parameters.AddWithValue("@Name", txtNama.Text);
            cmd.Parameters.AddWithValue("@Address", txtAlamat.Text);
            cmd.Parameters.AddWithValue("@Phone", txtTelepon.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
           

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridPelanggan.Columns.Clear();
            dataTable.Clear();

            fillData();
        }

        public void DeleteData()
        {
            string t0 = txtIDPelanggan.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Customers WHERE CustomerID = @t0;";
            cmd.Parameters.AddWithValue("@t0", t0);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridPelanggan.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void UpdateData()
        {
            con.Open();
            string tid = txtIDPelanggan.Text;
            string t0 = txtNama.Text;
            string t1 = txtAlamat.Text;
            string t2 = txtTelepon.Text;
            string t3 = txtEmail.Text;
            

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Customer SET Name = @t0, Address = @t1, Phone = @t2, Email = @t3 WHERE ID_Pelanggan = @tid;";
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.Parameters.AddWithValue("@t1", t1);
            cmd.Parameters.AddWithValue("@t2", t2);
            cmd.Parameters.AddWithValue("@t3", t3);
            

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridPelanggan.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
            MessageBox.Show("Update Pelanggan Berhasil!!!");

        }

        public void DisplayDataSearch()
        {

            
            con.Open();
            if (comboBox.Text == "")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email FROM Pelanggan WHERE CustomerID LIKE '" + txtSearch.Text + "%' OR Name LIKE '" + txtSearch.Text + "%' OR Address LIKE '" + txtSearch.Text + "%' OR Email LIKE '" + txtSearch.Text + "%' OR Phone LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;

            }
            else if (comboBox.Text == "Customer ID")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email FROM Pelanggan WHERE CustomerID LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            else if (comboBox.Text == "Name")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email  FROM Pelanggan WHERE Name LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            else if (comboBox.Text == "Address")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email  FROM Pelanggan WHERE Address LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            else if (comboBox.Text == "Phone")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email  FROM Pelanggan WHERE Phone LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            else if (comboBox.Text == "Email")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email  FROM Pelanggan WHERE Email LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            con.Close();
        }

        public void ViewData()
        {
                ButtonUpdateDeleteEnable();
                int selectedIndex = DataGridPelanggan.CurrentCell.RowIndex;
                txtIDPelanggan.Text = DataGridPelanggan.Rows[selectedIndex].Cells[0].Value.ToString();
                txtNama.Text = DataGridPelanggan.Rows[selectedIndex].Cells[1].Value.ToString();
                txtAlamat.Text = DataGridPelanggan.Rows[selectedIndex].Cells[2].Value.ToString();
                txtTelepon.Text = DataGridPelanggan.Rows[selectedIndex].Cells[3].Value.ToString();
                txtEmail.Text = DataGridPelanggan.Rows[selectedIndex].Cells[4].Value.ToString();
           
        }

        public void ViewDataWhileSearching()
        {
                ButtonUpdateDeleteEnable();
                int selectedIndex = DataGridPelanggan.CurrentCell.RowIndex;
                txtIDPelanggan.Text = DataGridPelanggan.Rows[selectedIndex].Cells[0+1].Value.ToString();
                txtNama.Text = DataGridPelanggan.Rows[selectedIndex].Cells[1 + 1].Value.ToString();
                txtAlamat.Text = DataGridPelanggan.Rows[selectedIndex].Cells[2 + 1].Value.ToString();
                txtTelepon.Text = DataGridPelanggan.Rows[selectedIndex].Cells[3 + 1].Value.ToString();
                txtEmail.Text = DataGridPelanggan.Rows[selectedIndex].Cells[4 + 1].Value.ToString();

        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            // Regular expression untuk validasi email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Cek apakah nilai textbox sesuai dengan regular expression
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Input harus berupa email yang valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                e.Cancel = true;
            }
        }

        private void _3InsertPelanggan_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearInsert(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData(); 
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
               
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                btnClear.Enabled = false;
            }
            else
            {
                btnClear.Enabled = true;
            }
        }

        private void DataGridPelanggan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                ViewData();
            }
        }

        private void DataGridPelanggan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewDataWhileSearching();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayDataSearch();
        }
    }

}
