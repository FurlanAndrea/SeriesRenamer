using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SeriesRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path;
        string name;

        private void button1_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            name = path.Split('\\').Last() + "E";
            if (checkBox1.Checked) rename("mkv");
            if (checkBox2.Checked) rename("srt");
            if (checkBox3.Checked) rename("mp3");
            if (checkBox4.Checked) rename("mp4");
        }

        private void rename(string ext)
        {
            string[] files = Directory.GetFiles(path, "*." + ext);
            int count = (checkBox5.Checked) ? Convert.ToInt32(textBox2.Text) : 1;
            foreach(string f in files)
            {
                File.Move(f, path + "\\" + name + ((count < 10)?"0":"") + count + "." + ext);
                count++;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox5.Checked;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            textBox1.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
