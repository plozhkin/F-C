﻿using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstApp
{
    public partial class Form2 : Form
    {
        public string ip_TU, ip_SST, share_TU, share_SST, path_To_Mod;
        public void parse_File()
        {
            using (FileStream fstream = File.OpenRead(@"D:\Test\settings.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                fstream.Close();
                string subStrBegin, subStrEnd;
                subStrBegin = "IP_TU=";
                int indexOfSubstring = textFromFile.IndexOf(subStrBegin);
                subStrEnd = "IP_SST=";
                int indexOfSubstringEnd = textFromFile.IndexOf(subStrEnd);
                ip_TU = textFromFile.Substring(indexOfSubstring + subStrBegin.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                indexOfSubstring = indexOfSubstringEnd;
                subStrBegin = "IP_SST=";
                subStrEnd = "SHARE_TU=";
                indexOfSubstringEnd = textFromFile.IndexOf(subStrEnd);
                ip_SST = textFromFile.Substring(indexOfSubstring + subStrBegin.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                indexOfSubstring = indexOfSubstringEnd;
                subStrBegin = "SHARE_TU=";
                subStrEnd = "SHARE_SST=";
                indexOfSubstringEnd = textFromFile.IndexOf(subStrEnd);
                share_TU = textFromFile.Substring(indexOfSubstring + subStrBegin.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                indexOfSubstring = indexOfSubstringEnd;
                subStrBegin = "SHARE_SST=";
                subStrEnd = "PATH_TO_MOD=";
                indexOfSubstringEnd = textFromFile.IndexOf(subStrEnd);
                share_SST = textFromFile.Substring(indexOfSubstring + subStrBegin.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                indexOfSubstring = indexOfSubstringEnd;
                indexOfSubstringEnd = textFromFile.Length;
                path_To_Mod = textFromFile.Substring(indexOfSubstring + subStrEnd.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                // MessageBox.Show("Текст из файла: {0}"+ textFromFile);

            }
        }
        public void save_to_file()
        {
            using (FileStream fstream = new FileStream(@"D:\test\settings.txt", FileMode.OpenOrCreate))
            {
                string textToFile;
                textToFile = "IP_TU=" + this.textBox1.Text + "\r\nIP_SST=" + this.textBox3.Text + "\r\nSHARE_TU=" +
                    this.textBox2.Text + "\r\nSHARE_SST=" + this.textBox4.Text + "\r\nPATH_TO_MOD=" + this.textBox5.Text + "\r\n";
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(textToFile);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                fstream.Close();
            }
        }

        
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 form)
        {
            InitializeComponent();
            parse_File();
            this.textBox1.Text = this.ip_TU;
            this.textBox2.Text = this.share_TU;
            this.textBox3.Text = this.ip_SST;
            this.textBox4.Text = this.share_SST;
            this.textBox5.Text = this.path_To_Mod;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           // this.BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetModPath()
        {
            return this.textBox5.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.save_to_file(); 

        }
    }
}
