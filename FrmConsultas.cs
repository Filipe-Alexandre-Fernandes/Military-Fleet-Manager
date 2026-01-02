using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestaoViaturasWinForms
{
    public partial class FrmConsultas : Form
    {
        public FrmConsultas()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            string sql = @"
    SELECT
        V.ViaturaID,
        V.Matricula,
        Mdl.NomeModelo AS Modelo,
        Mrk.NomeMarca AS Marca,
        TV.DescricaoTipoViatura AS TipoViatura,
        V.AnoFabrico,
        V.DescricaoEstado AS Estado,
        Q.NomeQuartel AS Quartel
    FROM Viatura V
    JOIN Modelo Mdl ON V.ModeloID = Mdl.ModeloID
    JOIN Marca Mrk ON Mdl.MarcaID = Mrk.MarcaID
    JOIN TipoViatura TV ON V.TipoViaturaID = TV.TipoViaturaID
    JOIN Quartel Q ON V.QuartelID = Q.QuartelID
    ORDER BY V.Matricula;
    ";

            dgvResultados.DataSource = Db.Query(sql);
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
