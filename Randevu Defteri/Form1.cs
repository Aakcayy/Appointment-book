using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Randevu_Defteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void buttonRandevuAl_Click(object sender, EventArgs e)
        {
            bool randevuonay = true;
            string FileName = "Randevu Defteri.txt";
            string[] lines = File.ReadAllLines(FileName);
            string aranantarih = dateTimePicker1.Text;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Tüm alanları doldurmak zorunludur.");
            }
            if (textBox1.Text != "")
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(aranantarih))
                    {
                        MessageBox.Show(aranantarih + " tarihinde başka bir randevu mevcuttur.Lütfen başka tarihe randevu alınız.");
                        randevuonay = false;
                        break;
                    }

                }

            }
            if (randevuonay != false && textBox1.Text!="")
            {
                if (!File.Exists(FileName))
                {
                    FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate);

                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.WriteLine("Sayın" + " " + textBox1.Text + " " + dateTimePicker1.Text);

                    }

                }
                else
                {
                    FileStream fs = new FileStream(FileName, FileMode.Append);
                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.WriteLine("Sayın" + " " + textBox1.Text + " " + dateTimePicker1.Text);
                    }


                }
                string appointmentDate = dateTimePicker1.Value.Date.ToString("dd.MM.yyyy");
                MessageBox.Show("Randevunuz >> " + textBox1.Text + "  " + dateTimePicker1.Text + "  " + "tarihindedir" + "\nİyi Günler");
            }
        }








        private void buttonRandevular_Click(object sender, EventArgs e)
        {
            string FileName = "Randevu Defteri.txt";
            string appointmentDate = dateTimePicker1.Value.Date.ToString("dd.MM.yyyy");
            listBox1.Items.Clear();
            int count = 0;
            using (StreamReader sr = new StreamReader(FileName)) //Okuma için
            {
                while (sr.Peek() > 0) //Erişilebilir karakter sayısı
                {
                    count++;
                    listBox1.Items.Add(count + "." + "Randevu>> " + sr.ReadLine() + "  " + "tarihindedir");

                }
            }
        }
    }
}
