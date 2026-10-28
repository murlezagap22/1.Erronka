using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Erronka
{
    public partial class Form1 : Form
    {

        private string[,] bezeroak =
        {
            { "1", "Jon" },
            { "2", "Ane" },
            { "3", "Mikel" },
            { "4", "Iker" },
            { "5", "Nerea" },
            { "6", "Otro" },
            { "7", "YUUUU" },
            { "8", "SUUUUU" },
            { "9", "asdasdasd" }
        };

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

        private bool lanaldia = false;

        private Color coloreOriginala;

        private bool[] egindakoLanak;

        public Form1()
        {
            InitializeComponent();

            btnHasiLanaldia.Visible = false;

            coloreOriginala = btnHasiLanaldia.BackColor;

            egindakoLanak = new bool[egitekoak.GetLength(0)];

            string[] workers =
            {
                "Ane",
                "Iker"
            };

            // Sortu bezero desberdinak eta hauen botoiak

            for (int i = 0; i < bezeroak.GetLength(0); i++)
            {
                //Definitu panelaren baloreak
                Panel panel = new Panel();
                panel.Width = 170;
                panel.Height = 60;

                // Botoia clickaretzarekoan bezeroaren pantaila irekiko duen funtzioarekin
                Button botoia = new Button();
                botoia.Text = bezeroak[i, 1];
                botoia.Width = 120;
                botoia.Height = 60;
                botoia.Tag = bezeroak[i, 0];
                botoia.Click += BezeroaKlikatu;
                botoia.Location = new Point(0, 0);

                // Bezeroa editatzeko botoia
                Button editatuBotoia = new Button();
                editatuBotoia.Text = "✏️";
                editatuBotoia.Width = 50;
                editatuBotoia.Height = 60;
                editatuBotoia.Tag = bezeroak[i, 0];
                editatuBotoia.Click += BezeroaAldatu;
                editatuBotoia.Location = new Point(120, 0);

                // Dena sartu panel barrura
                panel.Controls.Add(botoia);
                panel.Controls.Add(editatuBotoia);

                flowLayoutPanelBotoiak.Controls.Add(panel);
            }

            for (int i = 0; i < egitekoak.GetLength(0); i++)
            {
                // Eginkizunak erakusteko panela definitu
                Panel panelTarea = new Panel();

                panelTarea.Width = flowLayoutPanelTasks.ClientSize.Width - 25;
                panelTarea.Height = 75;
                panelTarea.BorderStyle = BorderStyle.FixedSingle;

                // Honen testua definitu
                Label labelTarea = new Label();
                labelTarea.Text = egitekoak[i, 1];
                labelTarea.Location = new Point(10, 10);
                labelTarea.AutoSize = true;
                labelTarea.Font = new Font(labelTarea.Font, FontStyle.Bold);

                // Bezeroaren izena erakutsi
                Label labelBezeroa = new Label();
                labelBezeroa.Text = "Bezero: " + egitekoak[i, 0];
                labelBezeroa.Location = new Point(10, 45);
                labelBezeroa.AutoSize = true;

                // Langilearen goiko testua definitu
                Label labelLangilea = new Label();
                labelLangilea.Text = "Langilea:";
                labelLangilea.Location = new Point(180, 45);
                labelLangilea.AutoSize = true;

                // Langilearen izena gordeko duen input-a definitu
                TextBox inputLangile = new TextBox();
                inputLangile.Location = new Point(250, 42);
                inputLangile.Width = 150;
                inputLangile.ReadOnly = true;
                inputsLangileak.Add(inputLangile);

                panelTarea.Controls.Add(labelTarea);
                panelTarea.Controls.Add(labelBezeroa);
                panelTarea.Controls.Add(labelLangilea);
                panelTarea.Controls.Add(inputLangile);

                flowLayoutPanelTasks.Controls.Add(panelTarea);
            }

            chargueBezeroak();
            showMezuak();

            // Langileen panela
            for (int i = 0; i < workers.GetLength(0); i++)
            {
                Panel panelWorkers = new Panel();

                panelWorkers.Width = flowLayoutPanelWorkers.ClientSize.Width - 25;
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

        // Bezeroa clickatzerakoan egingo duen funtzioa beste Formulario bat irekitzen
        private void BezeroaKlikatu(object sender, EventArgs e)
        {
            // Erreferentzia clickatutako botoiari
            Button botoia = (Button)sender;

            // Bezeroaren id-a gorde botoitik aterata
            string id = (string)botoia.Tag ?? null;
            string nombre = botoia.Text;

            // Formulario berria definitu
            Form2 formulario = new Form2(id, nombre);
            formulario.Show();
        }

        // Bezeroak aldatzeko botoia
        private void BezeroaAldatu(object sender, EventArgs e)
        {
            // Erantzuna definitu gero baldintza sortzeko
            DialogResult erantzuna = MessageBox.Show(
            "Bezeroa aldatu nahi duzu?",
            "Baieztapena",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            // Erantzuna EZ bada, hurrengo pausura ez da pasatuko
            if (erantzuna == DialogResult.No)
            {
                return;
            }

            Button botoia = (Button)sender;

            botoia.BackColor = Color.AliceBlue;

            Form4 formulario = new Form4();
            formulario.Show();

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

            string selectedBezero =
                comboBoxBezeroak.SelectedItem.ToString();

            // Array berri bat sortu bat gehiagorekin ezin delako array baten edukiera handitu
            string[,] newMezuak =
                new string[mezuak.GetLength(0) + 1, 4];

            // Dauden mezuak array berrira kopiatu
            for (int i = 0; i < mezuak.GetLength(0); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    newMezuak[i, j] = mezuak[i, j];
                }
            }

            // Mezu berria sartu
            int nuevaFila = newMezuak.GetLength(0) - 1;

            newMezuak[nuevaFila, 0] = selectedBezero;
            newMezuak[nuevaFila, 1] = text;
            newMezuak[nuevaFila, 2] = "0"; // Irakurrita dagoen jakiteko aldagaia
            newMezuak[nuevaFila, 3] = "0"; // Ezabatuta dagoen jakiteko aldagaia

            mezuak = newMezuak;

            showMezuak();
            textBoxMensaje.Clear();
        }

        // Mezuak array berrira sartzeko
        private void showMezuak()
        {
            flowLayoutPanel2.Controls.Clear();

            for (int i = 0; i < mezuak.GetLength(0); i++)
            {
                // Ezabatuta dauden mezuak kendu
                if (mezuak[i, 3] == "1")
                    continue;

                int indizea = i;

                Panel panelMezuak = new Panel();

                panelMezuak.Width = flowLayoutPanel2.ClientSize.Width - 25;
                panelMezuak.Height = 75;
                panelMezuak.BorderStyle = BorderStyle.FixedSingle;

                // Berdea irakurrita badagoen
                if (mezuak[i, 2] == "1")
                {
                    panelMezuak.BackColor = Color.LightGreen;
                }
                else
                {
                    panelMezuak.BackColor = Color.White;
                }

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

                // Click egoteko edozein lekutan
                panelMezuak.Click += (s, e) => mezuaKudeatu(indizea);
                labelTarea.Click += (s, e) => mezuaKudeatu(indizea);
                labelBezeroa.Click += (s, e) => mezuaKudeatu(indizea);

                flowLayoutPanel2.Controls.Add(panelMezuak);
            }
        }

        // Mezua bidaltzerakoan comboBox datuekin lehenik
        private void chargueBezeroak()
        {
            comboBoxBezeroak.Items.Clear();

            for (int i = 0; i < bezeroak.GetLength(0); i++)
            {
                comboBoxBezeroak.Items.Add(bezeroak[i, 1]);
            }

            if (comboBoxBezeroak.Items.Count > 0)
            {
                comboBoxBezeroak.SelectedIndex = 0;
            }
        }

        // Mezuak irakurrita edo ezabatuta daudela jakiteko eta aldatzeko
        private void mezuaKudeatu(int indice)
        {
            // Ezabatuta dagoenean ezer egin
            if (mezuak[indice, 3] == "1")
                return;

            // Ez badago irakurrita, irakurrita dagoela jarri
            if (mezuak[indice, 2] == "0")
            {
                mezuak[indice, 2] = "1";

                showMezuak();
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

                    showMezuak();
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
            Form3 formulario = new Form3();
            formulario.Show();
        }


        private void btnHasiLanaldia_Click(object sender, EventArgs e)
        {
            lanaldia = !lanaldia;
            if (lanaldia)
            {
                btnHasiLanaldia.Text = "Bukatu lanaldia";
                btnHasiLanaldia.BackColor = Color.Red;
                btnHasiLanaldia.ForeColor = Color.White;
            } else
            {
                btnHasiLanaldia.Text = "Hasi lanaldia";
                btnHasiLanaldia.BackColor = coloreOriginala;
                btnHasiLanaldia.ForeColor = Color.Black;
            }

            List<string> langileak = LangileakLortu();

            if (langileak.Count == 0)
            {
                MessageBox.Show("Ez dago langilerik barruan.");
                return;
            }

            int hurrengoLana = -1;

            foreach (string langilea in langileak)
            {
                Thread haria = new Thread(() =>
                {
                    while (true)
                    {
                        if (!lanaldia)
                            break;
                        int i = Interlocked.Increment(ref hurrengoLana);

                        if (i >= egitekoak.GetLength(0))
                            break;

                        if (egindakoLanak[i])
                            continue;

                        string lana = egitekoak[i, 1];
                        int denbora = DenboraLortu(lana);

                        Thread.Sleep(denbora);

                        TextBox input = inputsLangileak[i];

                        input.Invoke((MethodInvoker)(() =>
                        {
                            input.Text = langilea;
                        }));

                        if (lanaldia)
                        {
                            egindakoLanak[i] = true;
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




    }
}