namespace EnrollCourse
{
    partial class AdminControls
    {
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewCD = new System.Windows.Forms.DataGridView();
            this.btnavailablecourses = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCD)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCD
            // 
            this.dataGridViewCD.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewCD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCD.Location = new System.Drawing.Point(29, 147);
            this.dataGridViewCD.Name = "dataGridViewCD";
            this.dataGridViewCD.RowHeadersWidth = 51;
            this.dataGridViewCD.RowTemplate.Height = 24;
            this.dataGridViewCD.Size = new System.Drawing.Size(342, 256);
            this.dataGridViewCD.TabIndex = 0;
            // 
            // btnavailablecourses
            // 
            this.btnavailablecourses.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnavailablecourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnavailablecourses.ForeColor = System.Drawing.Color.Maroon;
            this.btnavailablecourses.Location = new System.Drawing.Point(63, 67);
            this.btnavailablecourses.Name = "btnavailablecourses";
            this.btnavailablecourses.Size = new System.Drawing.Size(128, 47);
            this.btnavailablecourses.TabIndex = 15;
            this.btnavailablecourses.Text = "All Courses";
            this.btnavailablecourses.UseVisualStyleBackColor = false;
            this.btnavailablecourses.Click += new System.EventHandler(this.btnavailablecourses_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(219, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 47);
            this.button1.TabIndex = 16;
            this.button1.Text = "Enrollemnts";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminControls
            // 
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(400, 431);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnavailablecourses);
            this.Controls.Add(this.dataGridViewCD);
            this.Name = "AdminControls";
            this.Load += new System.EventHandler(this.AdminControls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCD)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCD;
        private System.Windows.Forms.Button btnavailablecourses;
        private System.Windows.Forms.Button button1;
    }
}

