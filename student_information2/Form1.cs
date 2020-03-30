using System;
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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=Ashraful-PC;Initial Catalog=stdnt;Integrated Security=True;Pooling=False");
        public Form1()
        {
            InitializeComponent();
            show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            
                con.Open();

                string name = textBox1.Text.ToString();
                string add=textBox2.Text.ToString();
                string phone=textBox3.Text.ToString();
                //int iphone = Int3f2.Parse(phone);
                long iphone = Int64.Parse(phone);
                string sem=textBox4.Text.ToString();
                int isem = Int32.Parse(sem);
                string branch = comboBox1.SelectedItem.ToString();
            
                string qry = "insert into student values('"+name+"','"+add+"',"+iphone+","+isem+",'"+branch+"')";


                SqlCommand sc = new SqlCommand(qry,con);
            int i = sc.ExecuteNonQuery();
            if (i >= 1)

                MessageBox.Show(i + "student registerd successfully: " + name);
            else
                MessageBox.Show(i + "student not registerd: ");
                button1_Click(sender, e);

                show();
                con.Close();
              }
            catch (System.Exception exp) {
                 
                MessageBox.Show("error is "+exp.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

                con.Open();

                string name = textBox1.Text.ToString();
                string add = textBox2.Text.ToString();
                string phone = textBox3.Text.ToString();
                //int iphone = Int3f2.Parse(phone);
                long iphone = Int64.Parse(phone);
                string sem = textBox4.Text.ToString();
                int isem = Int32.Parse(sem);
                string branch = comboBox1.SelectedItem.ToString();

                string qry = "update student set sadd='" + add + "',phone=" + iphone + ",sem=" + isem + ",branch='" + branch + "'where sname='" + name + "'";


                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)

                    MessageBox.Show(i + "student data updated successfully: " + name);
                else
                    MessageBox.Show(i + "student data updation failed: ");
                button1_Click(sender, e);

                show();
                con.Close();
            }
            catch (System.Exception exp)
            {

                MessageBox.Show("error is " + exp.ToString());
            }

        }

        void show()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select * from student", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach(DataRow dr in dt.Rows)
            {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                string name = textBox1.Text.ToString();
                string qry = "Delete from student where sname='" + name + "'";

                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)

                    MessageBox.Show(i + "student data deleted successfully: " + name);
                else
                    MessageBox.Show(i + "student data deletion failed: ");
                button1_Click(sender, e);

                show();
                con.Close();
            }
            catch (System.Exception exp)
            {

                MessageBox.Show("error is " + exp.ToString());
            } 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from student where sname like '%"+textBox5.Text.ToString()+"%'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
