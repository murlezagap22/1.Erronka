using Erronka.modeloak;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Erronka
{
    public partial class FormPrintzipala : Form
    {
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

            // Lortu bezeroak
            bezeroakLista = BezeroakJarretikKargatu();

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

        // Funtzioa Java aplikazioko .jar era deitzen duena eta bezeroen datuak lortu
        private List<Bezeroa> BezeroakJarretikKargatu()
        {
            // Prozesu externoa hasi
            ProcessStartInfo info = new ProcessStartInfo();

            // Java-ko ingurunea definitu
            info.FileName = @"C:\Program Files\Eclipse Adoptium\jdk-25.0.5.8-hotspot\bin\java.exe";

            // Java-ko aplikazioaren bidea
            info.Arguments = "-jar \"..\\..\\..\\..\\erronkaDA\\JavaApp.jar\" importar";

            // Beharrezko parametroak
            // Shell ez erabiltzeko
            info.UseShellExecute = false;
            // Java-ko aplikazioa bueltatuko duen datuak kontsolatik hartzeko
            info.RedirectStandardOutput = true;
            // Kontsolako erroreak hartzeko
            info.RedirectStandardError = true;
            // Kontsola pantaila bat ez sortzeko
            info.CreateNoWindow = true;
            // Non egingo den prozesua definitu
            info.WorkingDirectory = Application.StartupPath;

            using (Process process = Process.Start(info))
            {
                // Bueltatzen diren datuak gorde, edo erroreak
                string json = process.StandardOutput.ReadToEnd();
                string errorea = process.StandardError.ReadToEnd();

                // Itxaron amaitu harte aplikazioa
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    MessageBox.Show("Errorea Java-n:\n" + errorea);
                    return new List<Bezeroa>();
                }

                // Json bihurtu dokumentu batean
                JsonDocument doc = JsonDocument.Parse(json);

                List<Bezeroa> lista = new List<Bezeroa>();

                // Datuak irakurri eta gorde bezero
                foreach (JsonElement dato in doc.RootElement.EnumerateArray())
                {
                    int mota = 0;

                    switch (dato.GetProperty("ostatuMota").GetString()?.ToLower())
                    {
                        case "denda":
                            mota = 1;
                            break;

                        case "autoka":
                            mota = 2;
                            break;

                        case "bungalow":
                            mota = 3;
                            break;
                    }

                    Bezeroa bezero = new Bezeroa(
                        int.Parse(dato.GetProperty("id").GetString()),
                        dato.GetProperty("izena").GetString(),
                        mota,
                        dato.GetProperty("abizena").GetString(),
                        dato.GetProperty("emaila").GetString(),
                        dato.GetProperty("telefonoa").GetString(),
                        dato.GetProperty("sortzeEguna").GetString()
                    );

                    lista.Add(bezero);
                }

                return lista;
            }
        }

        // Atasak erakusteko funtzioa
        public void showAtasak()
        {
            flowLayoutPanelTasks.Controls.Clear();

            // Bezero guztiak zeharkatu
            foreach (Bezeroa bezeroa in bezeroakLista)
            {
                // Bezero bakoitzaren Atasak zerrenda zeharkatu
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

        // Formularioan dauzkagun bezero desberdinak botoi moduan atera
        private void BezeroakErakutsi()
        {
            // Aurreko botoiak ezabatu
            flowLayoutPanelBotoiak.Controls.Clear();

            // Bezeroen list zeharkatuko dugu
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
                botoia.Tag = b; // objetu osoa gorde
                botoia.Click += BezeroaKlikatu;
                botoia.Location = new Point(0, 0);

                // Editatzeko botoia
                Button aldatzekoBotoia = new Button();
                aldatzekoBotoia.Text = "✏️";
                aldatzekoBotoia.Width = 50;
                aldatzekoBotoia.Height = 60;
                aldatzekoBotoia.Tag = b;
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
                return;

            Button botoia = (Button)sender;

            Bezeroa bezero = (Bezeroa)botoia.Tag;

            // Form berria hasi hautatutako bezeroarekin
            FormBezeroaAldatu formulario = new FormBezeroaAldatu(
                this,
                bezero.Id.ToString(),
                bezero.Izena,
                bezero.OstatuMota.ToString()
            );

            // Ireki form
            formulario.Show();
        }

        // Bezeroa datu berriekin aldatu gure list-an
        public void BezeroaEguneratu(string id, string izena, string ostatuMota)
        {
            int bezeroId = int.Parse(id);
            int mota = int.Parse(ostatuMota);

            foreach (Bezeroa bezero in bezeroakLista)
            {
                if (bezero.Id == bezeroId)
                {
                    bezero.Izena = izena;
                    bezero.OstatuMota = mota;

                    break;
                }
            }

            // Datuak berriro erakutsi
            BezeroakErakutsi();
            chargueBezeroak();
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

        // Bezero berri bat sortzeko formularioa hasi
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

        // Lanaldia hasteko funtzioa
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
            int id = bezeroakLista.Count + 1;
            int mota = int.Parse(ostatuMota);

            Bezeroa bezeroBerria = new Bezeroa(id, izena, mota, "", "proba@gmail.com", "000000000", "26-10-2026");

            bezeroakLista.Add(bezeroBerria);

            BezeroakErakutsi();
            chargueBezeroak();
        }

        // Funtzioa jokoa hasteko unity-rekin

        private void gameButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string exePath = System.IO.Path.Combine(userPath, "prueba.exe");

                Process p = Process.Start(exePath);
                label1.Text = "PID: " + p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea gertatu da bideojokoa irekitzekoan: " + ex.Message);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // CSV moduan exportatzeko
        private void buttonCSV_Click(object sender, EventArgs e)
        {
            BezeroakEsportatu(bezeroakLista, "csv");
        }

        // XML moduan exportazteko
        private void buttonXML_Click(object sender, EventArgs e)
        {
            BezeroakEsportatu(bezeroakLista, "xml");
        }

        // Bezeroak esportatzeko funtzioa
        private void BezeroakEsportatu(List<Bezeroa> bezeroak, string formatua)
        {
            ProcessStartInfo info = new ProcessStartInfo();

            info.FileName = @"C:\Program Files\Eclipse Adoptium\jdk-25.0.5.8-hotspot\bin\java.exe";

            info.Arguments = "-jar \"..\\..\\..\\..\\erronkaDA\\JavaApp.jar\" " + formatua;

            info.UseShellExecute = false;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.CreateNoWindow = true;
            info.WorkingDirectory = Application.StartupPath;

            // Datuak prestatu Java aplikaziora bidaltzeko
            var datos = bezeroak.Select(b => new
            {
                id = b.Id.ToString(),
                izena = b.Izena,
                abizena = b.Abizena,
                emaila = b.Emaila,
                telefonoa = b.Telefonoa,

                ostatuMota = b.OstatuMota switch
                {
                    1 => "denda",
                    2 => "autoka",
                    3 => "bungalow",
                    _ => ""
                },

                sortzeEguna = b.SortzeEguna
            });

            string json = JsonSerializer.Serialize(datos);

            using (Process process = Process.Start(info))
            {
                // Json-a bidali
                process.StandardInput.Write(json);
                process.StandardInput.Close();

                string salida = process.StandardOutput.ReadToEnd();
                string errorea = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // Kudeatu erantzuna
                if (process.ExitCode == 0)
                {
                    MessageBox.Show("Esportazioa ondo egin da: " + formatua.ToUpper());
                }
                else
                {
                    MessageBox.Show("Errorea esportatzerakoan:\n" + errorea);
                }
            }
        }
    }
}