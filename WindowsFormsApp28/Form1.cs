using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Data.SqlClient;
using System.Threading;
using static System.Console;
using System.Windows.Forms;

namespace WindowsFormsApp28
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            floor= Convert.ToInt32(textBox2.Text);
            weight=Convert.ToString(textBox1.Text);
           using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-V11FJUF\SQLEXPRESS;Initial Catalog=calculator;User Id=DESKTOP-V11FJUF\Admin;Integrated Security=True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"INSERT INTO [dbo].[Customer]([Weigh],[flor]) VALUES(@my_login, @my_type);", connection))
                    {

                        SqlParameter loginParameter = new SqlParameter("@my_login", floor);
                        SqlParameter typeParameter = new SqlParameter("@my_type", weight);

                        command.Parameters.Add(loginParameter);
                        command.Parameters.Add(typeParameter);

                        int count = command.ExecuteNonQuery();
                        if (count > 0)
                            WriteLine($"added {count} rows!");
                        command.Dispose();
                    }
                    connection.Close();
                }
            MessageBox.Show("Ввод данных в базу данных успешно произашел");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
