namespace Lab98 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.txt = new System.Windows.Forms.Label();
            this.textEnter = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(67, 111);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 0;
            this.btn.Text = "&Display";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(151, 111);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 1;
            this.clear.Text = "C&lear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.btn_Clear);
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(64, 63);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(56, 13);
            this.txt.TabIndex = 2;
            this.txt.Text = "Enter Text";
            this.txt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textEnter
            // 
            this.textEnter.Location = new System.Drawing.Point(126, 60);
            this.textEnter.Name = "textEnter";
            this.textEnter.Size = new System.Drawing.Size(100, 20);
            this.textEnter.TabIndex = 3;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 153);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(260, 96);
            this.outputBox.TabIndex = 4;
            this.outputBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.textEnter);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.btn);
            this.Name = "Form1";
            this.Text = "My First GUI Lab";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.TextBox textEnter;
        private System.Windows.Forms.RichTextBox outputBox;
    }
}

