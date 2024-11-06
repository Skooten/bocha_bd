using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace test_bd
{
    public partial class Form1 : Form
    {
        FileName database = new FileName();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                database.openConnection();
                SqlConnection conn = database.GetConnection();

                string query = "SELECT * FROM test_dbbb";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Таблица пуста");
                }
                else
                {
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
            finally
            {
                database.closeConnection();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}