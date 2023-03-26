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
    public partial class BuyurtmaTaomComponent : UserControl
    {
        public BuyurtmaTaomComponent(Taomlar taom)
        {
            InitializeComponent();

            label1.Text = taom.nomi;
            label2.Text = taom.narxi.ToString();
        }
    }
}
