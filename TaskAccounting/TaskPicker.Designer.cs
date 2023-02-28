
namespace TaskAccounting
{
    partial class TaskPicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.departmentPickerComboBox = new System.Windows.Forms.ComboBox();
            this.DepartmentPickerLable = new System.Windows.Forms.Label();
            this.ProjectPickerLable = new System.Windows.Forms.Label();
            this.projectPickerComboBox = new System.Windows.Forms.ComboBox();
            this.taskCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.taskTypeLabel = new System.Windows.Forms.Label();
            this.taskTypePickerComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bigTaskTypeLable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // departmentPickerComboBox
            // 
            this.departmentPickerComboBox.FormattingEnabled = true;
            this.departmentPickerComboBox.Location = new System.Drawing.Point(12, 29);
            this.departmentPickerComboBox.Name = "departmentPickerComboBox";
            this.departmentPickerComboBox.Size = new System.Drawing.Size(121, 21);
            this.departmentPickerComboBox.TabIndex = 0;
            this.departmentPickerComboBox.SelectedIndexChanged += new System.EventHandler(this.DepartmentPickerComboBox_SelectedIndexChanged);
            // 
            // DepartmentPickerLable
            // 
            this.DepartmentPickerLable.AutoSize = true;
            this.DepartmentPickerLable.Location = new System.Drawing.Point(13, 13);
            this.DepartmentPickerLable.Name = "DepartmentPickerLable";
            this.DepartmentPickerLable.Size = new System.Drawing.Size(38, 13);
            this.DepartmentPickerLable.TabIndex = 1;
            this.DepartmentPickerLable.Text = "Отдел";
            // 
            // ProjectPickerLable
            // 
            this.ProjectPickerLable.AutoSize = true;
            this.ProjectPickerLable.Location = new System.Drawing.Point(137, 13);
            this.ProjectPickerLable.Name = "ProjectPickerLable";
            this.ProjectPickerLable.Size = new System.Drawing.Size(44, 13);
            this.ProjectPickerLable.TabIndex = 2;
            this.ProjectPickerLable.Text = "Проект";
            // 
            // projectPickerComboBox
            // 
            this.projectPickerComboBox.FormattingEnabled = true;
            this.projectPickerComboBox.Location = new System.Drawing.Point(140, 29);
            this.projectPickerComboBox.Name = "projectPickerComboBox";
            this.projectPickerComboBox.Size = new System.Drawing.Size(648, 21);
            this.projectPickerComboBox.TabIndex = 3;
            this.projectPickerComboBox.SelectedIndexChanged += new System.EventHandler(this.projectPickerComboBox_SelectedIndexChanged);
            // 
            // taskCheckedListBox
            // 
            this.taskCheckedListBox.FormattingEnabled = true;
            this.taskCheckedListBox.Location = new System.Drawing.Point(12, 178);
            this.taskCheckedListBox.Name = "taskCheckedListBox";
            this.taskCheckedListBox.Size = new System.Drawing.Size(776, 94);
            this.taskCheckedListBox.TabIndex = 4;
            // 
            // taskTypeLabel
            // 
            this.taskTypeLabel.AutoSize = true;
            this.taskTypeLabel.Location = new System.Drawing.Point(13, 57);
            this.taskTypeLabel.Name = "taskTypeLabel";
            this.taskTypeLabel.Size = new System.Drawing.Size(74, 13);
            this.taskTypeLabel.TabIndex = 5;
            this.taskTypeLabel.Text = "Группа задач";
            // 
            // taskTypePickerComboBox
            // 
            this.taskTypePickerComboBox.FormattingEnabled = true;
            this.taskTypePickerComboBox.Location = new System.Drawing.Point(12, 74);
            this.taskTypePickerComboBox.Name = "taskTypePickerComboBox";
            this.taskTypePickerComboBox.Size = new System.Drawing.Size(776, 21);
            this.taskTypePickerComboBox.TabIndex = 6;
            this.taskTypePickerComboBox.SelectedIndexChanged += new System.EventHandler(this.taskTypeComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(713, 413);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Готово";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(632, 413);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // bigTaskTypeLable
            // 
            this.bigTaskTypeLable.AutoSize = true;
            this.bigTaskTypeLable.Location = new System.Drawing.Point(12, 102);
            this.bigTaskTypeLable.Name = "bigTaskTypeLable";
            this.bigTaskTypeLable.Size = new System.Drawing.Size(0, 13);
            this.bigTaskTypeLable.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(467, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(304, 279);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TaskPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 443);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bigTaskTypeLable);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.taskTypePickerComboBox);
            this.Controls.Add(this.taskTypeLabel);
            this.Controls.Add(this.taskCheckedListBox);
            this.Controls.Add(this.projectPickerComboBox);
            this.Controls.Add(this.ProjectPickerLable);
            this.Controls.Add(this.DepartmentPickerLable);
            this.Controls.Add(this.departmentPickerComboBox);
            this.Name = "TaskPicker";
            this.Text = "TaskPicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox departmentPickerComboBox;
        private System.Windows.Forms.Label DepartmentPickerLable;
        private System.Windows.Forms.Label ProjectPickerLable;
        private System.Windows.Forms.ComboBox projectPickerComboBox;
        private System.Windows.Forms.CheckedListBox taskCheckedListBox;
        private System.Windows.Forms.Label taskTypeLabel;
        private System.Windows.Forms.ComboBox taskTypePickerComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label bigTaskTypeLable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}