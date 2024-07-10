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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopManagmentSystem
{
    public partial class Waiter : Form
    {
        public Waiter()
        {
            InitializeComponent();
        }

        private void Waiter_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RAWAN;Initial Catalog=restaurantDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from Waitertab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RAWAN;Initial Catalog=restaurantDB;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into Waitertab Values(@id,@name,@age)", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@age", (textBox3.Text));
           

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RAWAN;Initial Catalog=restaurantDB;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Update Waitertab set name=@name,age=@age where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@name", (textBox2.Text));

            cnn.Parameters.AddWithValue("@age", (textBox3.Text));


            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RAWAN;Initial Catalog=restaurantDB;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Delete Waitertab where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
        }
    }
}
