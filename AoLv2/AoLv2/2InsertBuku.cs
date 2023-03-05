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
    public partial class _2InsertBuku : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tokoBuku;Integrated Security=True;");

        DataTable dataTable = new DataTable();
        public _2InsertBuku()
        {
            InitializeComponent();
        }
        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Buku", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }

        public string GenerateID()
        {
            string connectionString = (@"Data Source=.\SQLEXPRESS;Initial Catalog=tokoBuku;Integrated Security=True;");
            string query = "SELECT TOP 1 ID_Buku FROM Buku ORDER BY ID_Buku DESC";
            string id = "BD";

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
            DataGridBuku.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridBuku.Columns.Add(colBut);

            DataGridBuku.Columns[0].ReadOnly = true;
            DataGridBuku.Columns[1].ReadOnly = true;
            DataGridBuku.Columns[2].ReadOnly = true;
            DataGridBuku.Columns[3].ReadOnly = true;
            DataGridBuku.Columns[4].ReadOnly = true;
            DataGridBuku.Columns[5].ReadOnly = true;


            DisableViewAndButton();
            con.Close();
        }
        public void DisableViewAndButton()
        {
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void ButtonUpdateDeleteEnable() {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        public void ClearInsert()
        {
            txtIDBuku.Text = "";
            txtJudulBuku.Text = "";
            txtPengarang.Text = "";
            txtPenerbit.Text = "";
            txtTahunTerbit.Text = "";
            txtHarga.Value = 0;
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Buku VALUES (@ID_Buku, @Judul, @Pengarang, @Penerbit, @TahunTerbit, @Harga)", con);
            cmd.Parameters.AddWithValue("@ID_Buku", GenerateID());
            cmd.Parameters.AddWithValue("@Judul", txtJudulBuku.Text);
            cmd.Parameters.AddWithValue("@Pengarang", txtPengarang.Text);
            cmd.Parameters.AddWithValue("@Penerbit", txtPenerbit.Text);
            cmd.Parameters.AddWithValue("@TahunTerbit", txtTahunTerbit.Text);
            cmd.Parameters.AddWithValue("@Harga", (int)txtHarga.Value);

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridBuku.Columns.Clear();
            dataTable.Clear();

            fillData();

        }
        public void DeleteData()
        {
            string t0 = txtIDBuku.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Buku WHERE ID_Buku = @t0;";
            cmd.Parameters.AddWithValue("@t0", t0);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridBuku.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void UpdateData()
        {
            con.Open();
            string tid = txtIDBuku.Text;
            string t0 = txtJudulBuku.Text;
            string t1 = txtPengarang.Text;
            string t2 = txtPenerbit.Text;
            string t3 = txtTahunTerbit.Text;
            decimal t4 = txtHarga.Value;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Buku SET Judul = @t0, Pengarang = @t1, Penerbit = @t2, TahunTerbit = @t3, Harga = @t4  WHERE ID_Buku = @tid;";
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.Parameters.AddWithValue("@t1", t1);
            cmd.Parameters.AddWithValue("@t2", t2);
            cmd.Parameters.AddWithValue("@t3", t3);
            cmd.Parameters.AddWithValue("@t4", t4);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridBuku.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
            MessageBox.Show("Update Buku Berhasil!!!");

        }

       public void DisplayDataSearch()
        {
            con.Open();
            if(comboBox.Text == "")
            {
                string q = "SELECT ID_Buku, Judul, Pengarang, Penerbit, TahunTerbit, Harga FROM Buku WHERE ID_Buku LIKE '" + txtSearch.Text + "%' OR Judul LIKE '" + txtSearch.Text + "%' OR Pengarang LIKE '" + txtSearch.Text + "%' OR Penerbit LIKE '" + txtSearch.Text + "%' OR TahunTerbit LIKE '" + txtSearch.Text + "%' OR Harga LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;

            }
            else if(comboBox.Text == "ID Buku")
            {
                string q = "SELECT ID_Buku, Judul, Pengarang, Penerbit, TahunTerbit, Harga FROM Buku WHERE ID_Buku LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }else if (comboBox.Text == "Judul Buku") 
            {
                string q = "SELECT ID_Buku, Judul, Pengarang, Penerbit, TahunTerbit, Harga FROM Buku WHERE Judul LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Pengarang Buku")
            {
                string q = "SELECT ID_Buku, Judul, Pengarang, Penerbit, TahunTerbit, Harga FROM Buku WHERE Pengarang LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Penerbit Buku")
            {
                string q = "SELECT ID_Buku, Judul, Pengarang, Penerbit, TahunTerbit, Harga FROM Buku WHERE Penerbit LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Tahun Terbit")
            {
                string q = "SELECT ID_Buku, Judul, Pengarang, Penerbit, TahunTerbit, Harga FROM Buku WHERE TahunTerbit LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Harga Buku")
            {
                string q = "SELECT ID_Buku, Judul, Pengarang, Penerbit, TahunTerbit, Harga FROM Buku WHERE Harga LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            con.Close();
        }
        public void ViewData()
        {
            ButtonUpdateDeleteEnable();
          
                int selectedIndex = DataGridBuku.CurrentCell.RowIndex;
                txtIDBuku.Text = DataGridBuku.Rows[selectedIndex].Cells[0].Value.ToString();
                txtJudulBuku.Text = DataGridBuku.Rows[selectedIndex].Cells[1].Value.ToString();
                txtPengarang.Text = DataGridBuku.Rows[selectedIndex].Cells[2].Value.ToString();
                txtPenerbit.Text = DataGridBuku.Rows[selectedIndex].Cells[3].Value.ToString();
                txtTahunTerbit.Text = DataGridBuku.Rows[selectedIndex].Cells[4].Value.ToString();
                txtHarga.Value = Convert.ToDecimal(DataGridBuku.Rows[selectedIndex].Cells[5].Value); 
           
        }

        public void ViewDataWhileSearching()
        {
                int selectedIndex = DataGridBuku.CurrentCell.RowIndex;
                txtIDBuku.Text = DataGridBuku.Rows[selectedIndex].Cells[0+1].Value.ToString();
                txtJudulBuku.Text = DataGridBuku.Rows[selectedIndex].Cells[1 + 1].Value.ToString();
                txtPengarang.Text = DataGridBuku.Rows[selectedIndex].Cells[2 + 1].Value.ToString();
                txtPenerbit.Text = DataGridBuku.Rows[selectedIndex].Cells[3 + 1].Value.ToString();
                txtTahunTerbit.Text = DataGridBuku.Rows[selectedIndex].Cells[4 + 1].Value.ToString();

                // i dont know how tf this code works
                string hargaStr = DataGridBuku.Rows[selectedIndex].Cells[5 + 1].Value.ToString();
                decimal harga;
                if (!string.IsNullOrEmpty(hargaStr) && decimal.TryParse(hargaStr, out harga))
                 {
                     txtHarga.Value = harga;
                 }
        }



        // validasi buat textbox hanya menerima tahun
        private void txtTahunTerbit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan angka dan tombol khusus
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTahunTerbit_Leave(object sender, EventArgs e)
        {
            
            // Pastikan bahwa tahun yang dimasukkan memiliki panjang 4 digit
            if (txtTahunTerbit.Text.Length != 4)
            {
                MessageBox.Show("Tahun harus memiliki panjang 4 digit.");
                txtTahunTerbit.Focus();
            }
        }

       

        private void _2InsertBuku_Load(object sender, EventArgs e)
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

        private void txtJudulBuku_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJudulBuku.Text))
            {
                btnClear.Enabled = false;
            }
            else
            {
                btnClear.Enabled = true;
            }
        }

        private void DataGridBuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                ViewData();
            }
        }
        private void DataGridBuku_CellClick(object sender, DataGridViewCellEventArgs e)
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
