namespace DataBaseStudents
{
    partial class StudentForm
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
            this.dataGridViewSubjects = new System.Windows.Forms.DataGridView();
            this.PassId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Pass = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSubjects
            // 
            this.dataGridViewSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PassId,
            this.Subject,
            this.Pass});
            this.dataGridViewSubjects.Location = new System.Drawing.Point(25, 12);
            this.dataGridViewSubjects.Name = "dataGridViewSubjects";
            this.dataGridViewSubjects.RowTemplate.Height = 24;
            this.dataGridViewSubjects.Size = new System.Drawing.Size(384, 234);
            this.dataGridViewSubjects.TabIndex = 2;
            this.dataGridViewSubjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSubjects_CellContentClick);
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
            this.Pass.ReadOnly = true;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 265);
            this.Controls.Add(this.dataGridViewSubjects);
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentForm_FormClosing);
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassId;
        private System.Windows.Forms.DataGridViewButtonColumn Subject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pass;
    }
}