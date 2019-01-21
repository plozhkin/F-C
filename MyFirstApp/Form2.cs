using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MyFirstApp
{
    

    public partial class Form2 : Form
    {
        public string ip_TU, ip_SST, share_TU, share_SST, path_To_Mod, sst_2reg, tu_2reg;
        public bool debug;
       /* public void parse_File()
        {
            using (FileStream fstream = File.OpenRead("settings.cfg"))
            {
                byte[] array = new byte[fstream.Length];

                fstream.Read(array, 0, array.Length);
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
                subStrEnd = "TU_2REG=";
                indexOfSubstringEnd = textFromFile.IndexOf(subStrEnd);
                share_SST = textFromFile.Substring(indexOfSubstring + subStrBegin.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                indexOfSubstring = indexOfSubstringEnd;
                subStrBegin = "TU_2REG=";
                subStrEnd = "SST_2REG=";
                indexOfSubstringEnd = textFromFile.IndexOf(subStrEnd);
                tu_2reg = textFromFile.Substring(indexOfSubstring + subStrBegin.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                indexOfSubstring = indexOfSubstringEnd;
                subStrBegin = "SST_2REG=";
                subStrEnd = "DEBUG=";
                indexOfSubstringEnd = textFromFile.IndexOf(subStrEnd);
                sst_2reg = textFromFile.Substring(indexOfSubstring + subStrBegin.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                indexOfSubstring = indexOfSubstringEnd;
                subStrBegin = "DEBUG=";
                subStrEnd = "PATH_TO_MOD=";
                indexOfSubstringEnd = textFromFile.IndexOf(subStrEnd);
                debug = textFromFile.Substring(indexOfSubstring + subStrBegin.Length, indexOfSubstringEnd - indexOfSubstring - subStrBegin.Length - 2);

                indexOfSubstring = indexOfSubstringEnd;
                indexOfSubstringEnd = textFromFile.Length;
                path_To_Mod = textFromFile.Substring(indexOfSubstring + subStrEnd.Length, indexOfSubstringEnd - indexOfSubstring - subStrEnd.Length);

                // MessageBox.Show("Текст из файла: {0}"+ textFromFile);

            }
        }*/
       /* public void save_to_file()
        {
            using (FileStream fstream = new FileStream("settings.cfg", FileMode.Create))
            {
                string textToFile;

                textToFile = "IP_TU=" + this.textBox1.Text + "\r\nIP_SST=" + this.textBox3.Text + "\r\nSHARE_TU=" +
                    this.textBox2.Text + "\r\nSHARE_SST=" + this.textBox4.Text + "\r\nTU_2REG=" + this.textBox6.Text+
                     "\r\nSST_2REG=" + this.textBox7.Text + "\r\nDEBUG=" + this.check_debug + "\r\nPATH_TO_MOD=" + this.textBox5.Text;
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(textToFile);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                fstream.Close();
            }
        }*/

        
        public Form2()
        {
            InitializeComponent();
            Deserializing();
            //parse_File();
            //this.textBox1.Text = this.ip_TU;
            //this.textBox2.Text = this.share_TU;
            //this.textBox3.Text = this.ip_SST;
            //this.textBox4.Text = this.share_SST;
            //this.textBox5.Text = this.path_To_Mod;
            //this.textBox6.Text = this.tu_2reg;
            //this.textBox7.Text = this.sst_2reg;
            //if (this.debug == "1") this.checkBox1.Checked = true;
            //else this.checkBox1.Checked = false;           
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Serializing();
            MessageBox.Show("Настройки сохранены");
        }
       
        private void Serializing()
        {
            Settings TU = new Settings();
            TU.Ip_Adress = this.textBox1.Text;
            TU.Share = this.textBox2.Text;
            TU.Path_To_2regions = this.textBox6.Text;
            TU.Path_To_Mod = this.textBox5.Text;
            TU.Debug = this.checkBox1.Checked;
            TU.Type_Of_Sys = "TU";

            Settings SST = new Settings();
            SST.Ip_Adress = this.textBox3.Text;
            SST.Share = this.textBox4.Text;
            SST.Path_To_2regions = this.textBox7.Text;
            SST.Path_To_Mod = this.textBox5.Text;
            SST.Debug = this.checkBox1.Checked;
            SST.Type_Of_Sys = "SST";

            Settings[] settings = new Settings[] { TU, SST };

            XmlSerializer formatter = new XmlSerializer(typeof(Settings[]));

            using (FileStream fs = new FileStream("settings.xml", FileMode.Create))
            {
                formatter.Serialize(fs, settings);
            }
        }
        private void Deserializing()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Settings[]));
            using (FileStream fs = new FileStream("settings.xml", FileMode.OpenOrCreate))
            {
                Settings[] settings = (Settings[])formatter.Deserialize(fs);

                foreach (Settings set in settings)
                {
                    switch (set.Type_Of_Sys)
                    {
                        case "TU":
                            ip_TU=this.textBox1.Text=set.Ip_Adress;
                            share_TU= this.textBox2.Text= set.Share;
                            tu_2reg= this.textBox6.Text= set.Path_To_2regions;
                            path_To_Mod= this.textBox5.Text= set.Path_To_Mod;
                            debug = this.checkBox1.Checked= set.Debug;
                            break;
                        case "SST":
                            ip_SST= this.textBox3.Text = set.Ip_Adress;
                            share_SST= this.textBox4.Text = set.Share;
                            sst_2reg= this.textBox7.Text = set.Path_To_2regions;
                            break;
                    }
                }
            }
        }
    }
    [Serializable]
    public class Settings
    {
        public string Ip_Adress { get; set; }
        public string Share { get; set; }
        public string Path_To_2regions { get; set; }
        public bool Debug { get; set; }
        public string Path_To_Mod { get; set; }
        public string Type_Of_Sys { get; set; }
    }
}
