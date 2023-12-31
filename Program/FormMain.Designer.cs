﻿namespace ElectronicSecretary
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            phoneBookToolStripMenuItem = new ToolStripMenuItem();
            taskManagerToolStripMenuItem = new ToolStripMenuItem();
            deadlinesForTasksToolStripMenuItem = new ToolStripMenuItem();
            phoneBookFilterToolStripMenuItem = new ToolStripMenuItem();
            taskManagerFilterToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { phoneBookToolStripMenuItem, taskManagerToolStripMenuItem, deadlinesForTasksToolStripMenuItem, phoneBookFilterToolStripMenuItem, taskManagerFilterToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // phoneBookToolStripMenuItem
            // 
            phoneBookToolStripMenuItem.Name = "phoneBookToolStripMenuItem";
            phoneBookToolStripMenuItem.Size = new Size(120, 20);
            phoneBookToolStripMenuItem.Text = "Телефонная книга";
            phoneBookToolStripMenuItem.Click += phoneBookToolStripMenuItem_Click;
            // 
            // taskManagerToolStripMenuItem
            // 
            taskManagerToolStripMenuItem.Name = "taskManagerToolStripMenuItem";
            taskManagerToolStripMenuItem.Size = new Size(132, 20);
            taskManagerToolStripMenuItem.Text = "Планировщик задач";
            taskManagerToolStripMenuItem.Click += taskManagerToolStripMenuItem_Click;
            // 
            // deadlinesForTasksToolStripMenuItem
            // 
            deadlinesForTasksToolStripMenuItem.Name = "deadlinesForTasksToolStripMenuItem";
            deadlinesForTasksToolStripMenuItem.Size = new Size(140, 20);
            deadlinesForTasksToolStripMenuItem.Text = "Дедлайны по задачам";
            deadlinesForTasksToolStripMenuItem.Click += deadlinesForTasksToolStripMenuItem_Click;
            // 
            // phoneBookFilterToolStripMenuItem
            // 
            phoneBookFilterToolStripMenuItem.Name = "phoneBookFilterToolStripMenuItem";
            phoneBookFilterToolStripMenuItem.Size = new Size(164, 20);
            phoneBookFilterToolStripMenuItem.Text = "Телефонная книга - поиск";
            phoneBookFilterToolStripMenuItem.Click += phoneBookFilterToolStripMenuItem_Click;
            // 
            // taskManagerFilterToolStripMenuItem
            // 
            taskManagerFilterToolStripMenuItem.Name = "taskManagerFilterToolStripMenuItem";
            taskManagerFilterToolStripMenuItem.Size = new Size(176, 20);
            taskManagerFilterToolStripMenuItem.Text = "Планировщик задач - поиск";
            taskManagerFilterToolStripMenuItem.Click += taskManagerFilterToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "Электронный секретарь";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem phoneBookToolStripMenuItem;
        private ToolStripMenuItem taskManagerToolStripMenuItem;
        private ToolStripMenuItem deadlinesForTasksToolStripMenuItem;
        private ToolStripMenuItem phoneBookFilterToolStripMenuItem;
        private ToolStripMenuItem taskManagerFilterToolStripMenuItem;
    }
}