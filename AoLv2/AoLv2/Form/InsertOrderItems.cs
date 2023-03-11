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
namespace AoLv2.Insertion
{
    public partial class InsertOrderItems : Form
    {
        SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
        DataTable dataTable = new DataTable();
        SqlCommand cmd;
        SqlDataReader dr;
        public InsertOrderItems()
        {
            InitializeComponent();
        }
        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM OrderItems", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }

        public string GenerateID()
        {
            //string connectionString = (@"Data Source=.\SQLEXPRESS;Initial Catalog=tokoBukuu;Integrated Security=True;");
            string query = "SELECT TOP 1 OrderItemID FROM OrderItems ORDER BY OrderItemID DESC";
            string id = "TP";

            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
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
            DataGridDetail.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridDetail.Columns.Add(colBut);

            DataGridDetail.Columns[0].ReadOnly = true;
            DataGridDetail.Columns[1].ReadOnly = true;
            DataGridDetail.Columns[2].ReadOnly = true;
            DataGridDetail.Columns[3].ReadOnly = true;

            // dua kode dibawah ini buat menghapus default column & row di datagrid
            DataGridDetail.AllowUserToAddRows = false;
            DataGridDetail.RowHeadersVisible = false;
            DisableViewAndButton();
            con.Close();
        }
        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO OrderItems VALUES (@OrderItemID, @OrderID, @BookID, @Quantity)", con);
            cmd.Parameters.AddWithValue("@OrderItemID", GenerateID());
            cmd.Parameters.AddWithValue("@OrderID", comboOrder.Text);
            cmd.Parameters.AddWithValue("@BookID", comboBook.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Value);
            


            cmd.ExecuteNonQuery();
            con.Close();
            DataGridDetail.Columns.Clear();
            dataTable.Clear();

            fillData();
        }

        public void DeleteData()
        {
            string t0 = txtOrderDetailID.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM OrderItems WHERE OrderItemID = @t0;";
            cmd.Parameters.AddWithValue("@t0", t0);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridDetail.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void UpdateData()
        {
            con.Open();
            string tid = txtOrderDetailID.Text;
            string t0 = comboOrder.Text;
            string t1 = comboBook.Text;
            decimal t2 = txtQuantity.Value;
            

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE OrderItems SET OrderID = @t0, BookID = @t1, Quantity = @t2  WHERE OrderItemID = @tid;";
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.Parameters.AddWithValue("@t1", t1);
            cmd.Parameters.AddWithValue("@t2", t2);
          

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridDetail.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
            MessageBox.Show("Update Berhasil!!!");
            fixSearchBug();
        }
        public void fixSearchBug()
        {
            txtSearch.Text = "IO002";
            txtSearch.Text = "";
        }
        public void ViewData()
        {
            ButtonUpdateDeleteEnable();
            int selectedIndex = DataGridDetail.CurrentCell.RowIndex;
            txtOrderDetailID.Text = DataGridDetail.Rows[selectedIndex].Cells[0+1].Value.ToString();
            comboOrder.Text = DataGridDetail.Rows[selectedIndex].Cells[1+1].Value.ToString();
            comboBook.Text = DataGridDetail.Rows[selectedIndex].Cells[2+1].Value.ToString();
            txtQuantity.Value = Convert.ToInt32(DataGridDetail.Rows[selectedIndex].Cells[3+1].Value);
        }

        public void DisplayDataSearch()
        {
            con.Open();
            if (comboSearch.Text == "")
            {
                string q = "SELECT OrderItemID, OrderID, BookID, Quantity FROM OrderItems WHERE OrderItemID LIKE '" + txtSearch.Text + "%' OR OrderID LIKE '" + txtSearch.Text + "%' OR BookID LIKE '" + txtSearch.Text + "%' OR Quantity LIKE '" + txtSearch.Text+"%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridDetail.DataSource = st;

            }
            else if (comboSearch.Text == "Order ID")
            {
                string q = "SELECT OrderItemID, OrderID, BookID, Quantity FROM OrderItems WHERE OrderID LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridDetail.DataSource = st;
            }
            else if (comboSearch.Text == "Book ID")
            {
                string q = "SELECT OrderItemID, OrderID, BookID, Quantity FROM OrderItems WHERE BookID LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridDetail.DataSource = st;
            }
            else if (comboSearch.Text == "Quantity")
            {
                string q = "SELECT OrderItemID, OrderID, BookID, Quantity FROM OrderItems WHERE Quantity LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridDetail.DataSource = st;
            }


            con.Close();
        }

        public void fetchDataFromOrderTable()
        {
            string sql = "SELECT * FROM Orders";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboOrder.Items.Add(dr["OrderID"]);
            }
            con.Close();
        }
        public void fetchDataFromBookTable()
        {
            string sql = "SELECT * FROM Books";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBook.Items.Add(dr["BookID"]);
            }
            con.Close();
        }
        public void ClearInsert()
        {
            comboOrder.Text = "";
            comboBook.Text = "";
            txtOrderDetailID.Text = "";
            comboSearch.Text = "";
            txtSearch.Text = "";
            txtQuantity.Value = 0;
        }

        public void ButtonUpdateDeleteEnable()
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnClear.Enabled = true;
        }
        public void DisableViewAndButton()
        {
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void InsertOrderItems_Load(object sender, EventArgs e)
        {
            fetchDataFromOrderTable();
            fetchDataFromBookTable();
            fillData();
            fixSearchBug();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearInsert();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

       

        private void DataGridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DataGridDetail.Columns[e.ColumnIndex].Name != "View" && DataGridDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                ViewData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayDataSearch();
        }
    }
}
