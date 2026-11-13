namespace Erronka
{
    partial class FormBezeroa
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
            buttonCheck = new Button();
            buttonJatetxea = new Button();
            buttonZaborra = new Button();
            buttonIzarak = new Button();
            buttonEskuoihalak = new Button();
            buttonMezua = new Button();
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
            panel1.Controls.Add(buttonCheck);
            panel1.Controls.Add(buttonJatetxea);
            panel1.Controls.Add(buttonZaborra);
            panel1.Controls.Add(buttonIzarak);
            panel1.Controls.Add(buttonEskuoihalak);
            panel1.Controls.Add(buttonMezua);
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
            // buttonCheck
            // 
            buttonCheck.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCheck.Location = new Point(1184, 93);
            buttonCheck.Name = "buttonCheck";
            buttonCheck.Size = new Size(224, 90);
            buttonCheck.TabIndex = 6;
            buttonCheck.Text = "Check-out";
            buttonCheck.UseVisualStyleBackColor = true;
            buttonCheck.Click += button6_Click;
            // 
            // buttonJatetxea
            // 
            buttonJatetxea.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonJatetxea.Location = new Point(894, 93);
            buttonJatetxea.Name = "buttonJatetxea";
            buttonJatetxea.Size = new Size(217, 90);
            buttonJatetxea.TabIndex = 5;
            buttonJatetxea.Text = "Jatetxea";
            buttonJatetxea.UseVisualStyleBackColor = true;
            buttonJatetxea.Click += button5_Click;
            // 
            // buttonZaborra
            // 
            buttonZaborra.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonZaborra.Location = new Point(638, 93);
            buttonZaborra.Name = "buttonZaborra";
            buttonZaborra.Size = new Size(197, 90);
            buttonZaborra.TabIndex = 4;
            buttonZaborra.Text = "Zaborra";
            buttonZaborra.UseVisualStyleBackColor = true;
            buttonZaborra.Click += button4_Click;
            // 
            // buttonIzarak
            // 
            buttonIzarak.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonIzarak.Location = new Point(359, 93);
            buttonIzarak.Name = "buttonIzarak";
            buttonIzarak.Size = new Size(186, 90);
            buttonIzarak.TabIndex = 3;
            buttonIzarak.Text = "Izarak";
            buttonIzarak.UseVisualStyleBackColor = true;
            buttonIzarak.Click += button3_Click;
            // 
            // buttonEskuoihalak
            // 
            buttonEskuoihalak.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonEskuoihalak.Location = new Point(118, 93);
            buttonEskuoihalak.Name = "buttonEskuoihalak";
            buttonEskuoihalak.Size = new Size(168, 90);
            buttonEskuoihalak.TabIndex = 2;
            buttonEskuoihalak.Text = "Eskuoihalak";
            buttonEskuoihalak.UseVisualStyleBackColor = true;
            buttonEskuoihalak.Click += button2_Click;
            // 
            // buttonMezua
            // 
            buttonMezua.BackColor = SystemColors.MenuHighlight;
            buttonMezua.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonMezua.Location = new Point(1352, 17);
            buttonMezua.Name = "buttonMezua";
            buttonMezua.Size = new Size(119, 61);
            buttonMezua.TabIndex = 1;
            buttonMezua.Text = "Gehitu +";
            buttonMezua.UseVisualStyleBackColor = false;
            buttonMezua.Click += button1_Click;
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
            // FormBezeroa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 685);
            Controls.Add(panel1);
            Controls.Add(labelIzena);
            Name = "FormBezeroa";
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
        private Button buttonEskuoihalak;
        private Button buttonMezua;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonCheck;
        private Button buttonJatetxea;
        private Button buttonZaborra;
        private Button buttonIzarak;
    }
}