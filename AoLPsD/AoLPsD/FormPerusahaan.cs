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
namespace AoLPsD
{
    public partial class FormPerusahaan : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=crudPerusahaan;Integrated Security=True;");
        
        DataTable dataTable = new DataTable();


        public FormPerusahaan()
        {
            InitializeComponent();
        }

        

        public DataTable getDataTable() {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Perusahaan", con)) {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }
           
            return dataTable;
        }
        public string GenerateID()
        {
            string connectionString = "Data Source=RJAYAA\\SQLEXPRESS;Initial Catalog=crudPerusahaan;Integrated Security=True";
            string query = "SELECT TOP 1 ID_Perusahaan FROM Perusahaan ORDER BY ID_Perusahaan DESC";
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
        
        public string LastID()
        {
            con.Open();
            string Query = "SELECT TOP 1 ID_Perusahaan FROM Perusahaan ORDER BY ID_Perusahaan DESC;";
            SqlCommand cmd = new SqlCommand(Query, con);

            string LastID = Convert.ToString(cmd.ExecuteScalar());
            int IntId = 0;

            if (LastID == "") IntId = 1;
            else
            {
                string subString = LastID.Substring(LastID.Length - 4, 4);
                IntId = Convert.ToInt32(subString) + 1;
            }

            con.Close();

            string ID = "TS";

            if (IntId < 10) ID = string.Concat(ID, "000", IntId.ToString());
            else if (IntId < 100 && IntId >= 10) ID = string.Concat(ID, "00", IntId.ToString());
            else if (IntId < 1000 && IntId >= 100) ID = string.Concat(ID, "0", IntId.ToString());
            else ID = string.Concat(ID, IntId.ToString());


            return ID;
        }

        public void fillData() {
            DataGridPerusahaan.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridPerusahaan.Columns.Add(colBut);

            DataGridPerusahaan.Columns[0].ReadOnly = true;
            DataGridPerusahaan.Columns[1].ReadOnly = true;
            DataGridPerusahaan.Columns[2].ReadOnly = true;
            DataGridPerusahaan.Columns[3].ReadOnly = true;
            DataGridPerusahaan.Columns[4].ReadOnly = true;
            DisableViewAndButton();
            con.Close();
        }
        public void InsertData() {

            con.Open();
            
            SqlCommand cmd = new SqlCommand("INSERT INTO Perusahaan VALUES (@ID_Perusahaan,@Nama_Perusahaan,@NPWP_Perusahaan,@Kontak_Perusahaan,@Alamat_Perusahaan)", con);
            cmd.Parameters.AddWithValue("@ID_Perusahaan", GenerateID());
            cmd.Parameters.AddWithValue("@Nama_Perusahaan", txtNamaPerusahaan.Text);
            cmd.Parameters.AddWithValue("@NPWP_Perusahaan", txtNPWP.Text);
            cmd.Parameters.AddWithValue("@Kontak_Perusahaan", txtKontakPerusahaan.Text);
            cmd.Parameters.AddWithValue("@Alamat_Perusahaan", txtAlamatPerusahaan.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridPerusahaan.Columns.Clear();
            dataTable.Clear();
            fillData();
       


        }
        public void DisableViewAndButton(){
            txtViewNama.Enabled     = false;
            txtViewKontak.Enabled   = false;
            txtViewNPWP.Enabled     = false;
            txtViewAlamat.Enabled   = false;
            btnClear.Enabled        = false;
            btnDelete.Enabled       = false;
            btnUpdate.Enabled       = false;
        }
        private void FormPerusahaan_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
        }
    }
}
