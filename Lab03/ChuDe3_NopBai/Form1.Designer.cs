namespace ChuDe3_NopBai
{
    partial class Form1
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
            this.btnReadJSON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadJSON
            // 
            this.btnReadJSON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnReadJSON.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadJSON.Location = new System.Drawing.Point(194, 149);
            this.btnReadJSON.Name = "btnReadJSON";
            this.btnReadJSON.Size = new System.Drawing.Size(278, 135);
            this.btnReadJSON.TabIndex = 0;
            this.btnReadJSON.Text = "Đọc File JSON";
            this.btnReadJSON.UseVisualStyleBackColor = false;
            this.btnReadJSON.Click += new System.EventHandler(this.btnReadJSON_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReadJSON);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadJSON;
    }
}

