namespace _16189_16191_Projeto4ED
{
    partial class frmManterCidades
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.btnIncluirCidade = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.btnIncluirAresta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cidade:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(61, 16);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(100, 20);
            this.txtCidade.TabIndex = 1;
            // 
            // btnIncluirCidade
            // 
            this.btnIncluirCidade.Location = new System.Drawing.Point(83, 70);
            this.btnIncluirCidade.Name = "btnIncluirCidade";
            this.btnIncluirCidade.Size = new System.Drawing.Size(78, 23);
            this.btnIncluirCidade.TabIndex = 2;
            this.btnIncluirCidade.Text = "Incluir cidade";
            this.btnIncluirCidade.UseVisualStyleBackColor = true;
            this.btnIncluirCidade.Click += new System.EventHandler(this.btnIncluirCidade_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cidade de origem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cidade de destino:";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(294, 44);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(100, 20);
            this.txtDestino.TabIndex = 5;
            // 
            // txtOrigem
            // 
            this.txtOrigem.Location = new System.Drawing.Point(294, 16);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(100, 20);
            this.txtOrigem.TabIndex = 6;
            // 
            // btnIncluirAresta
            // 
            this.btnIncluirAresta.Location = new System.Drawing.Point(316, 70);
            this.btnIncluirAresta.Name = "btnIncluirAresta";
            this.btnIncluirAresta.Size = new System.Drawing.Size(78, 23);
            this.btnIncluirAresta.TabIndex = 7;
            this.btnIncluirAresta.Text = "Incluir aresta";
            this.btnIncluirAresta.UseVisualStyleBackColor = true;
            this.btnIncluirAresta.Click += new System.EventHandler(this.btnIncluirAresta_Click);
            // 
            // frmManterCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 103);
            this.Controls.Add(this.btnIncluirAresta);
            this.Controls.Add(this.txtOrigem);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnIncluirCidade);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label1);
            this.Name = "frmManterCidades";
            this.Text = "Manter cidades";
            this.Load += new System.EventHandler(this.frmManterCidades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Button btnIncluirCidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Button btnIncluirAresta;
    }
}