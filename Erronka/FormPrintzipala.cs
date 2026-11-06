using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;

namespace Erronka
{
    public partial class FormPrintzipala : Form
    {
        // Bezeroen array-a
        private string[,] bezeroak =
        {
            { "1", "Jon", "2" },
            { "2", "Ane", "2" },
            { "3", "Mikel", "2" },
            { "4", "Iker", "2" },
            { "5", "Nerea", "2" },
            { "6", "Otro", "2" },
            { "7", "YUUUU", "2" },
            { "8", "SUUUUU", "2" },
            { "9", "asdasdasd", "2" }
        };

        // Berekoak dituen array-a objetuetan bihurtzeko funtzioa
        private List<Bezeroa> bezeroakKargatu()
        {
            List<Bezeroa> lista = new List<Bezeroa>();

            for (int i = 0; i < bezeroak.GetLength(0); i++)
            {
                int id = int.Parse(bezeroak[i, 0]);
                string izena = bezeroak[i, 1];
                int mota = int.Parse(bezeroak[i, 2]);

                lista.Add(new Bezeroa(id, izena, mota));
            }

            return lista;
        }

        // Definitu mezuak arraya 
        private string[,] mezuak = { };

        // Egitekoen array-a
        private string[,] egitekoak =
        {
            { "Jon", "Eskuoihalak" },
            { "Ane", "Izarak" },
            { "Mikel", "Zaborra" },
            { "Iker", "Jatetxea" }
        };

        // Lanaldia kudeatzeko aldagaia
        private bool lanaldia = false;

        private Color coloreOriginala;
        // Bigarren formularioaren istantzia gordetzeko aldagaia
        private FormBezeroa formulario2;

        // Bezeroak gordeko dituen lista bezeroak gehitu ahal izateko.
        private List<Bezeroa> bezeroakLista;

        public FormPrintzipala()
        {
            InitializeComponent();

            bezeroakLista = bezeroakKargatu();

            // Hasierako egoerak gorde
            btnHasiLanaldia.Visible = false;

            coloreOriginala = btnHasiLanaldia.BackColor;

            // Langileak
            string[] workers =
            {
                "Ane",
                "Iker"
            };

            // Sortu bezero desberdinak eta hauen botoiak
            BezeroakErakutsi();

            // Comboboxean sartu bezeroak
            chargueBezeroak();

            // Langileen panela
            for (int i = 0; i < workers.GetLength(0); i++)
            {
                Panel panelWorkers = new Panel();

                panelWorkers.Width = flowLayoutPanelWorkers.ClientSize.Width - 8;
                panelWorkers.Height = 75;
                panelWorkers.BorderStyle = BorderStyle.FixedSingle;

                Label labelAtasa = new Label();
                labelAtasa.Text = workers[i];
                labelAtasa.Location = new Point(10, 10);
                labelAtasa.AutoSize = true;
                labelAtasa.Font = new Font(labelAtasa.Font, FontStyle.Bold);

                CheckBox checkWorker = new CheckBox();
                checkWorker.Text = "Barruan";
                checkWorker.Location = new Point(10, 35);
                checkWorker.AutoSize = true;

                // Langilea gorde
                checkWorker.Tag = workers[i];

                // Funtzioa check a aldatzerakoan
                checkWorker.CheckedChanged += CheckWorker_CheckedChanged;

                panelWorkers.Controls.Add(labelAtasa);
                panelWorkers.Controls.Add(checkWorker);

                flowLayoutPanelWorkers.Controls.Add(panelWorkers);
            }
        }

        public void showAtasak()
        {
            flowLayoutPanelTasks.Controls.Clear();

            // 1. Bezero guztiak zeharkatu
            foreach (Bezeroa bezeroa in bezeroakLista)
            {
                // 2. Bezero bakoitzaren Atasak zerrenda zeharkatu
                foreach (Atasa atasa in bezeroa.Atasak)
                {
                    Panel panelAtasa = new Panel
                    {
                        Width = flowLayoutPanelTasks.ClientSize.Width - 8,
                        Height = 75,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = atasa // Atasa objetua panelean gordetzen dugu
                    };

                    // Honen testua definitu
                    Label labelAtasa = new Label
                    {
                        Text = atasa.Testua,
                        Location = new Point(10, 10),
                        AutoSize = true,
                        Font = new Font(this.Font, FontStyle.Bold)
                    };

                    // Bezeroaren izena erakutsi
                    Label labelBezeroa = new Label
                    {
                        Text = "Bezero: " + bezeroa.Izena,
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
                    panelAtasa.Controls.Add(labelAtasa);
                    panelAtasa.Controls.Add(labelBezeroa);
                    panelAtasa.Controls.Add(labelLangilea);
                    panelAtasa.Controls.Add(inputLangile);
                    panelAtasa.Controls.Add(labelEginda);

                    flowLayoutPanelTasks.Controls.Add(panelAtasa);
                }
            }
        }

        private void BezeroakErakutsi()
        {
            // Aurreko botoiak ezabatu
            flowLayoutPanelBotoiak.Controls.Clear();

            // bezeroak.GetLength(0)-ren ordez List<Bezeroa> zeharkatuko dugu
            foreach (Bezeroa b in bezeroakLista)
            {
                // Panelaren baloreak definitu
                Panel panel = new Panel();
                panel.Width = 170;
                panel.Height = 60;

                // Bezeroaren botoia
                Button botoia = new Button();
                botoia.Text = b.Izena; // Objetuaren izena
                botoia.Width = 120;
                botoia.Height = 60;
                botoia.Tag = b; // ID bakarrik gorde ordez, objetu osoa gordetzen dugu!
                botoia.Click += BezeroaKlikatu;
                botoia.Location = new Point(0, 0);

                // Editatzeko botoia
                Button aldatzekoBotoia = new Button();
                aldatzekoBotoia.Text = "✏️";
                aldatzekoBotoia.Width = 50;
                aldatzekoBotoia.Height = 60;
                aldatzekoBotoia.Tag = b; // Hemen ere objetu osoa gordetzen dugu
                aldatzekoBotoia.Click += BezeroaAldatu;
                aldatzekoBotoia.Location = new Point(120, 0);

                // Kontrolak panelean sartu
                panel.Controls.Add(botoia);
                panel.Controls.Add(aldatzekoBotoia);

                flowLayoutPanelBotoiak.Controls.Add(panel);
            }
        }

        // Bezeroa click-atzerakoan egingo duen funtzioa beste Formulario bat irekitzen
        private void BezeroaKlikatu(object sender, EventArgs e)
        {
            // Erreferentzia clickatutako botoiari
            Button botoia = (Button)sender;

            Bezeroa bezeroHautatua = (Bezeroa)botoia.Tag;

            // Formulario berria definitu
            formulario2 = new FormBezeroa(this, bezeroHautatua);
            formulario2.Show();
        }

        // Bezeroak aldatzeko botoia
        private void BezeroaAldatu(object sender, EventArgs e)
        {
            DialogResult erantzuna = MessageBox.Show(
                "Bezeroa aldatu nahi duzu?",
                "Baieztapena",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (erantzuna != DialogResult.Yes)
            {
                return;
            }

            Button botoia = (Button)sender;

            string id = botoia.Tag.ToString();

            // Bezeroaren datuak bilatu
            for (int i = 0; i < bezeroak.GetLength(0); i++)
            {
                if (bezeroak[i, 0] == id)
                {
                    string izena = bezeroak[i, 1];
                    string ostatuMota = bezeroak[i, 2];

                    FormBezeroaAldatu formulario = new FormBezeroaAldatu(this, id, izena, ostatuMota);
                    formulario.Show();

                    break;
                }
            }
        }

        public void BezeroaEguneratu(string id, string izena, string ostatuMota)
        {
            for (int i = 0; i < bezeroak.GetLength(0); i++)
            {
                if (bezeroak[i, 0] == id)
                {
                    bezeroak[i, 1] = izena;
                    bezeroak[i, 2] = ostatuMota;

                    break;
                }
            }

            // Botoiak berriro sortu
            BezeroakErakutsi();
        }

        // Mezua
        private void AddText_Click(object sender, EventArgs e)
        {
            string text = textBoxMensaje.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Sartu mezu bat bezeroari bidaltzeko");
                return;
            }

            // Egiaztatu bezeroren bat hautatuta dagoen ComboBox-ean
            if (comboBoxBezeroak.SelectedIndex == -1)
            {
                MessageBox.Show("Hautatu bezero bat zerrendatik");
                return;
            }

            // Hautatutako Bezeroa objetua lortu posizioaren (índice) bidez
            Bezeroa bezeroHautatua = bezeroakLista[comboBoxBezeroak.SelectedIndex];

            // Mezu berria objetu gisa sortu eta bezeroaren zerrendara gehitu
            Mezua mezuBerria = new Mezua(text, osatuta: false, ezabatuta: false);
            bezeroHautatua.Mezuak.Add(mezuBerria);

            // Formulario nagusiko bista eguneratu (badaude mezuak erakusteko kontrolak)
            showMezuak();

            // Form2 zabalik badago, hautatutako bezero horren mezuak pasatu berriro kargatzeko
            if (formulario2 != null && !formulario2.IsDisposed)
            {
                formulario2.ErakutsiMezuak(bezeroHautatua.Mezuak);
            }

            // Testu-kustila garbitu
            textBoxMensaje.Clear();
        }

        // Mezuak array berrira sartzeko
        public void showMezuak()
        {
            flowLayoutPanelMezuak.Controls.Clear();

            // Bezero guztien zerrenda zeharkatu
            foreach (Bezeroa bezeroa in bezeroakLista)
            {
                // Bezero bakoitzaren mezuak zeharkatu
                foreach (Mezua mezua in bezeroa.Mezuak)
                {
                    // Ezabatuta dauden mezuak kendu
                    if (mezua.EzabatutaAdmin)
                        continue;

                    Panel panelMezuak = new Panel
                    {
                        Width = flowLayoutPanelMezuak.ClientSize.Width - 25,
                        Height = 75,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = mezua.Osatuta ? Color.LightGreen : Color.White
                    };

                    Label labelAtasa = new Label
                    {
                        Text = mezua.Testua,
                        Location = new Point(10, 10),
                        AutoSize = true,
                        Font = new Font(this.Font, FontStyle.Bold)
                    };

                    Label labelBezeroa = new Label
                    {
                        Text = "Bezero: " + bezeroa.Izena,
                        Location = new Point(10, 45),
                        AutoSize = true
                    };

                    panelMezuak.Controls.Add(labelAtasa);
                    panelMezuak.Controls.Add(labelBezeroa);

                    // Indizearen ordez, mezua eta bezeroa objektuak bidaltzen dizkiogu kudeatzaileari
                    panelMezuak.Click += (s, e) => mezuaKudeatu(mezua, bezeroa);
                    labelAtasa.Click += (s, e) => mezuaKudeatu(mezua, bezeroa);
                    labelBezeroa.Click += (s, e) => mezuaKudeatu(mezua, bezeroa);

                    flowLayoutPanelMezuak.Controls.Add(panelMezuak);
                }
            }
        }

        // Mezua bidaltzerakoan comboBox datuekin lehenik
        private void chargueBezeroak()
        {
            comboBoxBezeroak.Items.Clear();

            foreach (Bezeroa b in bezeroakLista)
            {
                comboBoxBezeroak.Items.Add(b.Izena);
            }

            if (comboBoxBezeroak.Items.Count > 0)
            {
                comboBoxBezeroak.SelectedIndex = 0;
            }
        }

        // Mezuak irakurrita edo ezabatuta daudela jakiteko eta aldatzeko
        private void mezuaKudeatu(Mezua mezua, Bezeroa bezeroa)
        {
            // Ezabatuta dagoenean ezer ez egin
            if (mezua.EzabatutaAdmin)
                return;

            // Ez badago irakurrita / osatuta, irakurrita gisa jarri
            if (!mezua.Osatuta)
            {
                mezua.Osatuta = true;
                EguneratuBistak();

                if (formulario2 != null && !formulario2.IsDisposed)
                {
                    formulario2.ErakutsiMezuak(bezeroa.Mezuak);
                }

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
                    mezua.EzabatutaAdmin = true;
                    EguneratuBistak();

                    if (formulario2 != null && !formulario2.IsDisposed)
                    {
                        formulario2.ErakutsiMezuak(bezeroa.Mezuak);
                    }

                }
            }
        }

        // Metodo laguntzailea Form1 eta Form2 (zabalik badago) aldi berean eguneratzeko
        private void EguneratuBistak()
        {
            // Form1-eko mezu guztiak berriro kargatu
            showMezuak();

            // Form2 zabalik badago, haren mezuak ere berriro kargatu
            if (formulario2 != null && !formulario2.IsDisposed)
            {
                // Form2-n kargatuta dagoen bezeroaren mezuak berriz bistaratu
                if (comboBoxBezeroak.SelectedIndex != -1)
                {
                    Bezeroa bezeroHautatua = bezeroakLista[comboBoxBezeroak.SelectedIndex];
                    formulario2.ErakutsiMezuak(bezeroHautatua.Mezuak);
                }
            }
        }

        // Jakiteko langileak barruan dauden ala ez
        private void CheckWorker_CheckedChanged(object sender, EventArgs e)
        {
            bool workersIn = false;

            foreach (Panel panel in flowLayoutPanelWorkers.Controls)
            {
                CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();

                if (checkBox != null && checkBox.Checked)
                {
                    workersIn = true;
                    break;
                }
            }

            // Langilea barruan badago, botoia erakutsi
            btnHasiLanaldia.Visible = workersIn;
        }

        // Langileak lortzeko funrzioa, jakiteko zeintzuk dauden hautatuta lan
        private List<string> LangileakLortu()
        {
            List<string> langileakBarruan = new List<string>();

            foreach (Panel panel in flowLayoutPanelWorkers.Controls)
            {
                CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();

                if (checkBox != null && checkBox.Checked)
                {
                    string izena = checkBox.Tag as string;

                    if (izena != null)
                    {
                        langileakBarruan.Add(izena);
                    }
                }
            }

            return langileakBarruan;
        }


        private void AddClient_Click(object sender, EventArgs e)
        {
            FormBezeroaSortu formulario = new FormBezeroaSortu(this);
            formulario.Show();
        }

        // Lana momentuan darabilen jakiteko funtzioa
        public void validateLanaldia()
        {
            if (lanaldia)
            {
                LanakProzesatu();
            }
        }


        private void btnHasiLanaldia_Click(object sender, EventArgs e)
        {
            // Langileak lortu
            List<string> langileak = LangileakLortu();

            if (!lanaldia && langileak.Count == 0)
            {
                MessageBox.Show("Ez dago langilerik barruan.");
                return;
            }

            // Lanaldiaren egoera aldatu
            lanaldia = !lanaldia;

            // Botoiaren aldaketa jakiteko lanaldia hasita badagoen ala ez
            if (lanaldia)
            {
                btnHasiLanaldia.Text = "Bukatu lanaldia";
                btnHasiLanaldia.BackColor = Color.Red;
                btnHasiLanaldia.ForeColor = Color.White;
            }
            else
            {
                btnHasiLanaldia.Text = "Hasi lanaldia";
                btnHasiLanaldia.BackColor = coloreOriginala;
                btnHasiLanaldia.ForeColor = Color.Black;
            }

            // Lanaldiaren egoera kontuan izanda, checkbox-ak desaktibatu edo aktibatu
            foreach (Panel panel in flowLayoutPanelWorkers.Controls)
            {
                foreach (Control kontrola in panel.Controls)
                {
                    if (kontrola is CheckBox checkWorker)
                    {
                        checkWorker.Enabled = !lanaldia;
                    }
                }
            }

            // Lanaldia aktibatuta bakarrik badago hasi harien (Thread) sorpena
            if (lanaldia)
            {
                LanakProzesatu();
            }
        }


        // Lanak kudeatzeko funtzio printzipala
        private void LanakProzesatu()
        {
            // Bezero guztien atasa guztiak zerrenda bakarrean bildu (eginda ez daudenak bakarrik)
            List<Atasa> atasaGuztiak = bezeroakLista
                .SelectMany(b => b.Atasak)
                .Where(a => !a.Eginda)
                .ToList();

            // Lanik ez badago, ez dugu haririk sortu behar
            if (atasaGuztiak.Count == 0)
                return;

            int hurrengoLana = -1;

            List<string> langileak = LangileakLortu();

            // 2. Langile bakoitzeko hari (Thread) bat sortu
            foreach (string langilea in langileak)
            {
                string langileIzena = langilea;

                Thread haria = new Thread(() =>
                {
                    while (true)
                    {
                        if (!lanaldia)
                            break;

                        // Hurrengo lanaren indizea lortu, horrela egiten da hari desberdinak kudeatzerakoan arazoak ez izateko
                        int i = Interlocked.Increment(ref hurrengoLana);

                        // Lan gehiago ez badago, haria amaitu
                        if (i >= atasaGuztiak.Count)
                            break;

                        Atasa atasa = atasaGuztiak[i];

                        if (atasa.Eginda)
                            continue;

                        // Denbora kalkulatu objetuaren testuarekin
                        int denbora = DenboraLortu(atasa.Testua);

                        // Lana simulatu
                        Thread.Sleep(denbora);

                        if (lanaldia)
                        {
                            // Objetuaren egoera eguneratu
                            atasa.Eginda = true;
                            atasa.Langilea = langileIzena;

                            // Interfazea haritik zuzenean freskatu Invoke bidez
                            this.Invoke((MethodInvoker)(() =>
                            {
                                showAtasak();

                                if (formulario2 != null && !formulario2.IsDisposed)
                                {
                                    formulario2.showAtasakBezero();
                                }
                            }));
                        }
                    }
                });

                haria.IsBackground = true;
                haria.Start();
            }
        }

        // Atasak zenbat denbora tardatuko duten jakitzeko funtzioa
        private int DenboraLortu(string lana)
        {
            switch (lana)
            {
                case "Eskuoihalak":
                    return 2000;

                case "Izarak":
                    return 3000;

                case "Zaborra":
                    return 1000;

                case "Jatetxea":
                    return 1000;

                default:
                    return 0;
            }
        }

        // Bezeroa gehitzeko funtzioa
        public void BezeroaGehitu(string izena, string ostatuMota)
        {
            // Array-aren zenbateko gero kopia bat egiteko bat gehiagorekin
            int kopurua = bezeroak.GetLength(0);

            string[,] berria = new string[kopurua + 1, 3];

            for (int i = 0; i < kopurua; i++)
            {
                berria[i, 0] = bezeroak[i, 0];
                berria[i, 1] = bezeroak[i, 1];
                berria[i, 2] = bezeroak[i, 2];
            }

            // Berria sartu array berrian azken lekuan
            berria[kopurua, 0] = (kopurua + 1).ToString();
            berria[kopurua, 1] = izena;
            berria[kopurua, 2] = ostatuMota;

            // Berdindu hasieran geneukan array-arekin
            bezeroak = berria;

            // Berriro bezeroak pintatu
            BezeroakErakutsi();
        }

    }
}