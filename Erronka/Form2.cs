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
        private Bezeroa bezeroHautatua;

        public Form2(Form1 form, Bezeroa bezeroa)
        {
            InitializeComponent();

            formulario1 = form;
            bezeroHautatua = bezeroa; // Guardamos el objeto recibido

            // Accedemos directamente a las propiedades del objeto
            labelIzena.Text = "Bezeroa: " + bezeroHautatua.Izena;

            // Le pasamos su lista de mensajes directamente a la función
            ErakutsiMezuak(bezeroHautatua.Mezuak);
            showAtasakBezero();
        }

        public void ErakutsiMezuak(List<Mezua> mezuakJasota)
        {
            flowLayoutPanel2.Controls.Clear();

            if (mezuakJasota == null) return;

            // Usamos un bucle for tradicional para conservar el índice del mensaje
            for (int i = 0; i < mezuakJasota.Count; i++)
            {
                Mezua mezua = mezuakJasota[i];

                // 1. Ezabatuak dauden mezuak kendu (bool denez, zuzenean egiaztatu)
                if (mezua.Ezabatuta || mezua.EzabatutaAdmin)
                    continue;

                int indizea = i;

                Panel panelMezuak = new Panel
                {
                    Width = flowLayoutPanel2.ClientSize.Width - 25, // Margen para evitar scrollbar horizontal
                    Height = 75,
                    BorderStyle = BorderStyle.FixedSingle,
                    // 2. Osatuta badago LightGreen, bestela White
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
                    Text = "Bezero: " + bezeroHautatua.Izena, // Bezeroaren izena objetutik
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

        private void mezuaKudeatu(int indice)
        {
            // Obtener la instancia directa del mensaje
            Mezua mezua = bezeroHautatua.Mezuak[indice];

            // 1. Ezabatuta dagoenean ezer ez egin
            if (mezua.Ezabatuta)
                return;

            // 2. Ez badago irakurrita / osatuta, irakurrita gisa jarri
            if (!mezua.Osatuta)
            {
                mezua.Osatuta = true;

                // Bista berriro kargatu bezeroaren mezuak pasatuz
                ErakutsiMezuak(bezeroHautatua.Mezuak);
                formulario1.showMezuak();
            }
            else
            {
                // 3. Irakurrita badago, ezabatzeko baieztapena erakutsi
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

        public void showAtasakBezero()
        {
            flowLayoutPanel1.Controls.Clear();

                // 2. Bezero bakoitzaren Atasak zerrenda zeharkatu
                foreach (Atasa atasa in bezeroHautatua.Atasak)
                {
                    Panel panelTarea = new Panel
                    {
                        Width = flowLayoutPanel1.ClientSize.Width - 8,
                        Height = 75,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = atasa // Atasa objetua panelean gordetzen dugu
                    };

                    // Honen testua definitu
                    Label labelTarea = new Label
                    {
                        Text = atasa.Testua,
                        Location = new Point(10, 10),
                        AutoSize = true,
                        Font = new Font(this.Font, FontStyle.Bold)
                    };

                    // Bezeroaren izena erakutsi
                    Label labelBezeroa = new Label
                    {
                        Text = "Bezero: " + bezeroHautatua.Izena,
                        Location = new Point(10, 45),
                        AutoSize = true
                    };

                    // Langilearen goiko testua definitu
                    Label labelLangilea = new Label
                    {
                        Text = "Langilea:",
                        Location = new Point(180, 45),
                        AutoSize = true
                    };

                    // Langilearen izena gordeko duen input-a definitu
                    TextBox inputLangile = new TextBox
                    {
                        Text = atasa.Langilea, // Objetuko langilea erakutsi
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


        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Sartu mezu bat bezeroari bidaltzeko");
                return;
            }

            // 1. Crear y añadir el nuevo objeto Mezua a la lista del cliente actual
            bezeroHautatua.Mezuak.Add(new Mezua(text, osatuta: false, ezabatuta: false));

            // 2. Refrescar la vista local en Form2 pasándole la lista actualizada
            ErakutsiMezuak(bezeroHautatua.Mezuak);
            formulario1.showMezuak();

            // 3. Limpiar el cuadro de texto
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 2. Atasa berria sortu eta bezeroaren zerrendan sartu
            Atasa atasaBerria = new Atasa("Eskuoihalak", langilea: "", eginda: false);
            bezeroHautatua.Atasak.Add(atasaBerria);
            showAtasakBezero();
            // 3. Form1-eko interfazea eguneratu atasa berria erakusteko
            if (formulario1 != null && !formulario1.IsDisposed)
            {
                formulario1.showAtasak();
                formulario1.validateLanaldia();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 2. Atasa berria sortu eta bezeroaren zerrendan sartu
            Atasa atasaBerria = new Atasa("Izarak", langilea: "", eginda: false);
            bezeroHautatua.Atasak.Add(atasaBerria);
            showAtasakBezero();
            // 3. Form1-eko interfazea eguneratu atasa berria erakusteko
            if (formulario1 != null && !formulario1.IsDisposed)
            {
                formulario1.showAtasak();
                formulario1.validateLanaldia();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 2. Atasa berria sortu eta bezeroaren zerrendan sartu
            Atasa atasaBerria = new Atasa("Zaborra", langilea: "", eginda: false);
            bezeroHautatua.Atasak.Add(atasaBerria);
            showAtasakBezero();
            // 3. Form1-eko interfazea eguneratu atasa berria erakusteko
            if (formulario1 != null && !formulario1.IsDisposed)
            {
                formulario1.showAtasak();
                formulario1.validateLanaldia();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 2. Atasa berria sortu eta bezeroaren zerrendan sartu
            Atasa atasaBerria = new Atasa("Jatetxea", langilea: "", eginda: false);
            bezeroHautatua.Atasak.Add(atasaBerria);
            showAtasakBezero();
            // 3. Form1-eko interfazea eguneratu atasa berria erakusteko
            if (formulario1 != null && !formulario1.IsDisposed)
            {
                formulario1.showAtasak();
                formulario1.validateLanaldia();
            }

        }
    }
}

