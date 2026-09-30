namespace Erronka
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flowLayoutPanelBotoiak = new FlowLayoutPanel();
            AddClient = new Button();
            panel1 = new Panel();
            textBoxMensaje = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            AddText = new Button();
            panel2 = new Panel();
            flowLayoutPanelTasks = new FlowLayoutPanel();
            panel3 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            gameButton = new Button();
            panel4 = new Panel();
            flowLayoutPanelWorkers = new FlowLayoutPanel();
            btnHasiLanaldia = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelBotoiak
            // 
            flowLayoutPanelBotoiak.AutoScroll = true;
            flowLayoutPanelBotoiak.Location = new Point(0, 0);
            flowLayoutPanelBotoiak.Name = "flowLayoutPanelBotoiak";
            flowLayoutPanelBotoiak.Size = new Size(1423, 159);
            flowLayoutPanelBotoiak.TabIndex = 0;
            // 
            // AddClient
            // 
            AddClient.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddClient.ImageAlign = ContentAlignment.MiddleRight;
            AddClient.Location = new Point(1429, 12);
            AddClient.Name = "AddClient";
            AddClient.Size = new Size(112, 101);
            AddClient.TabIndex = 1;
            AddClient.Text = "+";
            AddClient.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(textBoxMensaje);
            panel1.Location = new Point(0, 159);
            panel1.Name = "panel1";
            panel1.Size = new Size(1423, 74);
            panel1.TabIndex = 2;
            // 
            // textBoxMensaje
            // 
            textBoxMensaje.AccessibleRole = AccessibleRole.TitleBar;
            textBoxMensaje.Location = new Point(12, 12);
            textBoxMensaje.Multiline = true;
            textBoxMensaje.Name = "textBoxMensaje";
            textBoxMensaje.Size = new Size(1391, 50);
            textBoxMensaje.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // AddText
            // 
            AddText.Location = new Point(1429, 171);
            AddText.Name = "AddText";
            AddText.Size = new Size(112, 50);
            AddText.TabIndex = 5;
            AddText.Text = "Bidali Mezua";
            AddText.UseVisualStyleBackColor = true;
            AddText.Click += AddText_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(flowLayoutPanelTasks);
            panel2.Location = new Point(0, 233);
            panel2.Name = "panel2";
            panel2.Size = new Size(626, 570);
            panel2.TabIndex = 6;
            // 
            // flowLayoutPanelTasks
            // 
            flowLayoutPanelTasks.AutoScroll = true;
            flowLayoutPanelTasks.BackColor = SystemColors.ButtonHighlight;
            flowLayoutPanelTasks.Location = new Point(22, 23);
            flowLayoutPanelTasks.Name = "flowLayoutPanelTasks";
            flowLayoutPanelTasks.Size = new Size(583, 518);
            flowLayoutPanelTasks.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(flowLayoutPanel2);
            panel3.Location = new Point(632, 233);
            panel3.Name = "panel3";
            panel3.Size = new Size(728, 570);
            panel3.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = SystemColors.ControlLightLight;
            flowLayoutPanel2.Location = new Point(27, 23);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(679, 518);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // gameButton
            // 
            gameButton.BackColor = SystemColors.ActiveCaption;
            gameButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gameButton.Location = new Point(489, 809);
            gameButton.Name = "gameButton";
            gameButton.Size = new Size(276, 54);
            gameButton.TabIndex = 8;
            gameButton.Text = "Bideojokoa";
            gameButton.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLight;
            panel4.Controls.Add(btnHasiLanaldia);
            panel4.Controls.Add(flowLayoutPanelWorkers);
            panel4.Location = new Point(1366, 233);
            panel4.Name = "panel4";
            panel4.Size = new Size(175, 570);
            panel4.TabIndex = 9;
            // 
            // flowLayoutPanelWorkers
            // 
            flowLayoutPanelWorkers.BackColor = SystemColors.ButtonHighlight;
            flowLayoutPanelWorkers.Location = new Point(23, 23);
            flowLayoutPanelWorkers.Name = "flowLayoutPanelWorkers";
            flowLayoutPanelWorkers.Size = new Size(130, 456);
            flowLayoutPanelWorkers.TabIndex = 0;
            // 
            // btnHasiLanaldia
            // 
            btnHasiLanaldia.BackColor = SystemColors.MenuHighlight;
            btnHasiLanaldia.Location = new Point(23, 485);
            btnHasiLanaldia.Name = "btnHasiLanaldia";
            btnHasiLanaldia.Size = new Size(130, 56);
            btnHasiLanaldia.TabIndex = 1;
            btnHasiLanaldia.Text = "Hasi lanaldia";
            btnHasiLanaldia.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1553, 875);
            Controls.Add(panel4);
            Controls.Add(gameButton);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(AddText);
            Controls.Add(panel1);
            Controls.Add(AddClient);
            Controls.Add(flowLayoutPanelBotoiak);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelBotoiak;
        private Button AddClient;
        private Panel panel1;
        private TextBox textBoxMensaje;
        private ContextMenuStrip contextMenuStrip1;
        private Button AddText;
        private Panel panel2;
        private Panel panel3;
        private FlowLayoutPanel flowLayoutPanelTasks;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button gameButton;
        private Panel panel4;
        private FlowLayoutPanel flowLayoutPanelWorkers;
        private Button btnHasiLanaldia;
    }
}
