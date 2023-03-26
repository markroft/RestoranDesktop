using Microsoft.EntityFrameworkCore;
using RestoranDesktopApp.Forms;
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

namespace RestoranDesktopApp
{
    public partial class AdminMenuTaomlar : UserControl
    {
        Menu Dtaom = new Menu();

        public AdminMenuTaomlar(Menu taom)
        {
            InitializeComponent();
            label2.Text = taom.id.ToString();
            label4.Text = taom.nomi;
            label6.Text = taom.narxi.ToString();
            Dtaom = taom;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var parent = this.ParentForm as AdminMainPage;

            DBcontext dataAccess = new DBcontext();

            dataAccess.Menu.Remove(Dtaom);
            dataAccess.SaveChanges();
            MessageBox.Show("Ochirildi");
            parent.TaomFilling();
            parent.IchimlikFilling();
            parent.DesertFilling();

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Tahrirlash tahrirlash = new Tahrirlash(Dtaom);
            tahrirlash.Show();
           // var parent = this.ParentForm as Tahrirlash;
            //int a = parent.TahrirlashFilling(Dtaom);
            


        }
    }
}
