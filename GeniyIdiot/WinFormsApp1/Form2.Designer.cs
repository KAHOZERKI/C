namespace GeniyIdiot.WinForm
{
    partial class resultsForm
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
            resultsBox = new DataGridView();
            closeButton = new Button();
            ColumnName = new DataGridViewTextBoxColumn();
            columnBalls = new DataGridViewTextBoxColumn();
            ColumnDiagnoz = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)resultsBox).BeginInit();
            SuspendLayout();
            // 
            // resultsBox
            // 
            resultsBox.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsBox.Columns.AddRange(new DataGridViewColumn[] { ColumnName, columnBalls, ColumnDiagnoz });
            resultsBox.Location = new Point(251, 116);
            resultsBox.Name = "resultsBox";
            resultsBox.Size = new Size(411, 197);
            resultsBox.TabIndex = 0;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(591, 116);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(71, 26);
            closeButton.TabIndex = 1;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // ColumnName
            // 
            ColumnName.HeaderText = "Имя";
            ColumnName.Name = "ColumnName";
            // 
            // columnBalls
            // 
            columnBalls.HeaderText = "Баллы";
            columnBalls.Name = "columnBalls";
            // 
            // ColumnDiagnoz
            // 
            ColumnDiagnoz.HeaderText = "Диагноз";
            ColumnDiagnoz.Name = "ColumnDiagnoz";
            // 
            // resultsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(closeButton);
            Controls.Add(resultsBox);
            Name = "resultsForm";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)resultsBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView resultsBox;
        private Button closeButton;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn columnBalls;
        private DataGridViewTextBoxColumn ColumnDiagnoz;
    }
}