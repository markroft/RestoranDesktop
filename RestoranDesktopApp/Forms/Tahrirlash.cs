using Microsoft.EntityFrameworkCore;
using RestoranDesktopApp.MigrationData;
using RestoranDesktopApp.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranDesktopApp.Forms
{
    public partial class Tahrirlash : Form
    {

        public Tahrirlash(Menu ETaom)
        {
            InitializeComponent();

            textBox1.Text = ETaom.nomi;
            textBox2.Text = ETaom.narxi.ToString();
            label6.Text = ETaom.id.ToString();


        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            DBcontext dataAccess = new DBcontext();
            try
            {
                int example = int.Parse(label6.Text);
                var taom = dataAccess.Menu.FirstOrDefault(p => p.id == example);
                taom.nomi = textBox1.Text;
                taom.narxi = int.Parse(textBox2.Text);
                int a = 0;
                if (comboBox1.SelectedItem.ToString() == "TAOM") { a = 1; }
                if (comboBox1.SelectedItem.ToString() == "ICHIMLIK") { a = 2; }
                if (comboBox1.SelectedItem.ToString() == "DESERT") { a = 3; }


                taom.TaomTuri = a;
                dataAccess.SaveChanges();
                MessageBox.Show("QO'SHILDI.");
            }
            catch (Exception)
            {
                MessageBox.Show("Xatolik");
            }
        }



        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
