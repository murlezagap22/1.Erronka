namespace Erronka
{
    partial class Form3
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxIzena = new TextBox();
            comboBoxOstatuMota = new ComboBox();
            denyButton = new Button();
            acceptButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(275, 27);
            label1.Name = "label1";
            label1.Size = new Size(225, 49);
            label1.TabIndex = 0;
            label1.Text = "Bezero Berria";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(81, 102);
            label2.Name = "label2";
            label2.Size = new Size(82, 32);
            label2.TabIndex = 1;
            label2.Text = "Izena :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(81, 207);
            label3.Name = "label3";
            label3.Size = new Size(158, 32);
            label3.TabIndex = 2;
            label3.Text = "Ostatu mota :";
            // 
            // textBoxIzena
            // 
            textBoxIzena.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxIzena.Location = new Point(81, 156);
            textBoxIzena.Name = "textBoxIzena";
            textBoxIzena.Size = new Size(624, 35);
            textBoxIzena.TabIndex = 3;
            // 
            // comboBoxOstatuMota
            // 
            comboBoxOstatuMota.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxOstatuMota.FormattingEnabled = true;
            comboBoxOstatuMota.Location = new Point(81, 261);
            comboBoxOstatuMota.Name = "comboBoxOstatuMota";
            comboBoxOstatuMota.Size = new Size(624, 38);
            comboBoxOstatuMota.TabIndex = 4;
            // 
            // denyButton
            // 
            denyButton.BackColor = Color.Red;
            denyButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            denyButton.Location = new Point(119, 349);
            denyButton.Name = "denyButton";
            denyButton.Size = new Size(139, 58);
            denyButton.TabIndex = 5;
            denyButton.Text = "Ezeztatu";
            denyButton.UseVisualStyleBackColor = false;
            denyButton.Click += denyButton_Click;
            // 
            // acceptButton
            // 
            acceptButton.BackColor = Color.Lime;
            acceptButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            acceptButton.Location = new Point(496, 349);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(139, 58);
            acceptButton.TabIndex = 6;
            acceptButton.Text = "Gorde";
            acceptButton.UseVisualStyleBackColor = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(acceptButton);
            Controls.Add(denyButton);
            Controls.Add(comboBoxOstatuMota);
            Controls.Add(textBoxIzena);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxIzena;
        private ComboBox comboBoxOstatuMota;
        private Button denyButton;
        private Button acceptButton;
    }
}