using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;

namespace Erronka
{
    public partial class Form1 : Form
    {

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

        private List<Bezeroa> CargarBezeroak()
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

        private string[,] egitekoak =
        {
            { "Jon", "Eskuoihalak" },
            { "Ane", "Izarak" },
            { "Mikel", "Zaborra" },
            { "Iker", "Jatetxea" }
        };

        private List<TextBox> inputsLangileak = new List<TextBox>();
        private List<Label> labelsEginda = new List<Label>();
        private List<Panel> panelesTareas = new List<Panel>();

        private bool lanaldia = false;

        private Color coloreOriginala;

        private Form2 formulario2;

        private List<Bezeroa> bezeroakLista;

        public Form1()
        {
            InitializeComponent();

            bezeroakLista = CargarBezeroak();

            btnHasiLanaldia.Visible = false;

            coloreOriginala = btnHasiLanaldia.BackColor;

            string[] workers =
            {
                "Ane",
                "Iker"
            };

            // Sortu bezero desberdinak eta hauen botoiak
            BezeroakErakutsi();

            showAtasak();

            chargueBezeroak();
            showMezuak();

            // Langileen panela
            for (int i = 0; i < workers.GetLength(0); i++)
            {
                Panel panelWorkers = new Panel();

                panelWorkers.Width = flowLayoutPanelWorkers.ClientSize.Width - 8;
                panelWorkers.Height = 75;
                panelWorkers.BorderStyle = BorderStyle.FixedSingle;

                Label labelTarea = new Label();
                labelTarea.Text = workers[i];
                labelTarea.Location = new Point(10, 10);
                labelTarea.AutoSize = true;
                labelTarea.Font = new Font(labelTarea.Font, FontStyle.Bold);

                CheckBox checkWorker = new CheckBox();
                checkWorker.Text = "Barruan";
                checkWorker.Location = new Point(10, 35);
                checkWorker.AutoSize = true;

                // Langilea gorde
                checkWorker.Tag = workers[i];

                // Funtzioa check a aldatzerakoan
                checkWorker.CheckedChanged += CheckWorker_CheckedChanged;

                panelWorkers.Controls.Add(labelTarea);
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
                    Panel panelTarea = new Panel
                    {
                        Width = flowLayoutPanelTasks.ClientSize.Width - 8,
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
                    panelTarea.Controls.Add(labelTarea);
                    panelTarea.Controls.Add(labelBezeroa);
                    panelTarea.Controls.Add(labelLangilea);
                    panelTarea.Controls.Add(inputLangile);
                    panelTarea.Controls.Add(labelEginda);

                    flowLayoutPanelTasks.Controls.Add(panelTarea);
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
                Button editatuBotoia = new Button();
                editatuBotoia.Text = "✏️";
                editatuBotoia.Width = 50;
                editatuBotoia.Height = 60;
                editatuBotoia.Tag = b; // Hemen ere objetu osoa gordetzen dugu
                editatuBotoia.Click += BezeroaAldatu;
                editatuBotoia.Location = new Point(120, 0);

                // Kontrolak panelean sartu
                panel.Controls.Add(botoia);
                panel.Controls.Add(editatuBotoia);

                flowLayoutPanelBotoiak.Controls.Add(panel);
            }
        }

        // Bezeroa clickatzerakoan egingo duen funtzioa beste Formulario bat irekitzen
        private void BezeroaKlikatu(object sender, EventArgs e)
        {
            // Erreferentzia clickatutako botoiari
            Button botoia = (Button)sender;

            Bezeroa bezeroHautatua = (Bezeroa)botoia.Tag;

            // Formulario berria definitu
            formulario2 = new Form2(this, bezeroHautatua);
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

                    Form4 formulario = new Form4(this, id, izena, ostatuMota);
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

            // 1. Balioztatzea: Egiaztatu bezeroren bat hautatuta dagoen ComboBox-ean
            if (comboBoxBezeroak.SelectedIndex == -1)
            {
                MessageBox.Show("Hautatu bezero bat zerrendatik");
                return;
            }

            // 2. Hautatutako Bezeroa objetua lortu posizioaren (índice) bidez
            Bezeroa bezeroHautatua = bezeroakLista[comboBoxBezeroak.SelectedIndex];

            // 3. Mezu berria objetu gisa sortu eta bezeroaren zerrendara gehitu
            Mezua mezuaBerria = new Mezua(text, osatuta: false, ezabatuta: false);
            bezeroHautatua.Mezuak.Add(mezuaBerria);

            // 4. Formulario nagusiko bista eguneratu (badaude mezuak erakusteko kontrolak)
            showMezuak();

            // 5. Form2 zabalik badago, hautatutako bezero horren mezuak pasatu berriro kargatzeko
            if (formulario2 != null && !formulario2.IsDisposed)
            {
                formulario2.ErakutsiMezuak(bezeroHautatua.Mezuak);
            }

            // 6. Testu-kustila garbitu
            textBoxMensaje.Clear();
        }

        // Mezuak array berrira sartzeko
        public void showMezuak()
        {
            flowLayoutPanel2.Controls.Clear();

            // 1. Bezero guztien zerrenda zeharkatu
            foreach (Bezeroa bezeroa in bezeroakLista)
            {
                // 2. Bezero bakoitzaren mezuak zeharkatu
                foreach (Mezua mezua in bezeroa.Mezuak)
                {
                    // Ezabatuta dauden mezuak kendu
                    if (mezua.EzabatutaAdmin)
                        continue;

                    Panel panelMezuak = new Panel
                    {
                        Width = flowLayoutPanel2.ClientSize.Width - 25, // Margen para la barra de desplazamiento
                        Height = 75,
                        BorderStyle = BorderStyle.FixedSingle,
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
                        Text = "Bezero: " + bezeroa.Izena, // Bezeroaren izena objektutik directoki
                        Location = new Point(10, 45),
                        AutoSize = true
                    };

                    panelMezuak.Controls.Add(labelTarea);
                    panelMezuak.Controls.Add(labelBezeroa);

                    // Indizearen ordez, mezua eta bezeroa objektuak bidaltzen dizkiogu kudeatzaileari
                    panelMezuak.Click += (s, e) => mezuaKudeatu(mezua, bezeroa);
                    labelTarea.Click += (s, e) => mezuaKudeatu(mezua, bezeroa);
                    labelBezeroa.Click += (s, e) => mezuaKudeatu(mezua, bezeroa);

                    flowLayoutPanel2.Controls.Add(panelMezuak);
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
            // 1. Ezabatuta dagoenean ezer ez egin
            if (mezua.EzabatutaAdmin)
                return;

            // 2. Ez badago irakurrita / osatuta, irakurrita gisa jarri
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

        private List<string> LangileakLortu()
        {
            List<string> langileakBarruan = new List<string>();

            foreach (Panel panel in flowLayoutPanelWorkers.Controls)
            {
                CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();

                if (checkBox != null && checkBox.Checked)
                {
                    string nombre = checkBox.Tag as string;

                    if (nombre != null)
                    {
                        langileakBarruan.Add(nombre);
                    }
                }
            }

            return langileakBarruan;
        }


        private void AddClient_Click(object sender, EventArgs e)
        {
            Form3 formulario = new Form3(this);
            formulario.Show();
        }

        public void validateLanaldia()
        {
            if (lanaldia)
            {
                LanakProzesatu();
            }
        }


        private void btnHasiLanaldia_Click(object sender, EventArgs e)
        {
            // 1. Validar primero si hay trabajadores seleccionados/disponibles
            List<string> langileak = LangileakLortu();

            if (!lanaldia && langileak.Count == 0)
            {
                MessageBox.Show("Ez dago langilerik barruan.");
                return;
            }

            // 2. Cambiar el estado de la jornada
            lanaldia = !lanaldia;

            // 3. Estatus visual del botón
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

            // 4. Bloquear/desbloquear CheckBoxes según el estado de lanaldia
            foreach (Panel panel in flowLayoutPanelWorkers.Controls)
            {
                foreach (Control kontrola in panel.Controls)
                {
                    if (kontrola is CheckBox checkWorker)
                    {
                        checkWorker.Enabled = !lanaldia; // Si lanaldia es true -> Enabled = false
                    }
                }
            }

            // 5. Solo arrancar hilos si la jornada está ACTIVA
            if (lanaldia)
            {
                LanakProzesatu();
            }
        }


        private void LanakProzesatu()
        {
            // 1. Bezero guztien atasa guztiak zerrenda bakarrean bildu (eginda ez daudenak bakarrik)
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

                        // Atomikoki hurrengo lanaren indizea lortu
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