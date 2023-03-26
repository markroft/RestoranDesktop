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
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WelcomePage welcomePage= new WelcomePage();
            AdminLogIn adminPage = new AdminLogIn();
            adminPage.Show();
            welcomePage.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WelcomePage welcomePage= new WelcomePage();
            userPage userPage = new userPage();
            userPage.WindowState = FormWindowState.Maximized;
            userPage.Show();
            welcomePage.Close();
        }
    }
}
