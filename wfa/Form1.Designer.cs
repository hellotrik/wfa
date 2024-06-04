namespace wfa
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.en = new System.Windows.Forms.Button();
            this.de = new System.Windows.Forms.Button();
            this.miwen = new System.Windows.Forms.TextBox();
            this.mingwen = new System.Windows.Forms.TextBox();
            this.key = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // en
            // 
            this.en.Location = new System.Drawing.Point(2, 82);
            this.en.Name = "en";
            this.en.Size = new System.Drawing.Size(75, 21);
            this.en.TabIndex = 1;
            this.en.Text = "加密->";
            this.en.UseVisualStyleBackColor = true;
            this.en.Click += new System.EventHandler(this.en_Click);
            // 
            // de
            // 
            this.de.Location = new System.Drawing.Point(261, 82);
            this.de.Name = "de";
            this.de.Size = new System.Drawing.Size(75, 21);
            this.de.TabIndex = 3;
            this.de.Text = "<-解密";
            this.de.UseVisualStyleBackColor = true;
            this.de.Click += new System.EventHandler(this.de_Click);
            // 
            // miwen
            // 
            this.miwen.Location = new System.Drawing.Point(261, 3);
            this.miwen.Multiline = true;
            this.miwen.Name = "miwen";
            this.miwen.Size = new System.Drawing.Size(253, 73);
            this.miwen.TabIndex = 4;
            // 
            // mingwen
            // 
            this.mingwen.Location = new System.Drawing.Point(2, 3);
            this.mingwen.Multiline = true;
            this.mingwen.Name = "mingwen";
            this.mingwen.Size = new System.Drawing.Size(253, 73);
            this.mingwen.TabIndex = 5;
            // 
            // key
            // 
            this.key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.key.Location = new System.Drawing.Point(3, 17);
            this.key.Multiline = true;
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(493, 78);
            this.key.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.key);
            this.groupBox1.Location = new System.Drawing.Point(2, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 98);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "密钥";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 210);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mingwen);
            this.Controls.Add(this.miwen);
            this.Controls.Add(this.de);
            this.Controls.Add(this.en);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button en;
        private System.Windows.Forms.Button de;
        private System.Windows.Forms.TextBox miwen;
        private System.Windows.Forms.TextBox mingwen;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

