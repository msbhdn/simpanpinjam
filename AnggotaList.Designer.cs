﻿namespace simpanpinjam
{
    partial class AnggotaList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.tb_nipp = new System.Windows.Forms.TextBox();
            this.tb_jab = new System.Windows.Forms.TextBox();
            this.tb_nama = new System.Windows.Forms.TextBox();
            this.cb_dept = new System.Windows.Forms.ComboBox();
            this.panelFill = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tb_cari = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btn_add);
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(680, 205);
            this.panelTop.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_dept);
            this.groupBox1.Controls.Add(this.tb_jab);
            this.groupBox1.Controls.Add(this.tb_nama);
            this.groupBox1.Controls.Add(this.tb_nipp);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 196);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tambah Anggota";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Unit Kerja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Jabatan :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "NIPP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nama Anggota :";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(372, 56);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "Simpan";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tb_nipp
            // 
            this.tb_nipp.Location = new System.Drawing.Point(106, 23);
            this.tb_nipp.Name = "tb_nipp";
            this.tb_nipp.Size = new System.Drawing.Size(85, 20);
            this.tb_nipp.TabIndex = 1;
            this.tb_nipp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_jab
            // 
            this.tb_jab.Location = new System.Drawing.Point(106, 77);
            this.tb_jab.Name = "tb_jab";
            this.tb_jab.Size = new System.Drawing.Size(218, 20);
            this.tb_jab.TabIndex = 1;
            this.tb_jab.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_nama
            // 
            this.tb_nama.Location = new System.Drawing.Point(106, 50);
            this.tb_nama.Name = "tb_nama";
            this.tb_nama.Size = new System.Drawing.Size(218, 20);
            this.tb_nama.TabIndex = 1;
            this.tb_nama.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cb_dept
            // 
            this.cb_dept.FormattingEnabled = true;
            this.cb_dept.Location = new System.Drawing.Point(106, 105);
            this.cb_dept.Name = "cb_dept";
            this.cb_dept.Size = new System.Drawing.Size(218, 21);
            this.cb_dept.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.BackColor = System.Drawing.Color.White;
            this.panelFill.Controls.Add(this.label5);
            this.panelFill.Controls.Add(this.tb_cari);
            this.panelFill.Controls.Add(this.dataGridView1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 205);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(680, 331);
            this.panelFill.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(680, 299);
            this.dataGridView1.TabIndex = 0;
            // 
            // tb_cari
            // 
            this.tb_cari.Location = new System.Drawing.Point(109, 6);
            this.tb_cari.Name = "tb_cari";
            this.tb_cari.Size = new System.Drawing.Size(218, 20);
            this.tb_cari.TabIndex = 1;
            this.tb_cari.TextChanged += new System.EventHandler(this.tb_cari_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cari Nama :";
            // 
            // AnggotaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(680, 536);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelTop);
            this.Name = "AnggotaList";
            this.Text = "Daftar Anggota";
            this.panelTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox tb_nama;
        private System.Windows.Forms.ComboBox cb_dept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_nipp;
        private System.Windows.Forms.TextBox tb_jab;
        private System.Windows.Forms.TextBox tb_cari;
        private System.Windows.Forms.Label label5;
    }
}