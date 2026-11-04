namespace GestaoViaturasWinForms
{
    partial class FrmMenu
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
            btnRequisicoes = new Button();
            btnAtualizarViatura = new Button();
            btnConsulta = new Button();
            SuspendLayout();
            // 
            // btnRequisicoes
            // 
            btnRequisicoes.Font = new Font("Segoe UI", 14F);
            btnRequisicoes.Location = new Point(375, 99);
            btnRequisicoes.Name = "btnRequisicoes";
            btnRequisicoes.Size = new Size(392, 88);
            btnRequisicoes.TabIndex = 0;
            btnRequisicoes.Text = "Inserir Requisição e Atribuição";
            btnRequisicoes.UseVisualStyleBackColor = true;
            btnRequisicoes.Click += btnRequisicoes_Click;
            // 
            // btnAtualizarViatura
            // 
            btnAtualizarViatura.Font = new Font("Segoe UI", 14F);
            btnAtualizarViatura.Location = new Point(375, 228);
            btnAtualizarViatura.Name = "btnAtualizarViatura";
            btnAtualizarViatura.Size = new Size(392, 104);
            btnAtualizarViatura.TabIndex = 1;
            btnAtualizarViatura.Text = "Atualizar Viatura";
            btnAtualizarViatura.UseVisualStyleBackColor = true;
            btnAtualizarViatura.Click += btnAtualizarViatura_Click;
            // 
            // btnConsulta
            // 
            btnConsulta.Font = new Font("Segoe UI", 14F);
            btnConsulta.Location = new Point(375, 379);
            btnConsulta.Name = "btnConsulta";
            btnConsulta.Size = new Size(392, 110);
            btnConsulta.TabIndex = 2;
            btnConsulta.Text = "Consulta Detalhada das Viaturas";
            btnConsulta.UseVisualStyleBackColor = true;
            btnConsulta.Click += btnConsulta_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 653);
            Controls.Add(btnConsulta);
            Controls.Add(btnAtualizarViatura);
            Controls.Add(btnRequisicoes);
            Name = "FrmMenu";
            Text = "FrmMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRequisicoes;
        private Button btnAtualizarViatura;
        private Button btnConsulta;
    }
}