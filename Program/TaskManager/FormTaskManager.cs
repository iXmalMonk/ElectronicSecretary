namespace ElectronicSecretary
{
    public partial class FormTaskManager : Form
    {
        public FormTaskManager()
        {
            InitializeComponent();
            selectFromTaskManager();
        }

        private void selectFromTaskManager()
        {
            Npgsql.NpgsqlConnection npgsqlConnection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=electronic_secretary;User Id=postgres;Password=5683");
            npgsqlConnection.Open();
            Npgsql.NpgsqlCommand npgsqlCommand = new Npgsql.NpgsqlCommand();
            npgsqlCommand.Connection = npgsqlConnection;
            npgsqlCommand.CommandType = System.Data.CommandType.Text;
            npgsqlCommand.CommandText = "select * from es.task_manager";
            Npgsql.NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Load(npgsqlDataReader);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 165;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[0].HeaderText = "Идентификатор";
            dataGridView1.Columns[1].HeaderText = "Заголовок";
            dataGridView1.Columns[2].HeaderText = "Описание";
            dataGridView1.Columns[3].HeaderText = "Дата начала";
            dataGridView1.Columns[4].HeaderText = "Дата окончания";
            npgsqlCommand.Dispose();
            npgsqlConnection.Close();
        }

        private void FormTaskManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTaskManagerAdd formTaskManagerAdd = new FormTaskManagerAdd();
            if (formTaskManagerAdd.ShowDialog() == DialogResult.OK)
            {
                selectFromTaskManager();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            catch
            {
                MessageBox.Show("Не выбрано поле");
            }
            if (id == 0)
            {
                MessageBox.Show("Не выбрано поле");
            }
            else
            {
                FormTaskManagerChange formTaskManagerChange = new FormTaskManagerChange(id, Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value), Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value), Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value), Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value));
                if (formTaskManagerChange.ShowDialog() == DialogResult.OK)
                {
                    selectFromTaskManager();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            catch
            {
                MessageBox.Show("Не выбрано поле");
            }
            if (id == 0)
            {
                MessageBox.Show("Не выбрано поле");
            }
            else
            {
                Npgsql.NpgsqlConnection npgsqlConnection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=electronic_secretary;User Id=postgres;Password=5683");
                npgsqlConnection.Open();
                Npgsql.NpgsqlCommand npgsqlCommand = new Npgsql.NpgsqlCommand("delete from es.task_manager where id = @id", npgsqlConnection);
                npgsqlCommand.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                npgsqlCommand.ExecuteNonQuery();
                npgsqlCommand.Dispose();
                npgsqlConnection.Close();
                selectFromTaskManager();
            }
        }
    }
}
