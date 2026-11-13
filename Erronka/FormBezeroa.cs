using Erronka.modeloak;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Erronka
{
    public partial class FormBezeroa : Form
    {
        private FormPrintzipala formulario1;
        private Bezeroa bezeroHautatua;

        public FormBezeroa(FormPrintzipala form, Bezeroa bezeroa)
        {
            InitializeComponent();

            // Hasierako form-aren istantzia gorde
            formulario1 = form;
            bezeroHautatua = bezeroa;

            labelIzena.Text = "Bezeroa: " + bezeroHautatua.Izena;

            // Funtzioei datuak pasatu
            ErakutsiMezuak(bezeroHautatua.Mezuak);
            showAtasakBezero();
        }

        // Mezuak erakusteko funtzioa
        public void ErakutsiMezuak(List<Mezua> mezuakJasota)
        {
            flowLayoutPanel2.Controls.Clear();

            if (mezuakJasota == null) return;

            for (int i = 0; i < mezuakJasota.Count; i++)
            {
                Mezua mezua = mezuakJasota[i];

                // Ezabatuak dauden mezuak kendu (bool denez, zuzenean egiaztatu)
                if (mezua.Ezabatuta || mezua.EzabatutaAdmin)
                    continue;

                // Zein mezu den jakitzeko aldagaia
                int indizea = i;

                Panel panelMezuak = new Panel
                {
                    Width = flowLayoutPanel2.ClientSize.Width - 25,
                    Height = 75,
                    BorderStyle = BorderStyle.FixedSingle,
                    // Osatuta badago LightGreen, bestela White
                    BackColor = mezua.Osatuta ? Color.LightGreen : Color.White
                };

                Label labelTarea = new Label
                {
                    Text = mezua.Testua,
                    Location = new Point(10, 10),
                    AutoSize = true,
                    Font = new Font(this.Font, FontStyle.Bold)
                };

                Label labelBezeroa = new Label
                {
                    Text = "Bezero: " + bezeroHautatua.Izena, // Bezeroaren izena objetutik atera
                    Location = new Point(10, 45),
                    AutoSize = true
                };

                panelMezuak.Controls.Add(labelTarea);
                panelMezuak.Controls.Add(labelBezeroa);

                // Ekintza berdinak mantentzen ditugu indizearekin
                panelMezuak.Click += (s, e) => mezuaKudeatu(indizea);
                labelTarea.Click += (s, e) => mezuaKudeatu(indizea);
                labelBezeroa.Click += (s, e) => mezuaKudeatu(indizea);

                flowLayoutPanel2.Controls.Add(panelMezuak);
            }
        }

        // Mezuak kudeatzeko funtzioa
        private void mezuaKudeatu(int indice)
        {
            // Mezua indizetik atera
            Mezua mezua = bezeroHautatua.Mezuak[indice];

            // Ezabatuta dagoenean ezer ez egin
            if (mezua.Ezabatuta)
                return;

            // Ez badago irakurrita / osatuta, irakurrita gisa jarri
            if (!mezua.Osatuta)
            {
                mezua.Osatuta = true;

                // Bista berriro kargatu bezeroaren mezuak pasatuz
                ErakutsiMezuak(bezeroHautatua.Mezuak);
                formulario1.showMezuak();
            }
            else
            {
                // Irakurrita badago, ezabatzeko baieztapena erakutsi
                DialogResult resultado = MessageBox.Show(
                    "¿Mezua ezabatu nahi duzu?\n\n" + mezua.Testua,
                    "Mezua ezabatu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Ezabaketa logikoa (propietatea true jarri)
                    mezua.Ezabatuta = true;

                    // Bista berriro kargatu
                    ErakutsiMezuak(bezeroHautatua.Mezuak);
                    formulario1.showMezuak();
                }
            }
        }

        // Atasak ikustarazteko funtzioa
        public void showAtasakBezero()
        {
            flowLayoutPanel1.Controls.Clear();

            // Bezero bakoitzaren Atasak zerrenda zeharkatu
            foreach (Atasa atasa in bezeroHautatua.Atasak)
            {
                Panel panelTarea = new Panel
                {
                    Width = flowLayoutPanel1.ClientSize.Width - 8,
                    Height = 75,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = atasa // Atasa objetua panelean gorde
                };

                Label labelTarea = new Label
                {
                    Text = atasa.Testua,
                    Location = new Point(10, 10),
                    AutoSize = true,
                    Font = new Font(this.Font, FontStyle.Bold)
                };

                Label labelBezeroa = new Label
                {
                    Text = "Bezero: " + bezeroHautatua.Izena,
                    Location = new Point(10, 45),
                    AutoSize = true
                };

                Label labelLangilea = new Label
                {
                    Text = "Langilea:",
                    Location = new Point(180, 45),
                    AutoSize = true
                };

                TextBox inputLangile = new TextBox
                {
                    Text = atasa.Langilea,
                    Location = new Point(250, 42),
                    Width = 150,
                    ReadOnly = true
                };

                // Lana amaitzean "Eginda" erakutsiko duen Label-a
                Label labelEginda = new Label
                {
                    Text = atasa.Eginda ? "EGINDA" : "",
                    Location = new Point(450, 40),
                    Size = new Size(200, 30),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = atasa.Eginda ? Color.Green : Color.Black
                };

                // Kontrolak panelean sartu
                panelTarea.Controls.Add(labelTarea);
                panelTarea.Controls.Add(labelBezeroa);
                panelTarea.Controls.Add(labelLangilea);
                panelTarea.Controls.Add(inputLangile);
                panelTarea.Controls.Add(labelEginda);

                flowLayoutPanel1.Controls.Add(panelTarea);
            }

        }

        // Mezua gehitzeko botoiaren funtzionamendua
        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Sartu mezu bat bezeroari bidaltzeko");
                return;
            }

            bezeroHautatua.Mezuak.Add(new Mezua(text, osatuta: false, ezabatuta: false));

            ErakutsiMezuak(bezeroHautatua.Mezuak);
            formulario1.showMezuak();

            textBox1.Clear();
        }

        // Eskuoihalak atasa gehitzeko botoiaren funtzionamendua
        private void button2_Click(object sender, EventArgs e)
        {
            // Atasa berria sortu eta bezeroaren zerrendan sartu
            Atasa atasaBerria = new Atasa("Eskuoihalak", langilea: "", eginda: false);
            bezeroHautatua.Atasak.Add(atasaBerria);
            showAtasakBezero();
            // Form1-eko interfazea eguneratu atasa berria erakusteko
            if (formulario1 != null && !formulario1.IsDisposed)
            {
                formulario1.showAtasak();
                formulario1.validateLanaldia();
            }

        }

        // Izarak botoia
        private void button3_Click(object sender, EventArgs e)
        {
            // Atasa berria sortu eta bezeroaren zerrendan sartu
            Atasa atasaBerria = new Atasa("Izarak", langilea: "", eginda: false);
            bezeroHautatua.Atasak.Add(atasaBerria);
            showAtasakBezero();
            // Form1-eko interfazea eguneratu atasa berria erakusteko
            if (formulario1 != null && !formulario1.IsDisposed)
            {
                formulario1.showAtasak();
                formulario1.validateLanaldia();
            }

        }

        // Zaborra botoia
        private void button4_Click(object sender, EventArgs e)
        {
            // Atasa berria sortu eta bezeroaren zerrendan sartu
            Atasa atasaBerria = new Atasa("Zaborra", langilea: "", eginda: false);
            bezeroHautatua.Atasak.Add(atasaBerria);
            showAtasakBezero();
            // Form1-eko interfazea eguneratu atasa berria erakusteko
            if (formulario1 != null && !formulario1.IsDisposed)
            {
                formulario1.showAtasak();
                formulario1.validateLanaldia();
            }

        }

        // Jatetxea botoia
        private void button5_Click(object sender, EventArgs e)
        {
            // Atasa berria sortu eta bezeroaren zerrendan sartu
            Atasa atasaBerria = new Atasa("Jatetxea", langilea: "", eginda: false);
            bezeroHautatua.Atasak.Add(atasaBerria);
            showAtasakBezero();
            // Form1-eko interfazea eguneratu atasa berria erakusteko
            if (formulario1 != null && !formulario1.IsDisposed)
            {
                formulario1.showAtasak();
                formulario1.validateLanaldia();
            }

        }

        // Form ixteko
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

