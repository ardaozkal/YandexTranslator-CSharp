using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YandexTranslate;

namespace YandexTranslatorExample
{
    public partial class Form1 : Form
    {
        YandexTranslator yt = new YandexTranslator();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://api.yandex.com/key/form.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = yt.translate(textBox3.Text, textBox2.Text, textBox5.Text, textBox6.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = yt.translate(textBox8.Text, textBox2.Text, textBox7.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = yt.detect(textBox4.Text, textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string output;
            if (yt.trydetect(textBox9.Text, textBox2.Text, out output))
            {
                label2.Text = output;
            }
            else
            {
                label2.Text = "Error!";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //More info on keys: http://api.yandex.com/translate/doc/dg/reference/detect.xml
            string output;
            int outputkey;
            if (yt.trydetect(textBox10.Text, textBox2.Text, out output, out outputkey))
            {
                label2.Text = output + " -----> key: " + outputkey;
            }
            else
            {
                label2.Text = "Error! Error's key: " + outputkey;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://translate.yandex.com/");
        }
    }
}
