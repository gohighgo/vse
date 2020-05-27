using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vce
{
    public partial class LoginOrSignUpForm : Form
    {
        public LoginOrSignUpForm()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1}" + "User ID={2}; Password={3};Database={4};", "localhost", "5432", "postgres", "qwerty1324vcxz", "Demo");
        private DataTable dt;
        private NpgsqlCommand cmd;
        private string sql = null;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from u_login(_username, _password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_username", textBoxUserName.Text);
                cmd.Parameters.AddWithValue("_password", textBoxPassword.Text);
                int result=(int)cmd.ExecuteScalar();
                conn.Close();

                if (result == 1) 
                {
                    this.Hide();
                    Application.Run(new Form1());
                }
                else 
                {
                    MessageBox.Show("wrong login or password");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                conn.Close();        
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                string text;
                if (radioButtonStudent.Checked == true)
                    text = "student";
                if (radioButtonTeacher.Checked == true)

                    text = "teacher";
                else
                {
                    MessageBox.Show("sign up error");
                    return;
                }
                conn.Open();
                sql = @"insert into users values("+textBox3.Text+ ", "+textBox4.Text+ ", "+text+")";
                cmd = new NpgsqlCommand(sql, conn);
                int result = (int)cmd.ExecuteScalar();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("smth gone wrong" + ex.Message);
                conn.Close();
            }
        }
    }
}
