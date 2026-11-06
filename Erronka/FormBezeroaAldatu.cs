using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Erronka
{
    public partial class FormBezeroaAldatu : Form
    {
        private FormPrintzipala formulario1;
        private string bezeroId;

        public FormBezeroaAldatu(FormPrintzipala form, string id, string izena, string ostatuMota)
        {
            InitializeComponent();

            formulario1 = form;
            bezeroId = id;

            // Bezeroaren datuak erakutsi
            textBox1.Text = izena;
            textBox2.Text = bezeroId;
            textBox2.ReadOnly = true;
            comboBox1.SelectedIndex = int.Parse(ostatuMota) - 1;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form4_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string izena = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(izena))
            {
                MessageBox.Show("Sartu bezeroaren izena.");
                return;
            }

            string ostatuMota =
                (comboBox1.SelectedIndex + 1).ToString();

            formulario1.BezeroaEguneratu(bezeroId, izena, ostatuMota);

            this.Close();
        }
    }
}
