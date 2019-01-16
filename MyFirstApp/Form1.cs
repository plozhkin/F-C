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
    public partial class Form1 : Form
    {
        //Point moveStart;
        //SortedSet<char> s1 = new SortedSet<char>();
        public Form1()
        {
            InitializeComponent();
            //s1.Add('0');
            //s1.Add('1');
            //s1.Add('2');
            //s1.Add('3');
            //s1.Add('4');
            //s1.Add('5');
            //s1.Add('6');
            //s1.Add('7');
            //s1.Add('8');
            //s1.Add('9');                  
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.BackColor = Color.Yellow;
            //Button button2 = new Button
            //{
            //    Location = new Point
            //    {
            //        X = this.Width / 2,
            //        Y = this.Height / 2
            //    }
            //};
            //button2.Text = "Close";
            //button2.Click += button2_Click;
            //this.Controls.Add(button2);
            //this.Load += Form1_Load;
            //this.MouseDown += Form1_MouseDown;
            //this.MouseMove += Form1_MouseMove;


        }
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
        //    // создаем эллипс с высотой и шириной формы
        //    myPath.AddEllipse(0, 0, this.Width, this.Height);
        //    // создаем с помощью элипса ту область формы, которую мы хотим видеть
        //    Region myRegion = new Region(myPath);
        //    // устанавливаем видимую область
        //    this.Region = myRegion;
        //}

        //private void Form1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    // если нажата левая кнопка мыши
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        moveStart = new Point(e.X, e.Y);
        //    }
        //}
        //private void Form1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    // если нажата левая кнопка мыши
        //    if ((e.Button & MouseButtons.Left) != 0)
        //    {
        //        // получаем новую точку положения формы
        //        Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
        //        // устанавливаем положение формы
        //        this.Location = new Point(this.Location.X + deltaPos.X,
        //          this.Location.Y + deltaPos.Y);
        //    }
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this)
            {
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            };
            
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
            string str,str1;
            str = textBox1.Text;
            string[] mods = new string[100];
            int k = 0;

            for (int i = 0; i <= (str.Length-1); i++)
            {                
                str1 = "";
                while (checkNum(str[i]))
                {                    
                    str1 = str1 + str[i];
                    i++;
                    if (i==str.Length) { break; }
                }
                if (str1 != "")
                {
                    k++;
                    mods[k - 1] = str1;
                }
            }
            MessageBox.Show("Количество модификация для копирования: "+k.ToString());

            //for (int i=0; i<=k-1; i++)
            //{
            //    MessageBox.Show(mods[i]);
            //}
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
