using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace simpanpinjam
{

    public partial class sisi : Form
    {
        public sisi()
        {
            InitializeComponent();
            hideSubMenu();

            //label1.Text = global.userid;
        }


        private void hideSubMenu()
        {
            panelAnggotaSubMenu.Visible = false;
            panelTransSubMenu.Visible = false;
            panelRefSubmenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        //MENU BUTTON ANGGOTA
        private void btnAnggota_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAnggotaSubMenu);
        }

        private void btnAnggotaAdd_Click(object sender, EventArgs e)
        {
            openChildForm(new AnggotaAdd());
            hideSubMenu();
        }
        private void btnAnggotaList_Click(object sender, EventArgs e)
        {
            openChildForm(new AnggotaList());
            hideSubMenu();
        }



        //MENU BUTTON TRANSAKSI
        private void btnTrans_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTransSubMenu);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new SimpananAdd());
            hideSubMenu();
        }


        //MENU BUTTON REFERENSI
        private void btnRef_Click(object sender, EventArgs e)
        {
            showSubMenu(panelRefSubmenu);
        }

        private void btnRefDepAdd_Click(object sender, EventArgs e)
        {
            openChildForm(new RefDepAdd());
            hideSubMenu();
        }
        private void btnRefDep_Click(object sender, EventArgs e)
        {
            openChildForm(new RefDep());
            hideSubMenu();
        }
        



        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

    }
}
