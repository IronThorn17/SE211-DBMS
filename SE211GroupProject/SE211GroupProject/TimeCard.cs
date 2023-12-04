using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE211GroupProject
{
    public partial class TimeCard : Form
    {
        string connectionString = DatabaseConnection.connectionString;
        string tableName = "TimeCard";

        public TimeCard()
        {
            InitializeComponent();

            PopulateDataGridView();
        }

        private void PopulateDataGridView()
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

                        // Set the DataSource of the DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Set the DataGridView to read-only
                        dataGridView1.ReadOnly = true;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"INSERT INTO {tableName} (PayrollID, EmployeeID, ClockIn, ClockOut, Hours) " +
                                   "VALUES (@PayrollID, @EmployeeID, @ClockIn, @ClockOut, @Hours)";

                    // Display the SQL query in the console
                    Console.WriteLine("Executing SQL Query:\n" + query);

                    // Create a MySqlCommand
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters dynamically
                        AddParametersFromTextBoxes(command);

                        // Execute the command
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                MessageBox.Show("Command executed successfully.");
                PopulateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing command: {ex.Message}");
            }
        }

        private void AddParametersFromTextBoxes(MySqlCommand command)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && textBox.Name.StartsWith("txt"))
                {
                    string parameterName = $"@{textBox.Name.Substring(3)}";
                    command.Parameters.AddWithValue(parameterName, textBox.Text);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct the SQL query for update
                    string query = $"UPDATE {tableName} SET ";
                    List<string> columns = new List<string> { "ManagerID", "firstName", "lastName", "DepartmentID" };

                    foreach (string column in columns)
                    {
                        query += $"{column} = @{column}, ";
                    }

                    // Remove the trailing comma and space
                    query = query.Remove(query.Length - 2);

                    query += " WHERE PayrollID = @PayrollID";

                    // Display the SQL query in the console
                    Console.WriteLine("Executing SQL Query:\n" + query);

                    // Create a MySqlCommand
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters dynamically
                        foreach (string column in columns)
                        {
                            command.Parameters.AddWithValue($"@{column}", GetTextBoxValue(column));
                        }

                        // Execute the command
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                MessageBox.Show("Update executed successfully.");
                PopulateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing update: {ex.Message}");
            }
        }

        private string GetTextBoxValue(string columnName)
        {
            Control[] controls = this.Controls.Find($"txt{columnName}", true);
            if (controls.Length > 0 && controls[0] is TextBox)
            {
                return ((TextBox)controls[0]).Text;
            }
            return string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the command text from the TextBox
                    string payrollID = txtPayrollID.Text;

                    string query = $"DELETE FROM {tableName} WHERE PayrollID = @PayrollID";

                    // Display the SQL query in the console
                    Console.WriteLine("Executing SQL Query:\n" + query);

                    // Create a MySqlCommand
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PayrollID", payrollID);

                        // Execute the command
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                MessageBox.Show("Command executed successfully.");
                PopulateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing command: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Specify the column names you want to include in the search
                    List<string> columnNames = new List<string>
                    {
                        "PayrollID",
                        "EmployeeID",
                        "ClockIn",
                        "ClockOut",
                        "Hours"
                        // Add more column names as needed
                    };

                    // Create a list to store conditions
                    List<string> conditions = new List<string>();

                    // Create a MySqlCommand
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = connection;

                        // Check each specified column and add conditions for filled textboxes
                        foreach (string columnName in columnNames)
                        {
                            TextBox textBox = Controls.Find("txt" + columnName, true).FirstOrDefault() as TextBox;

                            if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
                            {
                                string parameterName = $"@{columnName}";
                                conditions.Add($"{columnName} = {parameterName}");
                                command.Parameters.AddWithValue(parameterName, textBox.Text);
                            }
                        }

                        // Construct the WHERE clause
                        string whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";

                        // Construct the SQL query
                        string query = $"SELECT * FROM {tableName} {whereClause}";

                        // Display the SQL query in the console
                        Console.WriteLine("Executing SQL Query:\n" + query);

                        command.CommandText = query;

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Handle retrieved data here (display in textboxes, etc.)
                                DisplayDataInTextBoxes(reader);
                            }
                            else
                            {
                                MessageBox.Show("TimeCard not found.");
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing command: {ex.Message}");
            }
        }

        private void DisplayDataInTextBoxes(MySqlDataReader reader)
        {
            txtPayrollID.Text = reader["PayrollID"].ToString();
            txtEmployeeID.Text = reader["EmployeeID"].ToString();
            txtClockIn.Text = reader["ClockIn"].ToString();
            txtClockOut.Text = reader["ClockOut"].ToString();
            txtHours.Text = reader["Hours"].ToString();
            // Add more textboxes for other columns as needed
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
