using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopDatabase
{
    public partial class CoffeeShop : Form
    {
        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=PC-301-08\SQLEXPRESS;DataBase=CoffeeShop;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"INSERT INTO Items (Name, Price) VALUES('"+NameTextBox.Text+"',"+PriceTextBox.Text+")";
           
            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
           




            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();




        }

        private void CoffeeShop_Load(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=PC-301-08\SQLEXPRESS;DataBase=CoffeeShop;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //string CommandString = @"INSERT INTO Items (Name, Price) VALUES('"+NameTextBox.Text+"',"+PriceTextBox.Text+")";
            string CommandString = @"SELECT * FROM Items";
            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;




            //sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();



        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=PC-301-08\SQLEXPRESS;DataBase=CoffeeShop;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"DELETE FROM Items WHERE ID="+deleteTextBox.Text+"";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


        }







        private void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=PC-301-08\SQLEXPRESS;DataBase=CoffeeShop;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"UPDATE Items SET Name='"+NameTextBox.Text+"', Price='"+PriceTextBox.Text+"' WHERE ID='"+deleteTextBox.Text+"'";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            

            sqlConnection.Close();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=PC-301-08\SQLEXPRESS;DataBase=CoffeeShop;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT * FROM Items WHERE ID='"+deleteTextBox.Text+"'";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;



            sqlConnection.Close();
        }
    }
}
