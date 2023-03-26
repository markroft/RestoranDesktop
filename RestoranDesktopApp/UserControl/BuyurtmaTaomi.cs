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
    public partial class BuyurtmaTaomi : UserControl
    {
        public BuyurtmaTaomi(Menu taom)
        {
            InitializeComponent();

            label1.Text = taom.nomi;
            label2.Text = taom.narxi.ToString();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var parent = this.ParentForm as userPage;
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
                var parent = this.ParentForm as userPage;
                string qidiruvTaom = label1.Text;
                var deleteItem = parent.taomlarList.FirstOrDefault(p => p.nomi== qidiruvTaom);
                parent.taomlarList.Remove(deleteItem);
                parent.filling();
        }
    }
}
