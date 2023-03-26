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
    public partial class UserComponent : UserControl
    {
        public UserComponent(Users user)
        {
            InitializeComponent();
            label1.Text = user.id.ToString();
            label2.Text = user.UserFirstName;
            label3.Text = user.UserLastName;
            label4.Text = user.RegistrationTime;
        }
    }
}
