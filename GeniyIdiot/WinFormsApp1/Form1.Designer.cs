
namespace WinFormsApp1
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            questionLabel = new Label();
            userAnswerTextBox = new TextBox();
            questionTextLabel = new Label();
            nextButton = new Button();
            restartbutton = new Button();
            exitButton = new Button();
            SuspendLayout();
            // 
            // questionLabel
            // 
            questionLabel.AutoSize = true;
            questionLabel.Location = new Point(67, 29);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(70, 15);
            questionLabel.TabIndex = 0;
            questionLabel.Text = "Вопрос №1";
            // 
            // userAnswerTextBox
            // 
            userAnswerTextBox.Location = new Point(67, 90);
            userAnswerTextBox.Name = "userAnswerTextBox";
            userAnswerTextBox.Size = new Size(136, 23);
            userAnswerTextBox.TabIndex = 1;
            userAnswerTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // questionTextLabel
            // 
            questionTextLabel.Location = new Point(67, 55);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(325, 32);
            questionTextLabel.TabIndex = 2;
            questionTextLabel.Text = "Текст вопрос";
            questionTextLabel.Click += questionTextLabel_Click;
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nextButton.Location = new Point(47, 139);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(182, 136);
            nextButton.TabIndex = 3;
            nextButton.Text = "Далее";
            nextButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // restartbutton
            // 
            restartbutton.Location = new Point(47, 299);
            restartbutton.Name = "restartbutton";
            restartbutton.Size = new Size(90, 48);
            restartbutton.TabIndex = 4;
            restartbutton.Text = "Всё сначала";
            restartbutton.UseVisualStyleBackColor = true;
            restartbutton.Click += buttonRestart_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(69, 385);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 5;
            exitButton.Text = "Выход";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 465);
            Controls.Add(exitButton);
            Controls.Add(restartbutton);
            Controls.Add(nextButton);
            Controls.Add(questionTextLabel);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionLabel);
            Name = "mainForm";
            Text = "ГенийИдиот";
            Load += mainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label questionLabel;
        private TextBox userAnswerTextBox;
        private Label questionTextLabel;
        private Button nextButton;
        private Button restartbutton;
        private Button exitButton;
    }
}
