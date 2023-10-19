namespace ElectronicSecretary
{
    public partial class FormPhoneBookFilter : Form
    {
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public FormPhoneBookFilter()
        {
            InitializeComponent();
            selectFromPhoneBook();
            _timer.Interval = 30000;
            _timer.Tick += TimerTick;
            _timer.Start();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = $"convert([id], 'System.String') like '%{textBox1.Text}%' or [full_name] like '%{textBox1.Text}%' or [phone_number] like '%{textBox1.Text}%'";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            selectFromPhoneBook();
        }

        private void FormPhoneBookFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
