namespace GestaoViaturasWinForms
{
    partial class FrmRequisicoesLote
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
            cboOperacao = new ComboBox();
            label2 = new Label();
            cboMilitar = new ComboBox();
            label3 = new Label();
            cboUnidade = new ComboBox();
            label4 = new Label();
            dtSaida = new DateTimePicker();
            label5 = new Label();
            dtRegresso = new DateTimePicker();
            label6 = new Label();
            dtSaidaEfetiva = new DateTimePicker();
            dgvViaturas = new DataGridView();
            btnAdd = new Button();
            btnRemove = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvViaturas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 36);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 0;
            label1.Text = "Operação";
            label1.Click += label1_Click;
            // 
            // cboOperacao
            // 
            cboOperacao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOperacao.DropDownWidth = 350;
            cboOperacao.FormattingEnabled = true;
            cboOperacao.Location = new Point(221, 28);
            cboOperacao.Name = "cboOperacao";
            cboOperacao.Size = new Size(151, 28);
            cboOperacao.TabIndex = 1;
            cboOperacao.SelectedIndexChanged += cboOperacao_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 91);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 2;
            label2.Text = "Militar";
            // 
            // cboMilitar
            // 
            cboMilitar.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMilitar.FormattingEnabled = true;
            cboMilitar.Location = new Point(221, 83);
            cboMilitar.Name = "cboMilitar";
            cboMilitar.Size = new Size(151, 28);
            cboMilitar.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 139);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 4;
            label3.Text = "Unidade Militar";
            // 
            // cboUnidade
            // 
            cboUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnidade.DropDownWidth = 350;
            cboUnidade.FormattingEnabled = true;
            cboUnidade.Location = new Point(221, 136);
            cboUnidade.Name = "cboUnidade";
            cboUnidade.Size = new Size(151, 28);
            cboUnidade.TabIndex = 5;
            cboUnidade.SelectedIndexChanged += cboUnidade_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(417, 43);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 6;
            label4.Text = "Data Saída";
            // 
            // dtSaida
            // 
            dtSaida.Format = DateTimePickerFormat.Short;
            dtSaida.Location = new Point(505, 36);
            dtSaida.Name = "dtSaida";
            dtSaida.Size = new Size(250, 27);
            dtSaida.TabIndex = 7;
            dtSaida.ValueChanged += dtSaida_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(407, 96);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 8;
            label5.Text = "Data Regresso";
            // 
            // dtRegresso
            // 
            dtRegresso.Format = DateTimePickerFormat.Short;
            dtRegresso.Location = new Point(518, 91);
            dtRegresso.Name = "dtRegresso";
            dtRegresso.Size = new Size(250, 27);
            dtRegresso.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(392, 160);
            label6.Name = "label6";
            label6.Size = new Size(131, 20);
            label6.TabIndex = 10;
            label6.Text = "Data Saída Efetiva";
            // 
            // dtSaidaEfetiva
            // 
            dtSaidaEfetiva.Format = DateTimePickerFormat.Short;
            dtSaidaEfetiva.Location = new Point(538, 155);
            dtSaidaEfetiva.Name = "dtSaidaEfetiva";
            dtSaidaEfetiva.Size = new Size(250, 27);
            dtSaidaEfetiva.TabIndex = 11;
            // 
            // dgvViaturas
            // 
            dgvViaturas.AllowUserToAddRows = false;
            dgvViaturas.AllowUserToDeleteRows = false;
            dgvViaturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViaturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvViaturas.Location = new Point(110, 194);
            dgvViaturas.MultiSelect = false;
            dgvViaturas.Name = "dgvViaturas";
            dgvViaturas.RowHeadersWidth = 51;
            dgvViaturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvViaturas.Size = new Size(300, 188);
            dgvViaturas.TabIndex = 12;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 14F);
            btnAdd.Location = new Point(452, 208);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(47, 45);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Font = new Font("Segoe UI", 14F);
            btnRemove.Location = new Point(452, 290);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(47, 47);
            btnRemove.TabIndex = 14;
            btnRemove.Text = "-";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LimeGreen;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(379, 409);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmRequisicoesLote
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 653);
            Controls.Add(btnGuardar);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(dgvViaturas);
            Controls.Add(dtSaidaEfetiva);
            Controls.Add(label6);
            Controls.Add(dtRegresso);
            Controls.Add(label5);
            Controls.Add(dtSaida);
            Controls.Add(label4);
            Controls.Add(cboUnidade);
            Controls.Add(label3);
            Controls.Add(cboMilitar);
            Controls.Add(label2);
            Controls.Add(cboOperacao);
            Controls.Add(label1);
            Name = "FrmRequisicoesLote";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Requisição de Viaturas";
            Load += FrmRequisicoesLote_Load;
            ((System.ComponentModel.ISupportInitialize)dgvViaturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboOperacao;
        private Label label2;
        private ComboBox cboMilitar;
        private Label label3;
        private ComboBox cboUnidade;
        private Label label4;
        private DateTimePicker dtSaida;
        private Label label5;
        private DateTimePicker dtRegresso;
        private Label label6;
        private DateTimePicker dtSaidaEfetiva;
        private DataGridView dgvViaturas;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnGuardar;
    }
}