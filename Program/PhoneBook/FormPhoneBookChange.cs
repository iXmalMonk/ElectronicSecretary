namespace ElectronicSecretary
{
    public partial class FormPhoneBookChange : Form
    {
        private int _id = 0;

        public FormPhoneBookChange(int id, string fullName, string phoneNumber)
        {
            InitializeComponent();
            _id = id;
            textBox1.Text = fullName;
            textBox2.Text = phoneNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 64 || textBox2.Text.Length > 16)
            {
                MessageBox.Show("Длина ФИО максимум 64 символа\nДлина номера телефона максимум 16 символов");
            }
            else if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1)
            {
                MessageBox.Show("Длина ФИО минимум 1 символ\nДлина номера телефона минимум 1 символ");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^[A-Za-zА-Яа-я\s]+$"))
            {
                MessageBox.Show("ФИО может состоять только из букв");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^[0-9]*$"))
            {
                MessageBox.Show("Номер телефона может состоять только из цифр");
            }
            else
            {
                Npgsql.NpgsqlConnection npgsqlConnection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=electronic_secretary;User Id=postgres;Password=5683");
                npgsqlConnection.Open();
                Npgsql.NpgsqlCommand npgsqlCommand = new Npgsql.NpgsqlCommand("update es.phone_book set full_name = @full_name, phone_number = @phone_number where id = @id", npgsqlConnection);
                npgsqlCommand.Parameters.AddWithValue("@id", _id);
                npgsqlCommand.Parameters.AddWithValue("@full_name", textBox1.Text);
                npgsqlCommand.Parameters.AddWithValue("@phone_number", textBox2.Text);
                npgsqlCommand.ExecuteNonQuery();
                npgsqlCommand.Dispose();
                npgsqlConnection.Close();
            }
        }
    }
}
