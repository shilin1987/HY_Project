
namespace WindowsFormsApp1
{
    partial class Transfer_wts
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
            this.开始同步 = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 开始同步
            // 
            this.开始同步.Location = new System.Drawing.Point(100, 35);
            this.开始同步.Name = "开始同步";
            this.开始同步.Size = new System.Drawing.Size(147, 74);
            this.开始同步.TabIndex = 0;
            this.开始同步.Text = "开始迁移";
            this.开始同步.UseVisualStyleBackColor = true;
            this.开始同步.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 129);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(1075, 482);
            this.txtInfo.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(734, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 74);
            this.button2.TabIndex = 2;
            this.button2.Text = "劳勤接口测试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Transfer_wts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 623);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.开始同步);
            this.Name = "Transfer_wts";
            this.Text = "劳勤用户信息迁移";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 开始同步;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button button2;
    }
}

