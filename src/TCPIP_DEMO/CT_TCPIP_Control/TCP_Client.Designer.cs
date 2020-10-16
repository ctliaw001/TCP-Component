namespace CT_TCPIP_Control
{
    partial class TCP_Client
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_hostname = new System.Windows.Forms.Label();
            this.lb_revice = new System.Windows.Forms.Label();
            this.lb_send = new System.Windows.Forms.Label();
            this.lb_state = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(1, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port: ";
            // 
            // lb_hostname
            // 
            this.lb_hostname.AutoSize = true;
            this.lb_hostname.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_hostname.Location = new System.Drawing.Point(84, 0);
            this.lb_hostname.Name = "lb_hostname";
            this.lb_hostname.Size = new System.Drawing.Size(64, 16);
            this.lb_hostname.TabIndex = 3;
            this.lb_hostname.Text = "localhost";
            // 
            // lb_revice
            // 
            this.lb_revice.AutoSize = true;
            this.lb_revice.BackColor = System.Drawing.Color.Green;
            this.lb_revice.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_revice.ForeColor = System.Drawing.Color.White;
            this.lb_revice.Location = new System.Drawing.Point(83, 68);
            this.lb_revice.Name = "lb_revice";
            this.lb_revice.Size = new System.Drawing.Size(26, 24);
            this.lb_revice.TabIndex = 5;
            this.lb_revice.Text = "O";
            this.lb_revice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_send
            // 
            this.lb_send.AutoSize = true;
            this.lb_send.BackColor = System.Drawing.Color.Green;
            this.lb_send.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_send.ForeColor = System.Drawing.Color.White;
            this.lb_send.Location = new System.Drawing.Point(46, 68);
            this.lb_send.Name = "lb_send";
            this.lb_send.Size = new System.Drawing.Size(26, 24);
            this.lb_send.TabIndex = 6;
            this.lb_send.Text = "O";
            this.lb_send.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.BackColor = System.Drawing.Color.Red;
            this.lb_state.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_state.ForeColor = System.Drawing.Color.White;
            this.lb_state.Location = new System.Drawing.Point(9, 68);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(26, 24);
            this.lb_state.TabIndex = 7;
            this.lb_state.Text = "O";
            this.lb_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_port.Location = new System.Drawing.Point(85, 29);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(24, 16);
            this.lb_port.TabIndex = 8;
            this.lb_port.Text = "22";
            // 
            // TCP_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.lb_send);
            this.Controls.Add(this.lb_revice);
            this.Controls.Add(this.lb_hostname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TCP_Client";
            this.Size = new System.Drawing.Size(185, 100);
            this.Load += new System.EventHandler(this.TCP_Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_hostname;
        private System.Windows.Forms.Label lb_revice;
        private System.Windows.Forms.Label lb_send;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.Label lb_port;
    }
}
