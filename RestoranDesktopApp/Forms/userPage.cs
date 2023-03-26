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

namespace RestoranDesktopApp
{
    public partial class userPage : Form
    {
      public  List<Menu> taomlarList = new List<Menu>();

        public userPage()
        {
            InitializeComponent();

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.ItemSize = new Size(0, 1);
            tabControl2.SizeMode = TabSizeMode.Fixed;
            TaomlarFilling();
            
        }

        public void TaomlarFilling()
        {
            DBcontext dataAccess = new DBcontext();

            var Lmenu = dataAccess.Menu.Where(p => p.TaomTuri == 1).ToList();

            for (int i = 0; i < Lmenu.Count; i++)
            {
                MenuItem item = new MenuItem(Lmenu[i]);
                item.Dock = DockStyle.Fill;
                tableLayoutPanel3.Controls.Add(item);

            }
        }

        public void IchimliklarFilling()
        {
            tableLayoutPanel10.Controls.Clear();
            DBcontext dataAccess = new DBcontext();

            var Lmenu = dataAccess.Menu.Where(p => p.TaomTuri == 2).ToList();

            for (int i = 0; i < Lmenu.Count; i++)
            {
                MenuItem item = new MenuItem(Lmenu[i]);
                item.Dock = DockStyle.Fill;
                tableLayoutPanel10.Controls.Add(item);

            }
        }

        public void DesertFilling()
        {
            DBcontext dataAccess = new DBcontext();
            tableLayoutPanel11.Controls.Clear();
            var Lmenu = dataAccess.Menu.Where(p => p.TaomTuri == 3).ToList();

            for (int i = 0; i < Lmenu.Count; i++)
            {
                MenuItem item = new MenuItem(Lmenu[i]);
                item.Dock = DockStyle.Fill;
                tableLayoutPanel11.Controls.Add(item);

            }
        }

        public void filling()
        {
            tableLayoutPanel9.Controls.Clear();
            foreach (var a in taomlarList)
            {
                BuyurtmaTaomi component = new BuyurtmaTaomi(a);
                component.Dock = DockStyle.Fill;
                tableLayoutPanel9.Controls.Add(component);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            filling();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(98, 111, 162);
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkBlue;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[0];

        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(98, 111, 162);

        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkBlue;


        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {

            button4.BackColor = Color.FromArgb(98, 111, 162);

        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkBlue;

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            DBcontext dataAccess = new DBcontext();

            Buyurtmalar buyurtma = new Buyurtmalar();
           // List<string> nomlar = new List<string>();

            { int  umumiySumma = 0;

                foreach( var t in taomlarList)
                {
                    umumiySumma += t.narxi;
                   
                }
                
                buyurtma.usum = umumiySumma;

                buyurtma.vaqti = DateTime.Now.ToString();

                foreach (var item in taomlarList)
                {
                    Taomlar taom = new Taomlar();

                    taom.narxi = item.narxi;
                    taom.nomi = item.nomi;

                    buyurtma.Btaomlar.Add(taom);
                    
                }
               
                           
            }
            
            dataAccess.Buyurtmalar.Add(buyurtma);
            dataAccess.SaveChanges();
            MessageBox.Show($"Buyurtma Saqlandi \nBuyurtma ID: {buyurtma.id}\n Buyurtma summasi {buyurtma.usum}\n Buyurtma Vaqti {buyurtma.vaqti}");
            taomlarList.Clear();
            filling();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[1];
            IchimliklarFilling();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[2];
            DesertFilling();

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {

            int a = int.Parse(textBox1.Text);
            
            DBcontext dataAccess = new DBcontext();

            var buyurtma = dataAccess.Buyurtmalar.Include(p=>p.Btaomlar).FirstOrDefault(p => p.id == a);
            tableLayoutPanel19.Controls.Clear();
            foreach(var t in buyurtma.Btaomlar)
            {

                var comp = new BuyurtmaTaomComponent(t);

                tableLayoutPanel19.Controls.Add(comp);
            }
            label5.Text = buyurtma.vaqti.ToString();
            label8.Text = buyurtma.usum.ToString();
        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userPage_Load(object sender, EventArgs e)
        {

        }
    }
}
