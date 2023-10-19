namespace ElectronicSecretary
{
    public partial class FormPhoneBook : Form
    {
        public FormPhoneBook()
        {
            InitializeComponent();
            selectFromPhoneBook();
        }

        private void selectFromPhoneBook()
        {
            Npgsql.NpgsqlConnection npgsqlConnection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=electronic_secretary;User Id=postgres;Password=5683");
            npgsqlConnection.Open();
            Npgsql.NpgsqlCommand npgsqlCommand = new Npgsql.NpgsqlCommand();
            npgsqlCommand.Connection = npgsqlConnection;
            npgsqlCommand.CommandType = System.Data.CommandType.Text;
            npgsqlCommand.CommandText = "select * from es.phone_book";
            Npgsql.NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Load(npgsqlDataReader);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 265;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[0].HeaderText = "Идентификатор";
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Номер телефона";
            npgsqlCommand.Dispose();
            npgsqlConnection.Close();
        }

        private void FormPhoneBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPhoneBookAdd formPhoneBookAdd = new FormPhoneBookAdd();
            if (formPhoneBookAdd.ShowDialog() == DialogResult.OK)
            {
                selectFromPhoneBook();
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
                FormPhoneBookChange formPhoneBookChange = new FormPhoneBookChange(id, Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value), Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value));
                if (formPhoneBookChange.ShowDialog() == DialogResult.OK)
                {
                    selectFromPhoneBook();
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
                Npgsql.NpgsqlCommand npgsqlCommand = new Npgsql.NpgsqlCommand("delete from es.phone_book where id = @id", npgsqlConnection);
                npgsqlCommand.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                npgsqlCommand.ExecuteNonQuery();
                npgsqlCommand.Dispose();
                npgsqlConnection.Close();
                selectFromPhoneBook();
            }
        }
    }
}
