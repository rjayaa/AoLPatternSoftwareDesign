
namespace AoLv2
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPelanggan = new System.Windows.Forms.Button();
            this.btnBuku = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTransaksi = new System.Windows.Forms.Button();
            this.btnDetailTransaksi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPelanggan);
            this.groupBox1.Controls.Add(this.btnBuku);
            this.groupBox1.Location = new System.Drawing.Point(35, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insert Data";
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(161, 30);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(100, 50);
            this.btnPelanggan.TabIndex = 0;
            this.btnPelanggan.Text = "Insert Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // btnBuku
            // 
            this.btnBuku.Location = new System.Drawing.Point(19, 30);
            this.btnBuku.Name = "btnBuku";
            this.btnBuku.Size = new System.Drawing.Size(100, 50);
            this.btnBuku.TabIndex = 0;
            this.btnBuku.Text = "Insert Buku";
            this.btnBuku.UseVisualStyleBackColor = true;
            this.btnBuku.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(35, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 172);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show Data";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(87, 86);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 50);
            this.button5.TabIndex = 0;
            this.button5.Text = "Data Transaksi";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(161, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 50);
            this.button3.TabIndex = 0;
            this.button3.Text = "Data Pelanggan";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(19, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 50);
            this.button4.TabIndex = 0;
            this.button4.Text = "Data Buku";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDetailTransaksi);
            this.groupBox3.Controls.Add(this.btnTransaksi);
            this.groupBox3.Location = new System.Drawing.Point(35, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transaksi";
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(19, 33);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(100, 50);
            this.btnTransaksi.TabIndex = 0;
            this.btnTransaksi.Text = "Insert Transaksi";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // btnDetailTransaksi
            // 
            this.btnDetailTransaksi.Location = new System.Drawing.Point(161, 33);
            this.btnDetailTransaksi.Name = "btnDetailTransaksi";
            this.btnDetailTransaksi.Size = new System.Drawing.Size(100, 50);
            this.btnDetailTransaksi.TabIndex = 1;
            this.btnDetailTransaksi.Text = "Insert Detail Transaksi";
            this.btnDetailTransaksi.UseVisualStyleBackColor = true;
            this.btnDetailTransaksi.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 475);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Menu";
            this.Text = "Main Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPelanggan;
        private System.Windows.Forms.Button btnBuku;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTransaksi;
        private System.Windows.Forms.Button btnDetailTransaksi;
    }
}