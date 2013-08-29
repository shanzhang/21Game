using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace _21Game
{
    public partial class Form1 : Form
    {
        private GameController game;
        private Image back;

        public Form1()
        {
            InitializeComponent();
            skinEngine2.SkinFile = System.Environment.CurrentDirectory + "\\skins\\" + "mp10green.ssk";
            skinEngine2.Active = true;
            this.BackgroundImage = Image.FromFile("桌布.png");
            this.back = Image.FromFile("b.gif");
            BustOrNot.Visible = false;
            WinGame.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new GameController();
            button3.Enabled = false;
            button4.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;

            label1.Text = "Score: 1000";
            textBox1.Text = "0";
            pictureBox2.Image = back;

            label2.Text = "Result:";
            List<int> a = game.Controller(1, 0);

            Image img_banker_1 = Image.FromFile(a[2].ToString() + ".gif");
            Image img_banker_2 = Image.FromFile(a[3].ToString() + ".gif");
            Image img_player_1 = Image.FromFile(a[4].ToString() + ".gif");
            Image img_player_2 = Image.FromFile(a[5].ToString() + ".gif");

            pictureBox11.Image = img_player_1;
            pictureBox12.Image = img_player_2;

            if (a[0] == 1)
            {
                button3.Enabled = false;
                button4.Enabled = false;

                if (a[1] == 0)
                {
                    pictureBox1.Image = img_banker_1;
                    pictureBox2.Image = img_banker_2;
                    label2.Text = "Result:\nPush!";
                }
                if (a[1] == 1)
                {
                    pictureBox1.Image = img_banker_1;
                    pictureBox2.Image = img_banker_2;
                    label2.Text = "Result:\nLose!";
                    BustOrNot.Visible = true;
                    
                }
                if (a[1] == 2)
                {
                    pictureBox1.Image = img_banker_1;
                    pictureBox2.Image = img_banker_2;
                    label2.Text = "Result:\nWin!";
                    WinGame.Visible = true;
                }
                label1.Text = "Score: " + game.getPlayerScore().ToString();
            }
            else
            {
                pictureBox1.Image = img_banker_1;
            }

            //获得返回的数组知道 展示牌的号码

            //导入对应图片

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;

            button5.Enabled = true;
            textBox1.Enabled = true;

            label2.Text = "Result:";
            BustOrNot.Visible = false;
            WinGame.Visible = false;
            pictureBox2.Image = back;
            //获得返回的数组知道 展示牌的号码
            List<int> a = game.NewHandhandler();
            //导入对应图片

            Image img_banker_1 = Image.FromFile(a[2].ToString() + ".gif");
            Image img_banker_2 = Image.FromFile(a[3].ToString() + ".gif");
            Image img_player_1 = Image.FromFile(a[4].ToString() + ".gif");
            Image img_player_2 = Image.FromFile(a[5].ToString() + ".gif");

            pictureBox11.Image = img_player_1;
            pictureBox12.Image = img_player_2;

            if (a[0] == 1)
            {
                button3.Enabled = false;
                button4.Enabled = false;

                if (a[1] == 0)
                {
                    pictureBox1.Image = img_banker_1;
                    pictureBox2.Image = img_banker_2;
                    label2.Text = "Result:\nPush!";
                }
                if (a[1] == 1)
                {
                    pictureBox1.Image = img_banker_1;
                    pictureBox2.Image = img_banker_2;
                    label2.Text = "Result:\nLose!";
                }
                if (a[1] == 2)
                {
                    pictureBox1.Image = img_banker_1;
                    pictureBox2.Image = img_banker_2;
                    label2.Text = "Result:\nWin!";
                }
                label1.Text = "Score: " + game.getPlayerScore().ToString();
            }
            else
            {
                pictureBox1.Image = img_banker_1;
                button3.Enabled = true;
                button4.Enabled = true;
            }


            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> tmp = game.Controller(3, 0);
            if (tmp[0] == 1)
            {
                int cardPosition = tmp[1];
                int playerLastCard = tmp[2];

                tmp.RemoveAt(0);
                tmp.RemoveAt(1);
                tmp.RemoveAt(2);

                string imgname = playerLastCard + ".gif";
                Image img = Image.FromFile(imgname);
                switch (cardPosition)
                {
                    case 3:
                        pictureBox13.Image = img;
                        pictureBox13.Visible = true;
                        break;
                    case 4:
                        pictureBox14.Image = img;
                        pictureBox14.Visible = true;
                        break;
                    case 5:
                        pictureBox15.Image = img;
                        pictureBox15.Visible = true;
                        break;
                    case 6:
                        pictureBox16.Image = img;
                        pictureBox16.Visible = true;
                        break;
                    case 7:
                        pictureBox17.Image = img;
                        pictureBox17.Visible = true;
                        break;
                    case 8:
                        pictureBox18.Image = img;
                        pictureBox18.Visible = true;
                        break;
                    case 9:
                        pictureBox19.Image = img;
                        pictureBox19.Visible = true;
                        break;
                    case 10:
                        pictureBox20.Image = img;
                        pictureBox20.Visible = true;
                        break;
                }
                img = Image.FromFile(tmp[1] + ".gif");
                pictureBox2.Image = img;
                pictureBox2.Visible = true;
                button3.Enabled = false;
                button4.Enabled = false;
                label2.Text = "Result:\nBusted!";
                BustOrNot.Visible = true;
                label1.Text = "Score: " + game.getPlayerScore().ToString();

            }
            else if (tmp[0] == 0)
            {
                int cardPosition = tmp[1];
                int playerLastCard = tmp[2];

                string imgname = playerLastCard + ".gif";
                Image img = Image.FromFile(imgname);
                switch (cardPosition)
                {
                    case 3:
                        pictureBox13.Image = img;
                        pictureBox13.Visible = true;
                        break;
                    case 4:
                        pictureBox14.Image = img;
                        pictureBox14.Visible = true;
                        break;
                    case 5:
                        pictureBox15.Image = img;
                        pictureBox15.Visible = true;
                        break;
                    case 6:
                        pictureBox16.Image = img;
                        pictureBox16.Visible = true;
                        break;
                    case 7:
                        pictureBox17.Image = img;
                        pictureBox17.Visible = true;
                        break;
                    case 8:
                        pictureBox18.Image = img;
                        pictureBox18.Visible = true;
                        break;
                    case 9:
                        pictureBox19.Image = img;
                        pictureBox19.Visible = true;
                        break;
                    case 10:
                        pictureBox20.Image = img;
                        pictureBox20.Visible = true;
                        break;
                }
            }
            button5.Enabled = false;
            textBox1.Enabled = false;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            List<int> bankerCard = game.Controller(4, 0);
            string file;
            int whoWin;
            int cardCount;
            int[] flag = new int[8];
            for (int y = 0; y < 8; y++)
                flag[y] = 0; whoWin = bankerCard[0];
            cardCount = bankerCard[1];
            bankerCard.RemoveAt(0);
            bankerCard.RemoveAt(0);
            bankerCard.RemoveAt(0);

            file = bankerCard[0].ToString() + ".gif";
            Image img = Image.FromFile(file);
            pictureBox2.Image = img;
            this.pictureBox2.Visible = true;
            bankerCard.RemoveAt(0);

            while (bankerCard.Count() > 0)
            {
                file = bankerCard[0].ToString() + ".gif";
                img = Image.FromFile(file);
                bankerCard.RemoveAt(0);
                if (flag[0] == 0)
                { this.pictureBox3.Image = img; flag[0] = 1; this.pictureBox3.Visible = true; continue; }
                if (flag[1] == 0)
                { this.pictureBox4.Image = img; flag[1] = 1; this.pictureBox4.Visible = true; continue; }
                if (flag[2] == 0)
                { this.pictureBox5.Image = img; flag[2] = 1; this.pictureBox5.Visible = true; continue; }
                if (flag[3] == 0)
                { this.pictureBox6.Image = img; flag[3] = 1; this.pictureBox6.Visible = true; continue; }
                if (flag[4] == 0)
                { this.pictureBox7.Image = img; flag[4] = 1; this.pictureBox7.Visible = true; continue; }
                if (flag[5] == 0)
                { this.pictureBox8.Image = img; flag[5] = 1; this.pictureBox8.Visible = true; continue; }
                if (flag[6] == 0)
                { this.pictureBox9.Image = img; flag[6] = 1; this.pictureBox9.Visible = true; continue; }
                if (flag[7] == 0)
                { this.pictureBox10.Image = img; flag[7] = 1; this.pictureBox10.Visible = true; continue; }
            }
            if (whoWin == 0)
                label2.Text = "Result:\nPush!";
            if (whoWin == 1)
            { 
                label2.Text = "Result:\nWin!";
                WinGame.Visible = true;
            }
            if (whoWin == 2)
            {
                label2.Text = "Result:\nLose!";
            }


            label1.Text = "Score: " + game.getPlayerScore().ToString();
            button3.Enabled = false;
            button4.Enabled = false;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            game.Controller(5, Int32.Parse(textBox1.Text.Trim()));
            textBox1.Enabled = false;
            button5.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox1.Text[0] == '-' )
            {
                button5.Enabled = false;
                textBox1.Text = "0";
            }
            else if (textBox1.Text.Length >= 10)
            {
                textBox1.Text = "9999999999";
            }
            else
            {
                int a = int.Parse(textBox1.Text);
                if (a > 1000 || a < 0)
                {
                    button5.Enabled = false;
                }
                else
                {
                    button5.Enabled = true;
                }
            }
        }





    }
}
