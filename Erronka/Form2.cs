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
        public Form2(string id, string nombre)
        {
            InitializeComponent();

            labelIzena.Text = "Bezeroa: " + nombre;
        }

    }
}
