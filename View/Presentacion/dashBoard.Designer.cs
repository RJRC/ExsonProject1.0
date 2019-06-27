namespace View.Presentacion
{
    partial class dashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_salesPerMonth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bt_close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_showTotalSales = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_salesPerMonth)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_salesPerMonth
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_salesPerMonth.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_salesPerMonth.Legends.Add(legend2);
            this.chart_salesPerMonth.Location = new System.Drawing.Point(32, 26);
            this.chart_salesPerMonth.Name = "chart_salesPerMonth";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Total ventas";
            this.chart_salesPerMonth.Series.Add(series2);
            this.chart_salesPerMonth.Size = new System.Drawing.Size(396, 164);
            this.chart_salesPerMonth.TabIndex = 0;
            this.chart_salesPerMonth.Text = "salesPerMonth";
            // 
            // bt_close
            // 
            this.bt_close.FlatAppearance.BorderSize = 0;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_close.ForeColor = System.Drawing.Color.White;
            this.bt_close.Location = new System.Drawing.Point(32, 396);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(87, 30);
            this.bt_close.TabIndex = 1;
            this.bt_close.Text = "Cerrar";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_generate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_showTotalSales);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(463, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 100);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total ventas: ";
            // 
            // lb_showTotalSales
            // 
            this.lb_showTotalSales.AutoSize = true;
            this.lb_showTotalSales.Location = new System.Drawing.Point(108, 21);
            this.lb_showTotalSales.Name = "lb_showTotalSales";
            this.lb_showTotalSales.Size = new System.Drawing.Size(0, 13);
            this.lb_showTotalSales.TabIndex = 1;
            this.lb_showTotalSales.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.chart_salesPerMonth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dashBoard";
            this.Text = "dashBoard";
            ((System.ComponentModel.ISupportInitialize)(this.chart_salesPerMonth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_salesPerMonth;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_showTotalSales;
        private System.Windows.Forms.Label label1;
    }
}