using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace RenameKoreanDirectories
{
    public class Database
    {

        private string fileKeyName = "tsl.rod";
        private ProgressBar progressBar;

        public Database(ProgressBar progressBar)
        {
            this.progressBar = progressBar;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public Registro? ReadCurrent(string path)
        {
            var filePath = path + "\\" + fileKeyName;
            if (!File.Exists(filePath))
            {
                return null;
            } else
            {
                return JsonConvert.DeserializeObject<Registro>(File.ReadAllText(filePath));
            }
        }

        public Registro ProcessProject(string path)
        {
            var totalElements = CountTotalElements(path);
            
            PrepareProgressBar(totalElements);
            return CreateRegistro(path, true);
        }

        private int CountTotalElements(string path)
        {
            return 
                Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                    .Where(f => f != fileKeyName)
                    .Count() +
                Directory.GetDirectories(path, "*", SearchOption.AllDirectories).Count();
        }

        private Registro CreateRegistro(string path, bool isDirectory = true)
        {
 
            if (isDirectory ? !Directory.Exists(path) : !File.Exists(path))            {
                throw new Exception("Diretorio Inválido: " + path);
            }
            var registro = new Registro();
            registro.originalPath = path;
            registro.originalName = Path.GetFileNameWithoutExtension(path);
            registro.extension = Path.GetExtension(path);
            registro.converted = false;
            registro.isDirectory = isDirectory;

            Rename(registro);
            if (isDirectory && registro.converted)
            {
                registro.children = Directory.GetDirectories(registro.newPath)
                        .Select(p => CreateRegistro(p, true))
                        .Concat(Directory.GetFiles(registro.newPath)
                            .Select(p => CreateRegistro(p, false))
                        )
                        .ToArray();
                WriteRegistro(registro.newPath, true, registro);
            }
            UpdateProgressBar();
            return registro;
        }

        private void WriteRegistro(string path, bool isNormalizing, Registro registro)
        {
            try
            {
                File.WriteAllText(path + "\\" + fileKeyName, JsonConvert.SerializeObject(registro));
            } catch(Exception ex)
            {
                registro.converted = !isNormalizing;
                var errorMsg = "Falha: " + ex.Message;
                registro.status = String.IsNullOrEmpty(registro.status) ? errorMsg : registro.status + "\n" + errorMsg;
            }
        }

        public void LimpaRegistro(Registro registro)
        {
            int total = 1 + (registro.children?.Count() > 0 ? registro.children.Count() : 0);
            PrepareProgressBar(total);
            ExuctaLimpaRegistro(registro);
        }

        private Registro ExuctaLimpaRegistro(Registro registro)
        {
            if (registro.isDirectory)
            {
                File.Delete(registro.originalPath + "\\" + fileKeyName);
            }
            registro.children?.ToList().ForEach(r => ExuctaLimpaRegistro(r));
            UpdateProgressBar();
            return registro;
        }

        public void LimpaByPath(string path)
        {
            var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories)
                .ToList();
            directories.Add(path);
            PrepareProgressBar(directories.Count);
            directories.ForEach(directory =>
            {
                File.Delete(directory + "\\" + fileKeyName);
                UpdateProgressBar();
            });
        }


        private void Rename(Registro registro)
        {
            var iso = Encoding.GetEncoding(1252);
            var korean = Encoding.GetEncoding(949);
            var convertedName = iso.GetString(korean.GetBytes(registro.originalName));
            var fullName = registro.isDirectory ? convertedName : convertedName + registro.extension;
            var newPath = Path.GetDirectoryName(registro.originalPath) + "\\" + fullName;
            registro.newName = convertedName;
            registro.newPath = newPath;

            try
            {
                if (registro.newPath != registro.originalPath)
                {
                    if (registro.isDirectory)
                        Directory.Move(registro.originalPath, newPath);
                    else
                        File.Move(registro.originalPath, newPath);
                }

                registro.converted = true;
                registro.status = "Sucesso";
            } catch(Exception ex)
            {
                var result = MessageBox.Show(
                    $"Erro ao tentar renomear '{registro.originalName}' para '{fullName}'. Normalmente pode ocorrer se o diretorio estiver aberto em algum programa ou arquivo. \nDetalhes do erro: {ex.Message}.",
                    "Erro",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                );

                if (result == DialogResult.Retry)
                {
                    Rename(registro);
                } else
                {
                    registro.converted = false;
                    var errorMsg = "Falha: " + ex.Message;
                    registro.status = String.IsNullOrEmpty(registro.status) ? errorMsg : registro.status + "\n" + errorMsg;
                }
            }
        }

        private void RenameBack(Registro registro)
        {
            try
            {
                if (registro.originalPath != registro.newPath)
                {
                    if (registro.isDirectory)
                        Directory.Move(registro.newPath, registro.originalPath);
                    else
                        File.Move(registro.newPath, registro.originalPath);
                }

                registro.converted = false;
                registro.status = "Sucesso";
            }
            catch (Exception ex)
            {
                var result = MessageBox.Show(
                    $"Erro ao tentar renomear '{registro.newName}' para '{registro.originalName}'. Normalmente pode ocorrer se o diretorio estiver aberto em algum programa ou arquivo. \nDetalhes do erro: {ex.Message}.",
                    "Erro",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                );

                if (result == DialogResult.Retry)
                {
                    RenameBack(registro);
                }
                else
                {
                    registro.converted = true;
                    var errorMsg = "Falha: " + ex.Message;
                    registro.status = String.IsNullOrEmpty(registro.status) ? errorMsg : registro.status + "\n" + errorMsg;

                }
            }
        }

        public Registro RenameProjectToOriginal(Registro registro)
        {
            var total = CountTotalElements(registro.newPath);
            PrepareProgressBar(total);
            return ExecuteRenameProjectToOriginal(registro);
        }

        private Registro ExecuteRenameProjectToOriginal(Registro registro)
        {
            registro.children?
                .ToList()
                .ForEach(c => ExecuteRenameProjectToOriginal(c));
            RenameBack(registro);
            if (registro.isDirectory)
            {
                WriteRegistro(registro.originalPath, false, registro);
            }
            UpdateProgressBar();
            return registro;
        }

        private void PrepareProgressBar(int total)
        {
            progressBar.Maximum = total;
            progressBar.Value = 0;
            progressBar.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
        }

        private void UpdateProgressBar()
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value += 1;
            } else
            {
                progressBar.Visible = false;
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
