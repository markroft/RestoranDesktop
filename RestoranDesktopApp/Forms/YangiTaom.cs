using Microsoft.EntityFrameworkCore;
using RestoranDesktopApp.MigrationData;
using RestoranDesktopApp.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranDesktopApp.Forms
{
    public partial class YangiTaom : Form
    {
        public YangiTaom()
        {
            InitializeComponent();


        }

        private void YangiTaomQoshish_Click(object sender, EventArgs e)
        {
            try
            {
                DBcontext dataAccess = new DBcontext();

                Menu taom = new Menu();
                taom.nomi = textBox1.Text;
                taom.narxi = int.Parse(textBox2.Text);
                int a = 0;
                if (comboBox1.SelectedItem.ToString() == "TAOM") { a = 1; }
                if (comboBox1.SelectedItem.ToString() == "ICHIMLIK") { a = 2; }
                if (comboBox1.SelectedItem.ToString() == "DESERT") { a = 3; }


                taom.TaomTuri = a;
                //var parent = this.ParentForm as userPage;
                dataAccess.Menu.Add(taom);
                dataAccess.SaveChanges();
                MessageBox.Show("QO'SHILDI.");
            }
            catch (Exception)
            {
                MessageBox.Show("Xatolik");
            }
           

        }
    }
}
