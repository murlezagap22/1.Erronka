using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Erronka
{
    public partial class Form2 : Form
    {
        private Form1 formulario1;
        private string[,] mezuak;
        private string bezeroIzena;

        public Form2(Form1 form, string id, string nombre, string[,] mensajes)
        {
            InitializeComponent();

            formulario1 = form;
            bezeroIzena = nombre;
            mezuak = mensajes;

            labelIzena.Text = "Bezeroa: " + nombre;

            ErakutsiMezuak();
        }

        private void ErakutsiMezuak()
        {
            flowLayoutPanel2.Controls.Clear();

            for (int i = 0; i < mezuak.GetLength(0); i++)
            {
                // Ezabatuak dauden mezuak kendu
                if (mezuak[i, 3] == "1")
                    continue;

                // Beste bezero batzuen mezuak kendu
                if (mezuak[i, 0] != bezeroIzena)
                    continue;

                int indizea = i;

                Panel panelMezuak = new Panel();

                panelMezuak.Width = flowLayoutPanel2.ClientSize.Width - 8;
                panelMezuak.Height = 75;
                panelMezuak.BorderStyle = BorderStyle.FixedSingle;

                if (mezuak[i, 2] == "1")
                    panelMezuak.BackColor = Color.LightGreen;
                else
                    panelMezuak.BackColor = Color.White;

                Label labelTarea = new Label();
                labelTarea.Text = mezuak[i, 1];
                labelTarea.Location = new Point(10, 10);
                labelTarea.AutoSize = true;
                labelTarea.Font = new Font(labelTarea.Font, FontStyle.Bold);

                Label labelBezeroa = new Label();
                labelBezeroa.Text = "Bezero: " + mezuak[i, 0];
                labelBezeroa.Location = new Point(10, 45);
                labelBezeroa.AutoSize = true;

                panelMezuak.Controls.Add(labelTarea);
                panelMezuak.Controls.Add(labelBezeroa);

                panelMezuak.Click += (s, e) => mezuaKudeatu(indizea);
                labelTarea.Click += (s, e) => mezuaKudeatu(indizea);
                labelBezeroa.Click += (s, e) => mezuaKudeatu(indizea);

                flowLayoutPanel2.Controls.Add(panelMezuak);
            }
        }

        private void mezuaKudeatu(int indice)
        {
            // Ezabatuta dagoenean ezer egin
            if (mezuak[indice, 3] == "1")
                return;

            // Ez badago irakurrita, irakurrita dagoela jarri
            if (mezuak[indice, 2] == "0")
            {
                mezuak[indice, 2] = "1";

                ErakutsiMezuak();
            }
            else
            {
                // Irakurrita badago, ezabatzeko baieztapena erakutsi

                DialogResult resultado = MessageBox.Show(
                    "¿Mezua ezabatu nahi duzu?\n\n" + mezuak[indice, 1],
                    "Mezua ezabatu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Ezabaketa logikoa bezeroko aldetik kudeatu ahal izateko
                    mezuak[indice, 3] = "1";

                    ErakutsiMezuak();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Sartu mezu bat bezeroari bidaltzeko");
                return;
            }

            mezuak = formulario1.MezuaGehitu(mezuak, bezeroIzena, text);

            ErakutsiMezuak();

            textBox1.Clear();
        }
    }
}
