using System.Data;

namespace GestaoViaturasWinForms
{
    partial class FrmAtualizarViatura
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
            label1 = new Label();
            cboViatura = new ComboBox();
            label2 = new Label();
            txtEstado = new TextBox();
            label3 = new Label();
            cboQuartel = new ComboBox();
            btnCarregar = new Button();
            btnAtualizar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(415, 111);
            label1.Name = "label1";
            label1.Size = new Size(89, 32);
            label1.TabIndex = 0;
            label1.Text = "Viatura";
            // 
            // cboViatura
            // 
            cboViatura.Font = new Font("Segoe UI", 14F);
            cboViatura.FormattingEnabled = true;
            cboViatura.Location = new Point(630, 111);
            cboViatura.Name = "cboViatura";
            cboViatura.Size = new Size(151, 39);
            cboViatura.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(415, 183);
            label2.Name = "label2";
            label2.Size = new Size(84, 32);
            label2.TabIndex = 2;
            label2.Text = "Estado";
            // 
            // txtEstado
            // 
            txtEstado.Font = new Font("Segoe UI", 14F);
            txtEstado.Location = new Point(656, 189);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(125, 39);
            txtEstado.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(415, 267);
            label3.Name = "label3";
            label3.Size = new Size(93, 32);
            label3.TabIndex = 4;
            label3.Text = "Quartel";
            // 
            // cboQuartel
            // 
            cboQuartel.DropDownWidth = 250;
            cboQuartel.Font = new Font("Segoe UI", 14F);
            cboQuartel.FormattingEnabled = true;
            cboQuartel.Location = new Point(630, 267);
            cboQuartel.Name = "cboQuartel";
            cboQuartel.Size = new Size(151, 39);
            cboQuartel.TabIndex = 5;
            cboQuartel.SelectedIndexChanged += cboQuartel_SelectedIndexChanged;
            // 
            // btnCarregar
            // 
            btnCarregar.Font = new Font("Segoe UI", 14F);
            btnCarregar.Location = new Point(376, 404);
            btnCarregar.Name = "btnCarregar";
            btnCarregar.Size = new Size(117, 41);
            btnCarregar.TabIndex = 6;
            btnCarregar.Text = "Carregar";
            btnCarregar.UseVisualStyleBackColor = true;
            btnCarregar.Click += btnCarregar_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Font = new Font("Segoe UI", 14F);
            btnAtualizar.Location = new Point(660, 404);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(121, 41);
            btnAtualizar.TabIndex = 7;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // FrmAtualizarViatura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 653);
            Controls.Add(btnAtualizar);
            Controls.Add(btnCarregar);
            Controls.Add(cboQuartel);
            Controls.Add(label3);
            Controls.Add(txtEstado);
            Controls.Add(label2);
            Controls.Add(cboViatura);
            Controls.Add(label1);
            Name = "FrmAtualizarViatura";
            Text = "FrmAtualizarViatura";
            Load += FrmAtualizarViatura_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboViatura;
        private Label label2;
        private TextBox txtEstado;
        private Label label3;
        private ComboBox cboQuartel;
        private Button btnCarregar;
        private Button btnAtualizar;
    }
}