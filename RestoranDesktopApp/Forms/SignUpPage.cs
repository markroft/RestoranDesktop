using Microsoft.EntityFrameworkCore;
using RestoranDesktopApp.MigrationData;
using RestoranDesktopApp.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranDesktopApp
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
       
        private void Register_Click(object sender, EventArgs e)
        {
            DBcontext db = new DBcontext();
            Modules.Users user = new Modules.Users();
            DateTime time = new DateTime();
            user.UserFirstName = name.Text;
            user.UserLastName = lastname.Text;
            user.login = username.Text;
            user.password = password.Text;
            user.RegistrationTime = DateTime.Now.ToString();
            Random r = new Random();
            user.id = r.Next(1, 1000000);
            db.Users.Add(user);
            db.SaveChanges();
            MessageBox.Show("User Successfully Added");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
