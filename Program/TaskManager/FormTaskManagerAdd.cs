namespace ElectronicSecretary
{
    public partial class FormTaskManagerAdd : Form
    {
        public FormTaskManagerAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 32 || textBox2.Text.Length > 256 )
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
                Npgsql.NpgsqlCommand npgsqlCommand = new Npgsql.NpgsqlCommand("insert into es.task_manager(title, description, start_date, expiration_date) values(@title, @description, @start_date, @expiration_date)", npgsqlConnection);
                npgsqlCommand.Parameters.AddWithValue("@title", textBox1.Text);
                npgsqlCommand.Parameters.AddWithValue("@description", textBox2.Text);
                npgsqlCommand.Parameters.AddWithValue("@start_date", dateTimePicker1.Value);
                npgsqlCommand.Parameters.AddWithValue("@expiration_date", dateTimePicker2.Value);
                npgsqlCommand.ExecuteNonQuery();
                npgsqlCommand.Dispose();
                npgsqlConnection.Close();
            }
        }
    }
}
