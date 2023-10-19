namespace ElectronicSecretary
{
    public partial class FormTaskManagerFilter : Form
    {
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public FormTaskManagerFilter()
        {
            InitializeComponent();
            selectFromTaskManager();
            _timer.Interval = 30000;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = $"convert([id], 'System.String') like '%{textBox1.Text}%' or [title] like '%{textBox1.Text}%' or [description] like '%{textBox1.Text}%' or convert([start_date], 'System.String') like '%{textBox1.Text}%' or convert([expiration_date], 'System.String') like '%{textBox1.Text}%'";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            selectFromTaskManager();
        }

        private void FormTaskManagerFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
