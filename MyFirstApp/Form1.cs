using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyFirstApp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }             

        static bool MapDriveSST()
        {
            Form2 newForm = new Form2();
            NamePass auth = new NamePass();

            auth.ShowDialog();
            bool cancel = auth.cancel;
            if (!cancel)
            {
                string cmdString = "net use  \\\\" + newForm.ip_SST + "\\"+newForm.share_SST  +" /user:" + auth.GetName() + " " + auth.GetPass();
                ManagementClass processClass = new ManagementClass("Win32_Process");
                object[] methodArgs = { cmdString, null, null, 0 };
                object result = processClass.InvokeMethod("Create", methodArgs);
            }
            return cancel;
        }
        static bool MapDriveTU()
        {
            Form2 newForm = new Form2();
            NamePass auth = new NamePass();

            auth.ShowDialog();
            bool cancel = auth.cancel;
            if (!cancel)
            {
                string cmdString = "net use  \\\\" + newForm.ip_TU + "\\" +newForm.share_TU+" /user:" + auth.GetName() + " " + auth.GetPass();
                //MessageBox.Show(cmdString);
                ManagementClass processClass = new ManagementClass("Win32_Process");
                object[] methodArgs = { cmdString, null, null, 0 };
                object result = processClass.InvokeMethod("Create", methodArgs);
            }
            return cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();            
            newForm.Show();
        }

        private bool checkNum(char ch)
        {
            bool flag1;
            flag1 = false;
            if (ch == '0' || ch == '1'|| ch == '2'|| ch == '3'|| ch == '4'|| ch == '5'|| 
                ch == '6' || ch == '7' || ch == '8' || ch == '9') { flag1 = true; }        
            return flag1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!MapDriveSST())
            {
                
                string str, modific;
                str = textBox1.Text;

                List<string> modifications = new List<string>();

                Form2 newfrom = new Form2();
                string pathMod = newfrom.path_To_Mod;

                string pathToCopy = @"\\" + newfrom.ip_SST + @"\" + newfrom.share_SST+ newfrom.sst_2reg;

                for (short i = 0; i < str.Length; i++)
                {
                    modific = "";
                    while (checkNum(str[i]))
                    {
                        modific = modific+ str[i];
                        i++;
                        if (i == str.Length) { break; }
                    }
                    if (modific != "")
                    {
                        if (modific.Length == 1) { modifications.Add("00" + modific); }

                        else if (modific.Length == 2) { modifications.Add("0" + modific); }

                        else { modifications.Add(modific); }

                    }
                }

                int k = modifications.Count;
                MessageBox.Show("Количество модификация для копирования: " + k.ToString());
                short numOfFiles = 0;
                
                for (int i = 0; i < k ; i++)
                {
                    string nameFile = "o3000" + modifications[i];
                    for (byte j = 1; j <= 2; j++)
                    {
                        FileInfo fileInf7Z = new FileInfo(pathMod + nameFile + ".7z");
                        //MessageBox.Show("Путь до 7зип " + pathMod + nameFile + ".7z");
                        FileInfo fileInfSGN = new FileInfo(pathMod + nameFile + ".sgn");
                        //MessageBox.Show("Путь до сгн " + pathMod + nameFile + ".sgn");
                       // MessageBox.Show("Exist 7z" + fileInf7Z.Exists);
                        if (fileInf7Z.Exists)
                        {
                            fileInf7Z.CopyTo(pathToCopy + nameFile + ".7z", true);
                            numOfFiles++;
                        }
                        if (fileInfSGN.Exists)
                        {
                            fileInfSGN.CopyTo(pathToCopy + nameFile + ".sgn", true);
                            numOfFiles++;
                        }
                        nameFile = "b3000" + modifications[i];
                    }

                }
                MessageBox.Show("Скопировано " + numOfFiles.ToString() + " файлов.");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!MapDriveTU())
            {
                string str, str1;
                str = textBox1.Text;

                string[] mods = new string[100];

                short k = 0;
                Form2 newfrom = new Form2();
                string pathMod = newfrom.path_To_Mod;

                string pathToCopy = @"\\" + newfrom.ip_TU + @"\" + newfrom.share_TU+ newfrom.tu_2reg;

                for (int i = 0; i <= (str.Length - 1); i++)
                {
                    str1 = "";
                    while (checkNum(str[i]))
                    {
                        str1 = str1 + str[i];
                        i++;
                        if (i == str.Length) { break; }
                    }
                    if (str1 != "")
                    {
                        k++;
                        if (str1.Length == 1) { mods[k - 1] = "00" + str1; }

                        else if (str1.Length == 2) { mods[k - 1] = "0" + str1; }

                        else { mods[k - 1] = str1; }

                    }
                }

                MessageBox.Show("Количество модификация для копирования: " + k.ToString());
                short numOfFiles = 0;
                for (short i = 0; i <= k - 1; i++)
                {
                    string nameFile = "o3000" + mods[i];
                    for (byte j = 1; j <= 2; j++)
                    {
                        FileInfo fileInf7Z = new FileInfo(pathMod + nameFile + ".7z");

                        FileInfo fileInfSGN = new FileInfo(pathMod + nameFile + ".sgn");
                        if (fileInf7Z.Exists)
                        {
                            fileInf7Z.CopyTo(pathToCopy + nameFile + ".7z", true);
                            numOfFiles++;
                        }
                        if (fileInfSGN.Exists)
                        {
                            fileInfSGN.CopyTo(pathToCopy + nameFile + ".sgn", true);
                            numOfFiles++;
                        }
                        nameFile = "b3000" + mods[i];
                    }

                }
                MessageBox.Show("Скопировано " + numOfFiles.ToString() + " файлов.");

            }
        }
    }

   
}
