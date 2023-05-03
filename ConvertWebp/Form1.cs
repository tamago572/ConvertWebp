using ImageProcessor.Plugins.WebP.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertWebp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "画像ファイル|*.png;*.jpg;*.jpeg;*.bmp;*.gif;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                textBox1.Text = openFileDialog1.FileName;
                label2.Visible = true;
                Console.WriteLine("FileName: "+openFileDialog1.SafeFileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chooseBtn2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.Description = "保存先を指定";
            if(folderBrowserDialog2.ShowDialog() == DialogResult.OK )
            {
                textBox2.Text = folderBrowserDialog2.SelectedPath;
            }

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void conv_btn_Click(object sender, EventArgs e)
        {
            if(!(textBox1.Text == "" || textBox2.Text == ""))
            {
                DialogResult dr = MessageBox.Show("変換を開始してもよろしいですか？", "確認", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    Console.WriteLine("変換します！");
                    conv_Img(openFileDialog1, folderBrowserDialog2);
                }
                else 
                { 
                    Console.WriteLine("変換はキャンセルされたようです！");
                }
            }
            else
            {
                Console.WriteLine("ファイルと保存先が指定されていないようです！");
                MessageBox.Show("ファイルと保存先のどっちかまたは両方が指定されていないようです！","IF文によって実行を止めました");
            }
        }

        private void conv_Img(OpenFileDialog filePath, FolderBrowserDialog folderPath)
        {
            var wf = new WebPFormat();
            using (var image = new Bitmap(filePath.FileName))
            {
                wf.Save(folderPath.SelectedPath +@"\"+filePath.SafeFileName+".webp", image, 0);
            }

            MessageBox.Show("変換が終了しました！", "おしらせ");
        }
    }
}
