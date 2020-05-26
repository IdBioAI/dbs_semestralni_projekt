namespace dbs_semestralka
{
    partial class Graf
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.buttonShow = new System.Windows.Forms.Button();
            this.chartTenzo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBaterie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStav = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTenzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBaterie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStav)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(249, 315);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(248, 26);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(550, 315);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(248, 26);
            this.dateTimePicker3.TabIndex = 2;
            this.dateTimePicker3.ValueChanged += new System.EventHandler(this.DateTimePicker3_ValueChanged);
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonShow.Enabled = false;
            this.buttonShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonShow.ForeColor = System.Drawing.Color.White;
            this.buttonShow.Location = new System.Drawing.Point(9, 374);
            this.buttonShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(125, 36);
            this.buttonShow.TabIndex = 8;
            this.buttonShow.Text = "Zobrazit";
            this.buttonShow.UseVisualStyleBackColor = false;
            this.buttonShow.Click += new System.EventHandler(this.ButtonShow_Click);
            // 
            // chartTenzo
            // 
            chartArea4.Name = "ChartArea1";
            this.chartTenzo.ChartAreas.Add(chartArea4);
            legend3.Name = "Legend1";
            legend3.Title = "Tenzometry";
            this.chartTenzo.Legends.Add(legend3);
            this.chartTenzo.Location = new System.Drawing.Point(148, 344);
            this.chartTenzo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartTenzo.Name = "chartTenzo";
            this.chartTenzo.Size = new System.Drawing.Size(650, 216);
            this.chartTenzo.TabIndex = 9;
            this.chartTenzo.Text = "chart1";
            this.chartTenzo.Click += new System.EventHandler(this.ChartTenzo_Click);
            // 
            // chartBaterie
            // 
            chartArea5.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea5.AxisY.Title = "Baterie [%]";
            chartArea5.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            chartArea5.Name = "ChartArea1";
            this.chartBaterie.ChartAreas.Add(chartArea5);
            this.chartBaterie.Location = new System.Drawing.Point(370, 10);
            this.chartBaterie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartBaterie.Name = "chartBaterie";
            series3.ChartArea = "ChartArea1";
            series3.IsVisibleInLegend = false;
            series3.Name = "Series1";
            this.chartBaterie.Series.Add(series3);
            this.chartBaterie.Size = new System.Drawing.Size(428, 298);
            this.chartBaterie.TabIndex = 10;
            this.chartBaterie.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "7 nejslabších baterií";
            this.chartBaterie.Titles.Add(title2);
            this.chartBaterie.Click += new System.EventHandler(this.Chart2_Click);
            // 
            // chartStav
            // 
            chartArea6.Name = "ChartArea1";
            this.chartStav.ChartAreas.Add(chartArea6);
            legend4.Name = "Legend1";
            legend4.Title = "Stav všech strojů";
            this.chartStav.Legends.Add(legend4);
            this.chartStav.Location = new System.Drawing.Point(9, 50);
            this.chartStav.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartStav.Name = "chartStav";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Stav";
            this.chartStav.Series.Add(series4);
            this.chartStav.Size = new System.Drawing.Size(345, 258);
            this.chartStav.TabIndex = 11;
            this.chartStav.Text = "chart3";
            this.chartStav.Click += new System.EventHandler(this.ChartStav_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(229, 10);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(125, 36);
            this.buttonRefresh.TabIndex = 13;
            this.buttonRefresh.Text = "Aktualizovat";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 316);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 28);
            this.comboBox1.TabIndex = 100;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(4, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 25);
            this.label8.TabIndex = 102;
            this.label8.Text = "Aktuální stav strojů";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(200, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 25);
            this.label1.TabIndex = 103;
            this.label1.Text = "Od:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(502, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 104;
            this.label2.Text = "Do:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(10, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 105;
            this.label3.Text = "Stroj";
            // 
            // Graf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 583);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.chartStav);
            this.Controls.Add(this.chartBaterie);
            this.Controls.Add(this.chartTenzo);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Graf";
            this.Text = "graf";
            this.Load += new System.EventHandler(this.Graf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTenzo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBaterie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStav)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTenzo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBaterie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStav;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}