using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Erronka
{
    public partial class Form3 : Form
    {
        // Form1 eko erreferntzia hasi honetako funtzioak eta aldagaiak erabili ahal izateko
        private Form1 formulario1;

        public Form3(Form1 form)
        {
            InitializeComponent();

            formulario1 = form;

            // Ostatuen combobox-a datuekin bete
            string[,] ostatuak =
            {
                { "1", "Denda" },
                { "2", "Autokarabana" },
                { "3", "Bungalow" }
            };

            for (int i = 0; i < ostatuak.GetLength(0); i++)
            {
                comboBoxOstatuMota.Items.Add(ostatuak[i, 1]);
            }

            comboBoxOstatuMota.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            // Duen formulario ixteko
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Bezero berriaren datuak hartu eta Form1-eko funtziora bidali honek gehitu ahal izateko
            string izena = textBoxIzena.Text.Trim();

            // Baldintzak izena datuekin egoteko
            if (string.IsNullOrWhiteSpace(izena))
            {
                MessageBox.Show("Sartu bezeroaren izena.");
                return;
            }

            string ostatuMota =
                (comboBoxOstatuMota.SelectedIndex + 1).ToString();

            // Form1 eko funtzioa eta parametroak pasatu
            formulario1.BezeroaGehitu(izena, ostatuMota);

            this.Close();
        }
    }
}
