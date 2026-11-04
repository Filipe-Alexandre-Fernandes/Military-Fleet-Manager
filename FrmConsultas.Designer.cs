namespace GestaoViaturasWinForms
{
    partial class FrmConsultas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvResultados = new DataGridView();
            btnExecutar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(12, 28);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.Size = new Size(1058, 517);
            dgvResultados.TabIndex = 0;
            dgvResultados.CellContentClick += dgvResultados_CellContentClick;
            // 
            // btnExecutar
            // 
            btnExecutar.Font = new Font("Segoe UI", 14F);
            btnExecutar.Location = new Point(399, 563);
            btnExecutar.Name = "btnExecutar";
            btnExecutar.Size = new Size(292, 55);
            btnExecutar.TabIndex = 1;
            btnExecutar.Text = "Listar Viaturas";
            btnExecutar.UseVisualStyleBackColor = true;
            btnExecutar.Click += btnExecutar_Click;
            // 
            // FrmConsultas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 653);
            Controls.Add(btnExecutar);
            Controls.Add(dgvResultados);
            Name = "FrmConsultas";
            Text = "FrmConsultas";
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResultados;
        private Button btnExecutar;
    }
}