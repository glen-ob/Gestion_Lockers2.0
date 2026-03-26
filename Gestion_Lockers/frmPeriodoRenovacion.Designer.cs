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
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(227, 42);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(240, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(128, 9);
            label1.Name = "label1";
            label1.Size = new Size(467, 30);
            label1.TabIndex = 1;
            label1.Text = "Elija la fecha del fin de la renovacion:";
            // 
            // button1
            // 
            button1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(128, 107);
            button1.Name = "button1";
            button1.Size = new Size(170, 71);
            button1.TabIndex = 2;
            button1.Text = "Iniciar Renovacion";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(425, 107);
            button2.Name = "button2";
            button2.Size = new Size(170, 71);
            button2.TabIndex = 3;
            button2.Text = "Cerrar";
            button2.UseVisualStyleBackColor = true;
            // 
            // frmPeriodoRenovacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 257);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Name = "frmPeriodoRenovacion";
            Text = "Renovacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}