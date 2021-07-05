
namespace KR
{
    partial class Output
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
            this.input_rtb = new System.Windows.Forms.RichTextBox();
            this.output_rtb = new System.Windows.Forms.RichTextBox();
            this.close_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input_rtb
            // 
            this.input_rtb.Enabled = false;
            this.input_rtb.Location = new System.Drawing.Point(12, 29);
            this.input_rtb.Name = "input_rtb";
            this.input_rtb.Size = new System.Drawing.Size(300, 215);
            this.input_rtb.TabIndex = 0;
            this.input_rtb.Text = "";
            // 
            // output_rtb
            // 
            this.output_rtb.Enabled = false;
            this.output_rtb.Location = new System.Drawing.Point(331, 29);
            this.output_rtb.Name = "output_rtb";
            this.output_rtb.Size = new System.Drawing.Size(300, 215);
            this.output_rtb.TabIndex = 1;
            this.output_rtb.Text = "";
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(556, 263);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(75, 27);
            this.close_btn.TabIndex = 2;
            this.close_btn.Text = "Ok";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Исходный текст:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Результат:";
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 313);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.output_rtb);
            this.Controls.Add(this.input_rtb);
            this.Name = "Output";
            this.Text = "Транслитер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox input_rtb;
        private System.Windows.Forms.RichTextBox output_rtb;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}