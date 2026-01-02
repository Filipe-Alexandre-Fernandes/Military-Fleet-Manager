using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestaoViaturasWinForms
{
    public partial class FrmAtualizarViatura : Form
    {
        public FrmAtualizarViatura()
        {
            InitializeComponent();
        }

        private void FrmAtualizarViatura_Load(object sender, EventArgs e)
        {
            cboViatura.DataSource = Db.Query("SELECT ViaturaID, Matricula FROM Viatura ORDER BY Matricula");
            cboViatura.DisplayMember = "Matricula";
            cboViatura.ValueMember = "ViaturaID";
            cboViatura.SelectedIndex = -1;

            cboQuartel.DataSource = Db.Query("SELECT QuartelID, NomeQuartel FROM Quartel ORDER BY NomeQuartel");
            cboQuartel.DisplayMember = "NomeQuartel";
            cboQuartel.ValueMember = "QuartelID";
            cboQuartel.SelectedIndex = -1;
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (cboViatura.SelectedValue == null)
            {
                MessageBox.Show("Seleciona uma viatura.");
                return;
            }

            int viaturaId = (int)cboViatura.SelectedValue;

            var dt = Db.Query(@"
        SELECT DescricaoEstado, QuartelID
        FROM Viatura
        WHERE ViaturaID = @id",
                new Microsoft.Data.SqlClient.SqlParameter("@id", viaturaId));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Viatura não encontrada.");
                return;
            }

            txtEstado.Text = dt.Rows[0]["DescricaoEstado"]?.ToString() ?? "";
            cboQuartel.SelectedValue = (int)dt.Rows[0]["QuartelID"];
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (cboViatura.SelectedValue == null)
            {
                MessageBox.Show("Seleciona uma viatura.");
                return;
            }
            if (cboQuartel.SelectedValue == null)
            {
                MessageBox.Show("Seleciona um quartel.");
                return;
            }

            int viaturaId = (int)cboViatura.SelectedValue;
            int quartelId = (int)cboQuartel.SelectedValue;
            string estado = txtEstado.Text.Trim();

            int rows = Db.Exec(@"
        UPDATE Viatura
        SET DescricaoEstado = @estado,
            QuartelID = @quartel
        WHERE ViaturaID = @id",
                new Microsoft.Data.SqlClient.SqlParameter("@estado", (object)estado ?? DBNull.Value),
                new Microsoft.Data.SqlClient.SqlParameter("@quartel", quartelId),
                new Microsoft.Data.SqlClient.SqlParameter("@id", viaturaId));

            MessageBox.Show(rows > 0 ? "Atualizado com sucesso!" : "Nada foi atualizado.");
        }

        private void cboQuartel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
