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
        private string[,] mezuak = {};

        private string[,] tareas =
        {
            { "Jon", "Revisar instalación eléctrica" },
            { "Ane", "Cambiar bombilla del almacén" },
            { "Mikel", "Reparar ordenador" },
            { "Nerea", "Configurar impresora" },
            { "Iker", "Revisar conexión a Internet" }
        };

        public Form1()
        {
            InitializeComponent();

            btnHasiLanaldia.Visible = false;



            //            string[,] mezuak =
            //{
            //                { "Jon", "Revisar instalación eléctrica" },
            //                { "Ane", "Cambiar bombilla del almacén" },
            //                { "Mikel", "Reparar ordenador" },
            //                { "Nerea", "Configurar impresora" },
            //                { "Iker", "Revisar conexión a Internet" }
            //            };

            string[] trabajadores =
            {
                "Ane",
                "Iker"
            };

            // Sortu bezero desberdinak eta hauen botoiak
            int botonesPorFila = 9;
            int anchoBoton = flowLayoutPanelBotoiak.ClientSize.Width / botonesPorFila;

            for (int i = 0; i < bezeroak.GetLength(0); i++)
            {
                Panel panel = new Panel();
                panel.Width = 170;
                panel.Height = 60;

                Button botoia = new Button();
                botoia.Text = bezeroak[i, 1];
                botoia.Width = 120;
                botoia.Height = 60;
                botoia.Tag = bezeroak[i, 0];
                botoia.Click += BezeroaKlikatu;
                botoia.Location = new Point(0, 0);

                Button editatuBotoia = new Button();
                editatuBotoia.Text = "✏️";
                editatuBotoia.Width = 50;
                editatuBotoia.Height = 60;
                editatuBotoia.Tag = bezeroak[i, 0];
                editatuBotoia.Click += BezeroaAldatu;
                editatuBotoia.Location = new Point(120, 0);

                panel.Controls.Add(botoia);
                panel.Controls.Add(editatuBotoia);

                flowLayoutPanelBotoiak.Controls.Add(panel);
            }

            for (int i = 0; i < tareas.GetLength(0); i++)
            {
                Panel panelTarea = new Panel();

                panelTarea.Width = flowLayoutPanelTasks.ClientSize.Width - 25;
                panelTarea.Height = 75;
                panelTarea.BorderStyle = BorderStyle.FixedSingle;

                Label labelTarea = new Label();
                labelTarea.Text = tareas[i, 1];
                labelTarea.Location = new Point(10, 10);
                labelTarea.AutoSize = true;
                labelTarea.Font = new Font(labelTarea.Font, FontStyle.Bold);

                Label labelBezeroa = new Label();
                labelBezeroa.Text = "Bezero: " + tareas[i, 0];
                labelBezeroa.Location = new Point(10, 45);
                labelBezeroa.AutoSize = true;

                Label labelLangilea = new Label();
                labelLangilea.Text = "Langilea:";
                labelLangilea.Location = new Point(180, 45);
                labelLangilea.AutoSize = true;

                TextBox inputTrabajador = new TextBox();
                inputTrabajador.Location = new Point(250, 42);
                inputTrabajador.Width = 150;
                inputTrabajador.ReadOnly = true;

                panelTarea.Controls.Add(labelTarea);
                panelTarea.Controls.Add(labelBezeroa);
                panelTarea.Controls.Add(labelLangilea);
                panelTarea.Controls.Add(inputTrabajador);

                flowLayoutPanelTasks.Controls.Add(panelTarea);
            }

            chargueBezeroak();
            showMezuak();

            for (int i = 0; i < trabajadores.GetLength(0); i++)
            {
                Panel panelWorkers = new Panel();

                panelWorkers.Width = flowLayoutPanelWorkers.ClientSize.Width - 25;
                panelWorkers.Height = 75;
                panelWorkers.BorderStyle = BorderStyle.FixedSingle;

                Label labelTarea = new Label();
                labelTarea.Text = trabajadores[i];
                labelTarea.Location = new Point(10, 10);
                labelTarea.AutoSize = true;
                labelTarea.Font = new Font(labelTarea.Font, FontStyle.Bold);

                CheckBox checkWorker = new CheckBox();
                checkWorker.Text = "Dentro";
                checkWorker.Location = new Point(10, 35);
                checkWorker.AutoSize = true;

                // Guardamos el trabajador asociado
                checkWorker.Tag = trabajadores[i];

                // Evento cuando cambia el CheckBox
                checkWorker.CheckedChanged += CheckWorker_CheckedChanged;

                panelWorkers.Controls.Add(labelTarea);
                panelWorkers.Controls.Add(checkWorker);

                flowLayoutPanelWorkers.Controls.Add(panelWorkers);
            }
        }

        private void BezeroaKlikatu(object sender, EventArgs e)
        {
            Button botoia = (Button)sender;

            string id = (string)botoia.Tag ?? null;
            string nombre = botoia.Text;

            Form2 formulario = new Form2(id, nombre);
            formulario.Show();
        }

        private void BezeroaAldatu(object sender, EventArgs e)
        {
            MessageBox.Show("Bezeroa aldatu nahi duzu?");
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
                // Irakurrita badago, ezabatzeko baieztapena irakutsi
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

        private void CheckWorker_CheckedChanged(object sender, EventArgs e)
        {
            bool hayTrabajadorDentro = false;

            foreach (Panel panel in flowLayoutPanelWorkers.Controls)
            {
                CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();

                if (checkBox != null && checkBox.Checked)
                {
                    hayTrabajadorDentro = true;
                    break;
                }
            }

            btnHasiLanaldia.Visible = hayTrabajadorDentro;
        }

        private void AddClient_Click(object sender, EventArgs e)
        {
            Form3 formulario = new Form3();
            formulario.Show();
        }

    }
}