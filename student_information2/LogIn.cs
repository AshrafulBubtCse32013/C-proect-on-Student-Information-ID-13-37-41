﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace student_information2
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Ashraful-PC;Initial Catalog=stdnt;Integrated Security=True;Pooling=False");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from student where sname = '" + textBox1.Text.ToString() + "'and sadd='"+textBox2.Text.ToString()+"'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                BUBTMDI cs = new BUBTMDI();
                cs.Show();
                this.Hide();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
