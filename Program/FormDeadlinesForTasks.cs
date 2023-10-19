namespace ElectronicSecretary
{
    public partial class FormDeadlinesForTasks : Form
    {
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public FormDeadlinesForTasks()
        {
            InitializeComponent();
            selectFromTaskManager();
            _timer.Interval = 2500;
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void selectFromTaskManager()
        {
            Npgsql.NpgsqlConnection npgsqlConnection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=electronic_secretary;User Id=postgres;Password=5683");
            npgsqlConnection.Open();
            Npgsql.NpgsqlCommand npgsqlCommand = new Npgsql.NpgsqlCommand();
            npgsqlCommand.Connection = npgsqlConnection;
            npgsqlCommand.CommandType = System.Data.CommandType.Text;
            npgsqlCommand.CommandText = "select id, title, start_date, expiration_date from es.task_manager";
            Npgsql.NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Load(npgsqlDataReader);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[0].HeaderText = "Идентификатор";
            dataGridView1.Columns[1].HeaderText = "Заголовок";
            dataGridView1.Columns[2].HeaderText = "Дата начала";
            dataGridView1.Columns[3].HeaderText = "Дата окончания";
            npgsqlCommand.Dispose();
            npgsqlConnection.Close();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            selectFromTaskManager();
        }

        private void FormDeadlinesForTasks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
