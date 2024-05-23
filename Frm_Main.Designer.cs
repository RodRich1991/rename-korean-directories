namespace RenameKoreanDirectories
{
    partial class Frm_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.MS_Principal = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.açõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limparDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Lbl_Path = new System.Windows.Forms.Label();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnKorean = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MS_Principal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MS_Principal
            // 
            this.MS_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.açõesToolStripMenuItem});
            this.MS_Principal.Location = new System.Drawing.Point(0, 0);
            this.MS_Principal.Name = "MS_Principal";
            this.MS_Principal.Size = new System.Drawing.Size(509, 24);
            this.MS_Principal.TabIndex = 0;
            this.MS_Principal.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Enabled = false;
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // açõesToolStripMenuItem
            // 
            this.açõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalizarToolStripMenuItem,
            this.originalToolStripMenuItem,
            this.limparDadosToolStripMenuItem});
            this.açõesToolStripMenuItem.Name = "açõesToolStripMenuItem";
            this.açõesToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.açõesToolStripMenuItem.Text = "Ações";
            // 
            // normalizarToolStripMenuItem
            // 
            this.normalizarToolStripMenuItem.Enabled = false;
            this.normalizarToolStripMenuItem.Name = "normalizarToolStripMenuItem";
            this.normalizarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.normalizarToolStripMenuItem.Text = "Normalizar";
            this.normalizarToolStripMenuItem.Click += new System.EventHandler(this.normalizarToolStripMenuItem_Click);
            // 
            // originalToolStripMenuItem
            // 
            this.originalToolStripMenuItem.Enabled = false;
            this.originalToolStripMenuItem.Name = "originalToolStripMenuItem";
            this.originalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.originalToolStripMenuItem.Text = "Original";
            this.originalToolStripMenuItem.Click += new System.EventHandler(this.originalToolStripMenuItem_Click);
            // 
            // limparDadosToolStripMenuItem
            // 
            this.limparDadosToolStripMenuItem.Enabled = false;
            this.limparDadosToolStripMenuItem.Name = "limparDadosToolStripMenuItem";
            this.limparDadosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.limparDadosToolStripMenuItem.Text = "Limpar dados";
            this.limparDadosToolStripMenuItem.Click += new System.EventHandler(this.limparDadosToolStripMenuItem_Click);
            // 
            // Lbl_Path
            // 
            this.Lbl_Path.AllowDrop = true;
            this.Lbl_Path.AutoEllipsis = true;
            this.Lbl_Path.AutoSize = true;
            this.Lbl_Path.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.Lbl_Path.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Lbl_Path.Location = new System.Drawing.Point(6, 19);
            this.Lbl_Path.Name = "Lbl_Path";
            this.Lbl_Path.Size = new System.Drawing.Size(0, 21);
            this.Lbl_Path.TabIndex = 1;
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNormal.BackgroundImage = global::RenameKoreanDirectories.Properties.Resources.abc;
            this.btnNormal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNormal.Enabled = false;
            this.btnNormal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNormal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnNormal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNormal.Location = new System.Drawing.Point(186, 111);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(108, 67);
            this.btnNormal.TabIndex = 2;
            this.btnNormal.Text = "Normalizar";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnKorean
            // 
            this.btnKorean.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKorean.BackgroundImage = global::RenameKoreanDirectories.Properties.Resources.korean;
            this.btnKorean.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnKorean.Enabled = false;
            this.btnKorean.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKorean.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnKorean.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKorean.Location = new System.Drawing.Point(185, 184);
            this.btnKorean.Name = "btnKorean";
            this.btnKorean.Size = new System.Drawing.Size(109, 67);
            this.btnKorean.TabIndex = 3;
            this.btnKorean.Text = "Original";
            this.btnKorean.UseVisualStyleBackColor = true;
            this.btnKorean.Click += new System.EventHandler(this.btnKorean_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(11, 257);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(468, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Lbl_Path);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnNormal);
            this.groupBox1.Controls.Add(this.btnKorean);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 286);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(509, 325);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MS_Principal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MS_Principal;
            this.Name = "Frm_Main";
            this.Text = "Rename Tabajaras";
            this.MS_Principal.ResumeLayout(false);
            this.MS_Principal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MS_Principal;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private Label Lbl_Path;
        private Button btnNormal;
        private Button btnKorean;
        private ToolStripMenuItem açõesToolStripMenuItem;
        private ToolStripMenuItem normalizarToolStripMenuItem;
        private ToolStripMenuItem originalToolStripMenuItem;
        private ToolStripMenuItem limparDadosToolStripMenuItem;
        private ProgressBar progressBar1;
        private ToolStripMenuItem fecharToolStripMenuItem;
        private GroupBox groupBox1;
    }
}