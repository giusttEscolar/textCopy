using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EX_EditorBase_3J_13
{
    public partial class Form1 : Form
    {

        StreamReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exibirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoArquivo();
        }

        private void NovoArquivo()
        {
            rtbText.Clear();
            rtbText.Focus();
        }

        private void Novo_Click(object sender, EventArgs e)
        {
            NovoArquivo();
        }

        private void Abrir_Click(object sender, EventArgs e)
        {
            abrirArquivo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirArquivo();
        }

        private void abrirArquivo()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\logon\Documents";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "*.TXT|*txt|Todos Arquivos (*.*)|*.*";

            try
            {
                if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(arquivo);
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.rtbText.Text = "";
                    string linha = sr.ReadLine();
                    while(linha != null)
                    {
                        this.rtbText.Text += linha + "\n";
                        linha = sr.ReadLine();
                    }
                    sr.Close();
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Erro Ao Abrir: " + ex.Message, "giustt's Notepad Says", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvarArquivo();
        }

        private void salvarArquivo()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(arquivo);
                    sw.Flush();
                    sw.BaseStream.Seek(0, SeekOrigin.Begin);
                    sw.Write(this.rtbText.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao Salvar: " + ex.Message, "Notepad By Giustt Informa:",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
