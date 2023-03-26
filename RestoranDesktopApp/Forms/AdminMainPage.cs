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
using Microsoft.VisualBasic.ApplicationServices;
using RestoranDesktopApp.Forms;
using RestoranDesktopApp.MigrationData;
using RestoranDesktopApp.Modules;

namespace RestoranDesktopApp
{
    public partial class AdminMainPage : Form
    {
        int TaomSahifasi = 1;
        int cpage;
        
        DBcontext dataAccess;

        List<Menu> Tmenu = new List<Menu>();
        public AdminMainPage(Users eUser)
        {
            dataAccess = new DBcontext();
            Tmenu = dataAccess.Menu.ToList();
            InitializeComponent();

            TaomFilling();
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.ItemSize = new Size(0, 1);
            tabControl2.SizeMode = TabSizeMode.Fixed;

            var parent = this.ParentForm as AdminLogIn;


            label5.Text = eUser.id.ToString();
            label12.Text = eUser.UserFirstName;
            label13.Text = eUser.UserLastName;


        }
        public void UsersFilling()
        {

            tableLayoutPanel22.Controls.Clear();

            DBcontext dataAccess = new DBcontext();



            var Tmenu = dataAccess.Users.ToList();

            for (int i = 0; i < Tmenu.Count; i++)
            {
                UserComponent item = new UserComponent(Tmenu[i]);
                item.Dock = DockStyle.Fill;
                tableLayoutPanel22.Controls.Add(item);

            }
        }
        public void TaomFilling()
        {
            Tmenu = Tmenu.Where(p => p.TaomTuri == 1).ToList();
            int a = int.Parse(comboBox1.SelectedItem.ToString());
            int pages = (Tmenu.Count + a - 1) / a;
           

            tableLayoutPanel28.Controls.Clear();
            for (int i = 1; i<= pages; i++)
            {
                Button button = new Button();
                button.Click += Click;
                button.Text = i.ToString();
                button.Dock = DockStyle.Fill;

                tableLayoutPanel28.Controls.Add(button);
            }

            tableLayoutPanel10.Controls.Clear();
            var PageList = Tmenu.Skip((cpage - 1) * a).Take(a).ToList();
            for (int i = 0; i < PageList.Count; i++)
            {
                AdminMenuTaomlar item = new AdminMenuTaomlar(PageList[i]);
                item.Dock = DockStyle.Fill;
                tableLayoutPanel10.Controls.Add(item);

            }
        }
        public void IchimlikFilling()
        {

            tableLayoutPanel12.Controls.Clear();

            DBcontext dataAccess = new DBcontext();

            var Tmenu = dataAccess.Menu.Where(p => p.TaomTuri == 2).ToList();

            for (int i = 0; i < Tmenu.Count; i++)
            {
                AdminMenuTaomlar item = new AdminMenuTaomlar(Tmenu[i]);
                item.Dock = DockStyle.Fill;
                tableLayoutPanel12.Controls.Add(item);

            }
        }

        public void DesertFilling()
        {
            tableLayoutPanel13.Controls.Clear();

            DBcontext dataAccess = new DBcontext();

            var Tmenu = dataAccess.Menu.Where(p => p.TaomTuri == 3).ToList();

            for (int i = 0; i < Tmenu.Count; i++)
            {
                AdminMenuTaomlar item = new AdminMenuTaomlar(Tmenu[i]);
                item.Dock = DockStyle.Fill;
                tableLayoutPanel13.Controls.Add(item);

            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];
            UsersFilling();


        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            DBcontext dataAccess = new DBcontext();
            tabControl1.SelectedTab = tabControl1.TabPages[3];
            int userid = int.Parse(label5.Text);
            var eUser = dataAccess.Users.FirstOrDefault(p => p.id == userid);
            label17.Text = eUser.id.ToString();
            label18.Text = eUser.RegistrationTime;
            textBox1.Text = eUser.UserFirstName;
            textBox2.Text = eUser.UserLastName;
            textBox3.Text = eUser.login.ToString();
            textBox4.Text = eUser.password.ToString();


        }

        private void materialButton6_Click(object sender, EventArgs e)
        {

            tabControl2.SelectedTab = tabControl2.TabPages[0];
            TaomFilling();
            

        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[1];
            IchimlikFilling();



        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[2];
            DesertFilling();


        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            YangiTaom YangiTaom = new YangiTaom();
            YangiTaom.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            DBcontext db = new DBcontext();
            int userID = int.Parse(label5.Text);
            var user = db.Users.FirstOrDefault(p => p.id == userID);
            user.UserFirstName = textBox1.Text;
            user.UserLastName = textBox2.Text;
            user.login = textBox3.Text.ToString();
            user.password = textBox4.Text.ToString();
            db.SaveChanges();
            MessageBox.Show("O'zgarishlar saqlandi");
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            DBcontext db = new DBcontext();

            int userID = int.Parse(label5.Text);
            var eUser = db.Users.FirstOrDefault(x => x.id == userID);
            db.Users.Remove(eUser);
            db.SaveChanges();
            MessageBox.Show("Ushbu Akkaunt O'chirib Yuborildi");
            this.Close();

        }

        private void Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
             cpage = int.Parse(button.Text);
            TaomFilling();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string SearchText = textBox5.Text.ToLower();
            Tmenu = Tmenu.Where(p => p.nomi.ToLower().Contains(SearchText)).ToList();
            TaomFilling();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            TaomFilling();
        }
    }
}
