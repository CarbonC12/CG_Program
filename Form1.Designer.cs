namespace CG_Program
{
    partial class CG_Win
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
            this.Tab_Draw = new System.Windows.Forms.TabControl();
            this.Tab_Line = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.Tab_Draw.SuspendLayout();
            this.Tab_Line.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab_Draw
            // 
            this.Tab_Draw.Controls.Add(this.Tab_Line);
            this.Tab_Draw.Controls.Add(this.tabPage2);
            this.Tab_Draw.Location = new System.Drawing.Point(0, 0);
            this.Tab_Draw.Margin = new System.Windows.Forms.Padding(0);
            this.Tab_Draw.Name = "Tab_Draw";
            this.Tab_Draw.SelectedIndex = 0;
            this.Tab_Draw.Size = new System.Drawing.Size(671, 405);
            this.Tab_Draw.TabIndex = 0;
            // 
            // Tab_Line
            // 
            this.Tab_Line.Controls.Add(this.label1);
            this.Tab_Line.Controls.Add(this.button2);
            this.Tab_Line.Controls.Add(this.groupBox1);
            this.Tab_Line.Controls.Add(this.button1);
            this.Tab_Line.Location = new System.Drawing.Point(4, 26);
            this.Tab_Line.Margin = new System.Windows.Forms.Padding(0);
            this.Tab_Line.Name = "Tab_Line";
            this.Tab_Line.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Line.Size = new System.Drawing.Size(663, 375);
            this.Tab_Line.TabIndex = 0;
            this.Tab_Line.Text = "线条绘制";
            this.Tab_Line.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(663, 353);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupBox1_Paint);
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            this.groupBox1.MouseHover += new System.EventHandler(this.GroupBox1_MouseHover);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(663, 375);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(302, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "绘制区";
            // 
            // CG_Win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 406);
            this.Controls.Add(this.Tab_Draw);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CG_Win";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算机图形学测试系统";
            this.Load += new System.EventHandler(this.CG_Win_Load);
            this.Tab_Draw.ResumeLayout(false);
            this.Tab_Line.ResumeLayout(false);
            this.Tab_Line.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tab_Draw;
        private System.Windows.Forms.TabPage Tab_Line;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        public int S_x, S_y, E_x, E_y;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

