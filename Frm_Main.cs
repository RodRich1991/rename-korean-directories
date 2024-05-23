namespace RenameKoreanDirectories
{
    public partial class Frm_Main : Form
    {

        private string projectPath;
        private Registro? registroProjeto;
        private Database database;

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            projectPath = fbd.SelectedPath;
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(projectPath))
            {
                abrirToolStripMenuItem.Enabled = false;
                fecharToolStripMenuItem.Enabled = true;
                Lbl_Path.Text = projectPath;
                database = new Database(progressBar1);
                registroProjeto = database.ReadCurrent(projectPath);

                UpdateMainButtonStatus(registroProjeto != null && registroProjeto.converted == true);
            }
        }

        private void UpdateMainButtonStatus(bool Original)
        {
            if (Original)
            {
                changeOriginalButtonStatus(true);
                changeNormalizeButtonStatus(false);
            } else
            {
                changeOriginalButtonStatus(false);
                changeNormalizeButtonStatus(true);
            }
        }

        private void changeNormalizeButtonStatus(bool enabled)
        {
            btnNormal.Enabled = enabled;
            normalizarToolStripMenuItem.Enabled = enabled;

            if (enabled)
            {
                limparDadosToolStripMenuItem.Enabled = false;
            }
        }

        private void changeOriginalButtonStatus(bool enabled)
        {
            btnKorean.Enabled = enabled;
            originalToolStripMenuItem.Enabled = enabled;

            if (enabled)
            {
                limparDadosToolStripMenuItem.Enabled = true;
            }
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (registroProjeto != null && registroProjeto.converted)
            {
                MessageBox.Show("Este projeto já está convertido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            registroProjeto = database.ProcessProject(projectPath);
            if (registroProjeto.converted)
            {
                UpdateMainButtonStatus(true);
                Lbl_Path.Text = registroProjeto.newPath;
                MessageBox.Show("Projeto renomeado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                registroProjeto = null;
            }
        }

        private void normalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNormal_Click(sender, e);
        }

        private void limparDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (registroProjeto != null)
            {
                database.LimpaRegistro(registroProjeto);
                database.LimpaByPath(projectPath);
                registroProjeto = null;
                UpdateMainButtonStatus(false);
                MessageBox.Show("Projeto limpado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Nada a ser limpo", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirToolStripMenuItem.Enabled = true;
            fecharToolStripMenuItem.Enabled = false;
            Lbl_Path.Text = "";
            changeOriginalButtonStatus(false);
            changeNormalizeButtonStatus(false);
        }

        private void VoltarAoOriginal()
        {
            if (registroProjeto != null)
            {
                registroProjeto = database.RenameProjectToOriginal(registroProjeto);

                if (!registroProjeto.converted)
                {
                    UpdateMainButtonStatus(false);
                    Lbl_Path.Text = registroProjeto.originalPath;
                    MessageBox.Show("Projeto de volta ao original!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Projeto não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKorean_Click(object sender, EventArgs e)
        {
            VoltarAoOriginal();
        }

        private void originalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoltarAoOriginal();
        }
    }
}