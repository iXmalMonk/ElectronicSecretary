namespace ElectronicSecretary
{
    public partial class FormTaskManagerChange : Form
    {
        private int _id = 0;

        public FormTaskManagerChange(int id, string title, string description, DateTime startDate, DateTime expirationDate)
        {
            InitializeComponent();
            _id = id;
            textBox1.Text = title;
            textBox2.Text = description;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = expirationDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 32 || textBox2.Text.Length > 256)
            {
                MessageBox.Show("Длина заголовка максимум 32 символа\nДлина описания максимум 256 символов");
            }
            else if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1)
            {
                MessageBox.Show("Длина заголовка минимум 1 символ\nДлина описания минимум 1 символ");
            }
            else if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Дата начала не может быть больше даты окончания");
            }
            else
            {
                Npgsql.NpgsqlConnection npgsqlConnection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=electronic_secretary;User Id=postgres;Password=5683");
                npgsqlConnection.Open();
                Npgsql.NpgsqlCommand npgsqlCommand = new Npgsql.NpgsqlCommand("update es.task_manager set title = @title, description = @description, start_date = @start_date, expiration_date = @expiration_date where id = @id", npgsqlConnection);
                npgsqlCommand.Parameters.AddWithValue("@id", _id);
                npgsqlCommand.Parameters.AddWithValue("@title", textBox1.Text);
                npgsqlCommand.Parameters.AddWithValue("@description", textBox1.Text);
                npgsqlCommand.Parameters.AddWithValue("@start_date", dateTimePicker1.Value);
                npgsqlCommand.Parameters.AddWithValue("@expiration_date", dateTimePicker2.Value);
                npgsqlCommand.ExecuteNonQuery();
                npgsqlCommand.Dispose();
                npgsqlConnection.Close();
            }
        }
    }
}
