namespace CT_TCPIP_Control
{
    partial class TCP_Server
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
            this.lb_port = new System.Windows.Forms.Label();
            this.lb_state = new System.Windows.Forms.Label();
            this.lb_Connected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port : ";
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_port.Location = new System.Drawing.Point(77, 19);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(27, 19);
            this.lb_port.TabIndex = 1;
            this.lb_port.Text = "22";
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.BackColor = System.Drawing.Color.Red;
            this.lb_state.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_state.ForeColor = System.Drawing.Color.White;
            this.lb_state.Location = new System.Drawing.Point(16, 54);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(26, 24);
            this.lb_state.TabIndex = 8;
            this.lb_state.Text = "O";
            this.lb_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Connected
            // 
            this.lb_Connected.AutoSize = true;
            this.lb_Connected.Location = new System.Drawing.Point(48, 63);
            this.lb_Connected.Name = "lb_Connected";
            this.lb_Connected.Size = new System.Drawing.Size(50, 12);
            this.lb_Connected.TabIndex = 9;
            this.lb_Connected.Text = "0,0,0,0  1";
            // 
            // TCP_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lb_Connected);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.label1);
            this.Name = "TCP_Server";
            this.Size = new System.Drawing.Size(183, 98);
            this.Load += new System.EventHandler(this.TCP_Server_Load);
            this.Leave += new System.EventHandler(this.TCP_Server_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.Label lb_Connected;
    }
}
