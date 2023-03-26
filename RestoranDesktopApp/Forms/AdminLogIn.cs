using Microsoft.VisualBasic.ApplicationServices;
using RestoranDesktopApp.MigrationData;
using RestoranDesktopApp.Modules;

namespace RestoranDesktopApp
{
    public partial class AdminLogIn : Form
    {
        public AdminLogIn()
        {
            InitializeComponent();
            pictureBox3.Visible= false;
        }



        public void button1_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            DBcontext db = new DBcontext();
            string info1 = userName.Text;
            string info2 = passWord.Text;
            
            var obj1 = db.Users.FirstOrDefault(p => p.login == info1);
            var obj2 = db.Users.FirstOrDefault(p => p.password == info2);


            if (obj1 != null && obj2 != null)
            {

                AdminMainPage adminMainPage = new AdminMainPage(obj2);
                adminMainPage.Show();

                this.Close();

            }
            else
            {
                MessageBox.Show("Username or Password Error");
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            AdminLogIn form1 = new AdminLogIn();
            SignUp form2 = new SignUp();
            form1.Hide(); form2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }
    }
}