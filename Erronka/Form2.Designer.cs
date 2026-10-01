namespace Erronka
{
    partial class Form2
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
            labelIzena = new Label();
            panel1 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelIzena
            // 
            labelIzena.AutoSize = true;
            labelIzena.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelIzena.Location = new Point(12, 9);
            labelIzena.Name = "labelIzena";
            labelIzena.Size = new Size(90, 37);
            labelIzena.TabIndex = 0;
            labelIzena.Text = "label1";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(-2, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(1483, 636);
            panel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = SystemColors.ButtonHighlight;
            flowLayoutPanel2.Location = new Point(758, 224);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(713, 400);
            flowLayoutPanel2.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ButtonHighlight;
            flowLayoutPanel1.Location = new Point(14, 224);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(705, 400);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(1184, 93);
            button6.Name = "button6";
            button6.Size = new Size(224, 90);
            button6.TabIndex = 6;
            button6.Text = "Check-out";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(894, 93);
            button5.Name = "button5";
            button5.Size = new Size(217, 90);
            button5.TabIndex = 5;
            button5.Text = "Jatetxea";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(638, 93);
            button4.Name = "button4";
            button4.Size = new Size(197, 90);
            button4.TabIndex = 4;
            button4.Text = "Zaborra";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(359, 93);
            button3.Name = "button3";
            button3.Size = new Size(186, 90);
            button3.TabIndex = 3;
            button3.Text = "Izarak";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(118, 93);
            button2.Name = "button2";
            button2.Size = new Size(168, 90);
            button2.TabIndex = 2;
            button2.Text = "Eskuoihalak";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(1352, 17);
            button1.Name = "button1";
            button1.Size = new Size(119, 61);
            button1.TabIndex = 1;
            button1.Text = "Gehitu +";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(14, 17);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1332, 61);
            textBox1.TabIndex = 0;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 685);
            Controls.Add(panel1);
            Controls.Add(labelIzena);
            Name = "Form2";
            Text = "Form2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelIzena;
        private Panel panel1;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
    }
}