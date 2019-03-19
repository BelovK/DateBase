namespace DataBaseStudents
{
    partial class MainForm
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
            this.dataGridViewStudent = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Student = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewSubjects = new System.Windows.Forms.DataGridView();
            this.PassId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Pass = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStudent
            // 
            this.dataGridViewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Student});
            this.dataGridViewStudent.Location = new System.Drawing.Point(30, 50);
            this.dataGridViewStudent.Name = "dataGridViewStudent";
            this.dataGridViewStudent.RowTemplate.Height = 24;
            this.dataGridViewStudent.Size = new System.Drawing.Size(311, 234);
            this.dataGridViewStudent.TabIndex = 0;
            this.dataGridViewStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudent_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // Student
            // 
            this.Student.HeaderText = "Имя Студента";
            this.Student.Name = "Student";
            this.Student.ReadOnly = true;
            // 
            // dataGridViewSubjects
            // 
            this.dataGridViewSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PassId,
            this.Subject,
            this.Pass});
            this.dataGridViewSubjects.Location = new System.Drawing.Point(429, 50);
            this.dataGridViewSubjects.Name = "dataGridViewSubjects";
            this.dataGridViewSubjects.RowTemplate.Height = 24;
            this.dataGridViewSubjects.Size = new System.Drawing.Size(384, 234);
            this.dataGridViewSubjects.TabIndex = 1;
            this.dataGridViewSubjects.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSubjects_CellContentClick);
            // 
            // PassId
            // 
            this.PassId.HeaderText = "ID";
            this.PassId.Name = "PassId";
            this.PassId.ReadOnly = true;
            this.PassId.Width = 50;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Предмет";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            // 
            // Pass
            // 
            this.Pass.HeaderText = "Оценка";
            this.Pass.Name = "Pass";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 314);
            this.Controls.Add(this.dataGridViewSubjects);
            this.Controls.Add(this.dataGridViewStudent);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewButtonColumn Student;
        private System.Windows.Forms.DataGridView dataGridViewSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassId;
        private System.Windows.Forms.DataGridViewButtonColumn Subject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pass;
    }
}