using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestaoViaturasWinForms
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            this.Load += FrmMenu_Load;
        }

        private void btnRequisicoes_Click(object sender, EventArgs e)
        {
            new FrmRequisicoesLote().ShowDialog();
        }

        private void btnAtualizarViatura_Click(object sender, EventArgs e)
        {
            new FrmAtualizarViatura().ShowDialog();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            new FrmConsultas().ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                var dt = Db.Query("SELECT DB_NAME() AS BaseDeDados, @@SERVERNAME AS Servidor");
                MessageBox.Show($"Ligação OK!\nServidor: {dt.Rows[0]["Servidor"]}\nBD: {dt.Rows[0]["BaseDeDados"]}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de ligação à BD:\n" + ex.Message);
            }
        }
    }
}
