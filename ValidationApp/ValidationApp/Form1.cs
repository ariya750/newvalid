using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidationApp
{
    public partial class Form1 : Form
    {
        //Global parameters:
        
        public User u1 = new User();
        public static  UserList ul1 = new UserList();
        List<string> lines2 = File.ReadAllLines(@"UserInfo.txt").ToList();//textfile can be found in bin\debug

        public Form1()
        {
           
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (var line in lines2)
            {
                string[] values = line.Split(',');
                u1.Name = values[0];
                u1.Password = values[1];
                //Adding to object list
                UserList.lstUsers.Add(new User(u1.Name, u1.Password));
              
            }
        }

        private void txt_namebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
           
            string enteredName = txt_namebox.Text;
            string enteredPword = txtPwordbox.Text;
            bool valid = false;

            foreach (var user in UserList.lstUsers)
            {
                if (enteredName == user.Name && enteredPword == user.Password)

                {
                    valid = true;
                    break;
                   
                }
               
            }
            if (valid)
            {
                MessageBox.Show("Hi you are validated");
            }
            else 
            {
                MessageBox.Show("Invalid user credentials");

            }

        }

        private void btnview_Click(object sender, EventArgs e)
        {
           txtPwordbox.PasswordChar = char.MinValue;
       
        }
    }
}
