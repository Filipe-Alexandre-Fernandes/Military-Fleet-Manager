using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace GestaoViaturasWinForms
{
    public partial class FrmRequisicoesLote : Form
    {
        public FrmRequisicoesLote()
        {
            InitializeComponent();
        }

        private DataTable _dtViaturas;

        private void FrmRequisicoesLote_Load(object sender, EventArgs e)
        {



            // Carregar Operações
            cboOperacao.DataSource = Db.Query("SELECT OperacaoID, DescricaoOperacao FROM Operacao");
            cboOperacao.DisplayMember = "DescricaoOperacao";
            cboOperacao.ValueMember = "OperacaoID";
            cboOperacao.SelectedIndex = -1;

            // Carregar Militares
            cboMilitar.DataSource = Db.Query("SELECT MilitarID, NomeMilitar FROM Militar");
            cboMilitar.DisplayMember = "NomeMilitar";
            cboMilitar.ValueMember = "MilitarID";
            cboMilitar.SelectedIndex = -1;

            // Carregar Unidades
            cboUnidade.DataSource = Db.Query("SELECT UnidadeMilitarID, NomeUM FROM UnidadeMilitar");
            cboUnidade.DisplayMember = "NomeUM";
            cboUnidade.ValueMember = "UnidadeMilitarID";
            cboUnidade.SelectedIndex = -1;

            // Carregar Viaturas para o grid
            _dtViaturas = Db.Query("SELECT ViaturaID, Matricula FROM Viatura ORDER BY Matricula");

            SetupGrid();
            AddEmptyRow();
        }


        private void SetupGrid()
        {
            dgvViaturas.AutoGenerateColumns = false;
            dgvViaturas.AllowUserToAddRows = false;
            dgvViaturas.Columns.Clear();

            var colViatura = new DataGridViewComboBoxColumn
            {
                Name = "ViaturaID",
                HeaderText = "Viatura (Matrícula)",
                DataSource = _dtViaturas,
                DisplayMember = "Matricula",
                ValueMember = "ViaturaID",
                Width = 200
            };

            dgvViaturas.Columns.Add(colViatura);
        }

        private void AddEmptyRow()
        {
            dgvViaturas.Rows.Add();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dgvViaturas.EndEdit();

            // validações rápidas
            if (cboOperacao.SelectedValue == null ||
                cboMilitar.SelectedValue == null ||
                cboUnidade.SelectedValue == null)
            {
                MessageBox.Show("Seleciona Operação, Militar e Unidade.");
                return;
            }

            int operacaoId = (int)cboOperacao.SelectedValue;
            int militarId = (int)cboMilitar.SelectedValue;
            int unidadeId = (int)cboUnidade.SelectedValue;

            var viaturas = new List<int>();
            foreach (DataGridViewRow row in dgvViaturas.Rows)
            {
                var v = row.Cells["ViaturaID"].Value;
                if (v == null) continue;
                viaturas.Add((int)v);
            }

            if (viaturas.Count == 0)
            {
                MessageBox.Show("Adiciona pelo menos uma viatura.");
                return;
            }

            if (viaturas.Count != viaturas.Distinct().Count())
            {
                MessageBox.Show("Tens viaturas repetidas. Remove duplicados antes de guardar.");
                return;
            }

            // Usa a mesma connection string do Db.cs (ajusta Server se necessário)
            var cs = "Server=.;Database=GestaoViaturasAtual;Trusted_Connection=True;TrustServerCertificate=True;";

            using var con = new SqlConnection(cs);
            con.Open();
            using var tx = con.BeginTransaction();

            try
            {
                var requisicoesCriadas = new List<int>();

                foreach (var viaturaId in viaturas)
                {
                    using var cmd = new SqlCommand("sp_CriarRequisicaoEAtribuicao", con, tx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ViaturaID", viaturaId);
                    cmd.Parameters.AddWithValue("@OperacaoID", operacaoId);
                    cmd.Parameters.AddWithValue("@MilitarID", militarId);
                    cmd.Parameters.AddWithValue("@UnidadeMilitarID", unidadeId);
                    cmd.Parameters.AddWithValue("@DataSaida", dtSaida.Value);
                    cmd.Parameters.AddWithValue("@DataRegresso", dtRegresso.Value);
                    cmd.Parameters.AddWithValue("@DataSaidaEfetiva", dtSaidaEfetiva.Value);

                    int newReqId = Convert.ToInt32(cmd.ExecuteScalar());
                    requisicoesCriadas.Add(newReqId);
                }

                tx.Commit();

                MessageBox.Show("Guardado!\nRequisições: " + string.Join(", ", requisicoesCriadas));

                dgvViaturas.Rows.Clear();
                AddEmptyRow();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("Erro ao guardar (foi tudo revertido):\n" + ex.Message);
            }
        }

        private void cboUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtSaida_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmptyRow();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvViaturas.CurrentRow != null)
                dgvViaturas.Rows.Remove(dgvViaturas.CurrentRow);
        }

        private void cboOperacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

