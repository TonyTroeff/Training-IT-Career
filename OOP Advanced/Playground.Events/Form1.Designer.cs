namespace Playground.Events
{
    partial class Form1
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
            operativeButton = new Button();
            clicksCounter = new Label();
            textBox = new TextBox();
            textLabel = new Label();
            SuspendLayout();
            // 
            // operativeButton
            // 
            operativeButton.Location = new Point(119, 133);
            operativeButton.Name = "operativeButton";
            operativeButton.Size = new Size(321, 159);
            operativeButton.TabIndex = 0;
            operativeButton.Text = "Click me!";
            operativeButton.UseVisualStyleBackColor = true;
            operativeButton.Click += OnButtonClick;
            // 
            // clicksCounter
            // 
            clicksCounter.AutoSize = true;
            clicksCounter.Location = new Point(499, 133);
            clicksCounter.Name = "clicksCounter";
            clicksCounter.Size = new Size(114, 15);
            clicksCounter.TabIndex = 1;
            clicksCounter.Text = "Click counter label...";
            // 
            // textBox
            // 
            textBox.Location = new Point(119, 91);
            textBox.Name = "textBox";
            textBox.Size = new Size(321, 23);
            textBox.TabIndex = 2;
            textBox.TextChanged += OnTextChanged;
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Location = new Point(499, 99);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(0, 15);
            textLabel.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textLabel);
            Controls.Add(textBox);
            Controls.Add(clicksCounter);
            Controls.Add(operativeButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button operativeButton;
        private Label clicksCounter;
        private TextBox textBox;
        private Label textLabel;
    }
}