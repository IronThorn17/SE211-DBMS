using System.Windows.Forms;
using System;
using System.Drawing.Imaging;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SE211GroupProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetPlaceholder(txtUsername, "Username");
            SetPlaceholder(txtPassword, "Password");
        }

        string connectionString = DatabaseConnection.connectionString;
        string tableName = "employee";

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                // Create a MySqlConnection
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Create a MySqlDataAdapter to fetch data from the database
                    string query = $"SELECT * FROM {tableName}";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        // Create a DataTable to hold the data
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with data from the database
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = System.Drawing.SystemColors.GrayText;

            textBox.GotFocus += (s, ev) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.SystemColors.ControlText;
                }
            };

            textBox.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.SystemColors.GrayText;
                }
            };
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check username and password
            if (CheckCredentials(txtUsername.Text, txtPassword.Text))
            {
                // If credentials are correct, open the main form
                MainMenu mainForm = new MainMenu(); // Opens MainMenu.cs
                mainForm.Show();
                this.Hide();  // Hide the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckCredentials(string enteredUsername, string enteredPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query the database to check if the entered credentials match
                    string query = $"SELECT COUNT(*) FROM {tableName} WHERE EmployeeID = @Username AND Password = @Password";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", enteredUsername);
                        command.Parameters.AddWithValue("@Password", enteredPassword);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // If a match is found, count will be greater than 0
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
