
namespace TaskAccounting
{
    partial class ClientWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отправитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьЗадачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskDataGridView = new System.Windows.Forms.DataGridView();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.отправитьToolStripMenuItem,
            this.выбратьЗадачиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(994, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // отправитьToolStripMenuItem
            // 
            this.отправитьToolStripMenuItem.Name = "отправитьToolStripMenuItem";
            this.отправитьToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.отправитьToolStripMenuItem.Text = "Отправить";
            this.отправитьToolStripMenuItem.Click += new System.EventHandler(this.отправитьToolStripMenuItem_Click);
            // 
            // выбратьЗадачиToolStripMenuItem
            // 
            this.выбратьЗадачиToolStripMenuItem.Name = "выбратьЗадачиToolStripMenuItem";
            this.выбратьЗадачиToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.выбратьЗадачиToolStripMenuItem.Text = "Выбрать задачи";
            this.выбратьЗадачиToolStripMenuItem.Click += new System.EventHandler(this.выбратьЗадачиToolStripMenuItem_Click);
            // 
            // TaskDataGridView
            // 
            this.TaskDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Task});
            this.TaskDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskDataGridView.Location = new System.Drawing.Point(0, 24);
            this.TaskDataGridView.Name = "TaskDataGridView";
            this.TaskDataGridView.Size = new System.Drawing.Size(994, 426);
            this.TaskDataGridView.TabIndex = 1;
            // 
            // Task
            // 
            this.Task.Frozen = true;
            this.Task.HeaderText = "Задача";
            this.Task.Name = "Task";
            this.Task.ReadOnly = true;
            // 
            // ClientWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 450);
            this.Controls.Add(this.TaskDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientWindow";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отправитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьЗадачиToolStripMenuItem;
        private System.Windows.Forms.DataGridView TaskDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
    }
}

