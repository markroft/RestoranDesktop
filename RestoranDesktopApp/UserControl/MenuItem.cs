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
    public partial class MenuItem : UserControl
    {
        Menu JTaom = new Menu();

        public MenuItem(Menu taom)
        {
            InitializeComponent();

            label2.Text = taom.nomi;
            label3.Text = taom.narxi.ToString();
            label1.Text = taom.id.ToString();
            JTaom = taom;

        }

        public void materialButton1_Click(object sender, EventArgs e)
        {
            BuyurtmaTaomi by = new BuyurtmaTaomi(JTaom);
            var parent = this.ParentForm as userPage;
            parent.taomlarList.Add(JTaom);
            parent.filling();

        }
    }
}
