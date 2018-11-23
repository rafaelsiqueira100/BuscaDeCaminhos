namespace _16189_16191_Projeto4ED
{
    partial class frmAcharCaminho
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
            this.gbMetodo = new System.Windows.Forms.GroupBox();
            this.rbDijkstra = new System.Windows.Forms.RadioButton();
            this.rbBacktracking = new System.Windows.Forms.RadioButton();
            this.rbRecursao = new System.Windows.Forms.RadioButton();
            this.btnManterCidades = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.btnAcharCaminhos = new System.Windows.Forms.Button();
            this.lsbCaminhos = new System.Windows.Forms.ListBox();
            this.gbMetodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMetodo
            // 
            this.gbMetodo.Controls.Add(this.rbDijkstra);
            this.gbMetodo.Controls.Add(this.rbBacktracking);
            this.gbMetodo.Controls.Add(this.rbRecursao);
            this.gbMetodo.Location = new System.Drawing.Point(12, 12);
            this.gbMetodo.Name = "gbMetodo";
            this.gbMetodo.Size = new System.Drawing.Size(241, 48);
            this.gbMetodo.TabIndex = 0;
            this.gbMetodo.TabStop = false;
            this.gbMetodo.Text = "Método";
            // 
            // rbDijkstra
            // 
            this.rbDijkstra.AutoSize = true;
            this.rbDijkstra.Location = new System.Drawing.Point(177, 19);
            this.rbDijkstra.Name = "rbDijkstra";
            this.rbDijkstra.Size = new System.Drawing.Size(60, 17);
            this.rbDijkstra.TabIndex = 2;
            this.rbDijkstra.TabStop = true;
            this.rbDijkstra.Text = "Dijkstra";
            this.rbDijkstra.UseVisualStyleBackColor = true;
            // 
            // rbBacktracking
            // 
            this.rbBacktracking.AutoSize = true;
            this.rbBacktracking.Location = new System.Drawing.Point(83, 19);
            this.rbBacktracking.Name = "rbBacktracking";
            this.rbBacktracking.Size = new System.Drawing.Size(88, 17);
            this.rbBacktracking.TabIndex = 1;
            this.rbBacktracking.TabStop = true;
            this.rbBacktracking.Text = "Backtracking";
            this.rbBacktracking.UseVisualStyleBackColor = true;
            // 
            // rbRecursao
            // 
            this.rbRecursao.AutoSize = true;
            this.rbRecursao.Location = new System.Drawing.Point(6, 19);
            this.rbRecursao.Name = "rbRecursao";
            this.rbRecursao.Size = new System.Drawing.Size(71, 17);
            this.rbRecursao.TabIndex = 0;
            this.rbRecursao.TabStop = true;
            this.rbRecursao.Text = "Recursão";
            this.rbRecursao.UseVisualStyleBackColor = true;
            // 
            // btnManterCidades
            // 
            this.btnManterCidades.Location = new System.Drawing.Point(384, 12);
            this.btnManterCidades.Name = "btnManterCidades";
            this.btnManterCidades.Size = new System.Drawing.Size(75, 48);
            this.btnManterCidades.TabIndex = 1;
            this.btnManterCidades.Text = "Manter Cidades";
            this.btnManterCidades.UseVisualStyleBackColor = true;
            this.btnManterCidades.Click += new System.EventHandler(this.btnManterCidades_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cidade de origem:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cidade de destino:";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(357, 96);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(102, 20);
            this.txtDestino.TabIndex = 4;
            // 
            // txtOrigem
            // 
            this.txtOrigem.Location = new System.Drawing.Point(357, 70);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(102, 20);
            this.txtOrigem.TabIndex = 5;
            // 
            // btnAcharCaminhos
            // 
            this.btnAcharCaminhos.Location = new System.Drawing.Point(259, 129);
            this.btnAcharCaminhos.Name = "btnAcharCaminhos";
            this.btnAcharCaminhos.Size = new System.Drawing.Size(200, 23);
            this.btnAcharCaminhos.TabIndex = 6;
            this.btnAcharCaminhos.Text = "Achar caminhos";
            this.btnAcharCaminhos.UseVisualStyleBackColor = true;
            this.btnAcharCaminhos.Click += new System.EventHandler(this.btnAcharCaminhos_Click);
            // 
            // lsbCaminhos
            // 
            this.lsbCaminhos.FormattingEnabled = true;
            this.lsbCaminhos.Location = new System.Drawing.Point(259, 158);
            this.lsbCaminhos.Name = "lsbCaminhos";
            this.lsbCaminhos.Size = new System.Drawing.Size(200, 82);
            this.lsbCaminhos.TabIndex = 7;
            // 
            // frmAcharCaminho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 245);
            this.Controls.Add(this.lsbCaminhos);
            this.Controls.Add(this.btnAcharCaminhos);
            this.Controls.Add(this.txtOrigem);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnManterCidades);
            this.Controls.Add(this.gbMetodo);
            this.Name = "frmAcharCaminho";
            this.Text = "Achar caminho entre cidades";
            this.gbMetodo.ResumeLayout(false);
            this.gbMetodo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMetodo;
        private System.Windows.Forms.RadioButton rbDijkstra;
        private System.Windows.Forms.RadioButton rbBacktracking;
        private System.Windows.Forms.RadioButton rbRecursao;
        private System.Windows.Forms.Button btnManterCidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Button btnAcharCaminhos;
        private System.Windows.Forms.ListBox lsbCaminhos;
    }
}

