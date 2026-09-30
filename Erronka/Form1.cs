namespace Erronka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnHasiLanaldia.Visible = false;

            string[] bezeroak = { "Jon", "Ane", "HASpnasdn", "Ane", "Mikel", "Iker", "Nerea", "Otro", "YUUUU", "SUUUUU", "asdasdasd" };

            string[,] tareas =
            {
                { "Jon", "Revisar instalación eléctrica" },
                { "Ane", "Cambiar bombilla del almacén" },
                { "Mikel", "Reparar ordenador" },
                { "Nerea", "Configurar impresora" },
                { "Iker", "Revisar conexión a Internet" }
            };

            string[,] mezuak =
{
                { "Jon", "Revisar instalación eléctrica" },
                { "Ane", "Cambiar bombilla del almacén" },
                { "Mikel", "Reparar ordenador" },
                { "Nerea", "Configurar impresora" },
                { "Iker", "Revisar conexión a Internet" }
            };

            string[] trabajadores =
            {
                "Ane",
                "Iker"
            };

            int botonesPorFila = 9;
            int anchoBoton = flowLayoutPanelBotoiak.ClientSize.Width / botonesPorFila;

            foreach (string bezeroa in bezeroak)
            {
                Panel panel = new Panel();
                panel.Width = 170;
                panel.Height = 60;

                Button botoia = new Button();
                botoia.Text = bezeroa;
                botoia.Width = 120;
                botoia.Height = 60;
                botoia.Click += BezeroaKlikatu;
                botoia.Location = new Point(0, 0);

                Button editatuBotoia = new Button();
                editatuBotoia.Text = "✏️";
                editatuBotoia.Width = 50;
                editatuBotoia.Height = 60;
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

            for (int i = 0; i < mezuak.GetLength(0); i++)
            {
                Panel panelMezuak = new Panel();

                panelMezuak.Width = flowLayoutPanel2.ClientSize.Width - 25;
                panelMezuak.Height = 75;
                panelMezuak.BorderStyle = BorderStyle.FixedSingle;

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

                flowLayoutPanel2.Controls.Add(panelMezuak);
            }

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

            botoia.Text = botoia.Text + " / Click";
            botoia.BackColor = Color.LightGreen;
        }

        private void BezeroaAldatu(object sender, EventArgs e)
        {
            Button botoia = (Button)sender;

            botoia.BackColor = Color.AliceBlue;
        }

        private void AddText_Click(object sender, EventArgs e)
        {
            string texto = textBoxMensaje.Text;

            MessageBox.Show(texto);
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

    }
}