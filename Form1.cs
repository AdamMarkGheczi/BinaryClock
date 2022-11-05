using System;
using System.Drawing;
using System.Windows.Forms;

namespace BinaryClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] seconds = new PictureBox[7];
        PictureBox[] minutes = new PictureBox[7];
        PictureBox[] hours = new PictureBox[6];
        private void Form1_Load(object sender, EventArgs e)
        {

            seconds[0] = pictureBox1;
            seconds[1] = pictureBox2;
            seconds[2] = pictureBox3;
            seconds[3] = pictureBox4;
            seconds[4] = pictureBox5;
            seconds[5] = pictureBox6;
            seconds[6] = pictureBox7;

            minutes[0] = pictureBox8;
            minutes[1] = pictureBox9;
            minutes[2] = pictureBox10;
            minutes[3] = pictureBox11;
            minutes[4] = pictureBox12;
            minutes[5] = pictureBox13;
            minutes[6] = pictureBox14;

            hours[0] = pictureBox15;
            hours[1] = pictureBox16;
            hours[2] = pictureBox17;
            hours[3] = pictureBox18;
            hours[4] = pictureBox19;
            hours[5] = pictureBox20;

            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        /// <summary> Returnează cifrele lui s în ordine inversă, sub forma little endian BCD </summary>
        /// <example> De exemplu din numărul 13 rezultă 11001000 </example>
        public string convertStringToBinary(string s)
        {
            int x = int.Parse(s[1].ToString());
            int y = int.Parse(s[0].ToString());

            string result = "";

            for (int i = 1; i <= 4; i++)
            {
                result += x % 2;
                x /= 2;
            }

            for (int i = 1; i <= 4; i++)
            {
                result += y % 2;
                y /= 2;
            }

            return result;
        }
        
        public void displayBinarySegment(string x, PictureBox[] v)
        {
            for (int i = 0; i < v.Length; i++)
                if (x[i] == '1')
                    v[i].BackColor = Color.DarkCyan;
                else
                    v[i].BackColor = Color.White;
        }

        string h, m, s;

        DateTime date1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            date1 = DateTime.Now;

            h = date1.Hour < 10 ? "0" + date1.Hour.ToString() : date1.Hour.ToString();
            m = date1.Minute < 10 ? "0" + date1.Minute.ToString() : date1.Minute.ToString();
            s = date1.Second < 10 ? "0" + date1.Second.ToString() : date1.Second.ToString();

            textBox1.Text = $"{h}:{m}:{s}";

            displayBinarySegment(convertStringToBinary(s), seconds);
            displayBinarySegment(convertStringToBinary(m), minutes);
            displayBinarySegment(convertStringToBinary(h), hours);
        }
    }
}
