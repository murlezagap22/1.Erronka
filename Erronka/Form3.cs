using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Erronka
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            string[,] ostatuak =
            {
                { "1", "Denda" },
                { "2", "Autokarabana" },
                { "3", "Bungalow" }
            };

            for (int i = 0; i < ostatuak.GetLength(0); i++)
            {
                comboBoxOstatuMota.Items.Add(ostatuak[i, 1]);
            }
        }

    }
}
