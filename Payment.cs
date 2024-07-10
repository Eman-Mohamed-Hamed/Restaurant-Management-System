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

namespace ShopManagmentSystem
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RAWAN;Initial Catalog=restaurantDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from Paymenttab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;

        }

        private void button1_Click(object sender, EventArgs e)
{
    // Define your connection string
    string connectionString = @"Data Source=RAWAN;Initial Catalog=restaurantDB;Integrated Security=True;Encrypt=False";

    // Create a connection
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        try
        {
            // Open the connection
            con.Open();

            // Define the SQL command with parameters
            SqlCommand cnn = new SqlCommand("Insert into Paymenttab Values(@id,@name,@food1,@food2,@PaymentMethod,@Total)", con);

            // Add parameters to the command
            cnn.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@name", textBox2.Text);
            cnn.Parameters.AddWithValue("@food1", textBox3.Text);
            cnn.Parameters.AddWithValue("@food2", textBox4.Text);
            cnn.Parameters.AddWithValue("@PaymentMethod", textBox5.Text);
            cnn.Parameters.AddWithValue("@Total", int.Parse(textBox6.Text));

            // Execute the command
            cnn.ExecuteNonQuery();

            // Show success message
            MessageBox.Show("Data Added");
        }
        catch (SqlException ex)
        {
            // Check if the exception is due to a foreign key constraint violation
            if (ex.Number == 547) // Error number for foreign key constraint violation
            {
                MessageBox.Show("This order is not found.",
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                // Handle other SQL exceptions
                MessageBox.Show("An error occurred while inserting data: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        finally
        {
            // Ensure the connection is closed
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RAWAN;Initial Catalog=restaurantDB;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Update Paymenttab set name=@name,food1=@food1,food2=@food2,PaymentMethod=@PaymentMethod,Total=@Total where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@name", (textBox2.Text));

            cnn.Parameters.AddWithValue("@food1", (textBox3.Text));

            cnn.Parameters.AddWithValue("@food2", (textBox4.Text));

            cnn.Parameters.AddWithValue("@PaymentMethod", (textBox5.Text));

            cnn.Parameters.AddWithValue("@Total", int.Parse(textBox6.Text));


            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RAWAN;Initial Catalog=restaurantDB;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Delete Paymenttab where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
        }

      
    }
}
