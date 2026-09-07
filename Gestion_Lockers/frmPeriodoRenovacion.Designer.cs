namespace Gestion_Lockers
{
    partial class frmPeriodoRenovacion
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
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.CalendarForeColor = SystemColors.ButtonHighlight;
            dateTimePicker1.CalendarMonthBackground = Color.MidnightBlue;
            dateTimePicker1.CalendarTitleBackColor = SystemColors.ButtonHighlight;
            dateTimePicker1.CalendarTitleForeColor = Color.MidnightBlue;
            dateTimePicker1.CalendarTrailingForeColor = Color.SteelBlue;
            dateTimePicker1.Location = new Point(294, 121);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(273, 27);
            dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(150, 45);
            label1.Name = "label1";
            label1.Size = new Size(561, 37);
            label1.TabIndex = 1;
            label1.Text = "Elija la fecha del fin de la renovacion:";
            // 
            // button1
            // 
            button1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(150, 201);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(256, 95);
            button1.TabIndex = 2;
            button1.Text = "Iniciar Renovacion";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(455, 201);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(256, 95);
            button2.TabIndex = 3;
            button2.Text = "Cerrar";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(843, 343);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // frmPeriodoRenovacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(843, 343);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmPeriodoRenovacion";
            Text = "Renovacion";
            Load += frmPeriodoRenovacion_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
    }
}