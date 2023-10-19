namespace ElectronicSecretary
{
    public partial class FormMain : Form
    {
        private Form _formPhoneBook = new FormPhoneBook();
        private Form _formTaskManager = new FormTaskManager();
        private Form _formDeadlinesForTasks = new FormDeadlinesForTasks();
        private Form _formPhoneBookFilter = new FormPhoneBookFilter();
        private Form _formTaskManagerFilter = new FormTaskManagerFilter();

        public FormMain()
        {
            InitializeComponent();
            _formPhoneBook.MdiParent = this;
            _formTaskManager.MdiParent = this;
            _formDeadlinesForTasks.MdiParent = this;
            _formPhoneBookFilter.MdiParent = this;
            _formTaskManagerFilter.MdiParent = this;
        }

        private void phoneBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formPhoneBook.Show();
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formTaskManager.Show();
        }

        private void deadlinesForTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formDeadlinesForTasks.Show();
        }

        private void phoneBookFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formPhoneBookFilter.Show();
        }

        private void taskManagerFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formTaskManagerFilter.Show();
        }
    }
}
