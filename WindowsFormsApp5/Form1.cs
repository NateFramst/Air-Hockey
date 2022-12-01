using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        //pens 
        Pen redpen = new Pen(Color.Red, 4);
        Pen bluepen = new Pen(Color.Blue, 4);
        Pen greenpen = new Pen(Color.Green, 4);
        Pen orangepen = new Pen(Color.OrangeRed, 4);
        Pen yellowpen = new Pen(Color.Yellow, 4);
        Pen pinkpen = new Pen(Color.Magenta, 4);
        // brushes
        SolidBrush playerColour = new SolidBrush(Color.Gainsboro);
        SolidBrush puckColour = new SolidBrush(Color.Sienna);
        SolidBrush goal = new SolidBrush(Color.Black);
        // keys

        bool wDown = false;
        bool sDown = false;
        bool dDown = false;
        bool aDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        //player 
        int playerSpeed = 4;
        int puckXSpeed = -6;
        int puckYSpeed = -6;

        //player1 build
        Rectangle player1 = new Rectangle(300, 150, 30, 30);
        Rectangle p1t = new Rectangle(302, 150, 27, 1);
        Rectangle p1l = new Rectangle(300, 152, 1, 27);
        Rectangle p1b = new Rectangle(302, 180, 27, 1);
        Rectangle p1r = new Rectangle(330, 152, 1, 27);
        Rectangle p1c1 = new Rectangle(300, 150, 1, 1);
        Rectangle p1c2 = new Rectangle(330, 150, 1, 1);
        Rectangle p1c3 = new Rectangle(300, 180, 1, 1);
        Rectangle p1c4 = new Rectangle(330, 180, 1, 1);

        //player2 bulid
        Rectangle player2 = new Rectangle(300, 550, 30, 30);
        Rectangle p2t = new Rectangle(302, 550, 27, 1);
        Rectangle p2l = new Rectangle(300, 552, 1, 27);
        Rectangle p2b = new Rectangle(302, 580, 27, 1);
        Rectangle p2r = new Rectangle(330, 552, 1, 27);
        Rectangle p2c1 = new Rectangle(300, 550, 1, 1);
        Rectangle p2c2 = new Rectangle(330, 550, 1, 1);
        Rectangle p2c3 = new Rectangle(300, 580, 1, 1);
        Rectangle p2c4 = new Rectangle(330, 580, 1, 1);

        //puck
        Rectangle puck = new Rectangle(295, 195, 20, 20);


        //goals
        Rectangle goal1 = new Rectangle(210, 0, 210, 47);
        Rectangle goal2 = new Rectangle(210, 653, 210, 47);


        //stopwatch
        Stopwatch Stopwatch = new Stopwatch();

        //Random

        Random Ranspeed = new Random();

        // scoring 
        int p1score, p2score;

        //sounds

        SoundPlayer wallHit = new SoundPlayer(Properties.Resources.wallHit);
        SoundPlayer playerHit = new SoundPlayer(Properties.Resources.playerHit);
        SoundPlayer goalNoise = new SoundPlayer(Properties.Resources.goalNoise);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //players&&puck
            e.Graphics.FillRectangle(playerColour, player1);
            e.Graphics.FillRectangle(playerColour, player2);
            e.Graphics.FillRectangle(puckColour, puck);
            //sides
            e.Graphics.DrawLine(redpen, 70, 45, 70, 225);
            e.Graphics.DrawLine(yellowpen, 70, 225, 70, 475);
            e.Graphics.DrawLine(bluepen, 70, 475, 70, 655);
            e.Graphics.DrawLine(orangepen, 560, 475, 560, 655);
            e.Graphics.DrawLine(pinkpen, 560, 475, 560, 225);
            e.Graphics.DrawLine(greenpen, 560, 225, 560, 45);
            //goal1
            e.Graphics.DrawLine(redpen, 68, 45, 210, 45);
            e.Graphics.DrawLine(greenpen, 562, 45, 420, 45);
            e.Graphics.DrawLine(redpen, 210, 47, 210, 0);
            e.Graphics.DrawLine(greenpen, 420, 47, 420, 0);
            //goal2
            e.Graphics.DrawLine(bluepen, 68, 655, 210, 655);
            e.Graphics.DrawLine(orangepen, 562, 655, 420, 655);
            e.Graphics.DrawLine(bluepen, 210, 653, 210, Bottom);
            e.Graphics.DrawLine(orangepen, 420, 653, 420, Bottom);
            //CenterLine
            e.Graphics.DrawLine(redpen, 72, 350, 558, 350);
            //goals
            e.Graphics.FillRectangle(goal, goal1);
            e.Graphics.FillRectangle(goal, goal2);


            ////testing p1
            //e.Graphics.FillRectangle(puckColour, p1r);
            //e.Graphics.FillRectangle(puckColour, p1t);
            //e.Graphics.FillRectangle(puckColour, p1l);
            //e.Graphics.FillRectangle(puckColour, p1b);
            //e.Graphics.FillRectangle(puckColour, p1c1);
            //e.Graphics.FillRectangle(puckColour, p1c2);
            //e.Graphics.FillRectangle(puckColour, p1c3);
            //e.Graphics.FillRectangle(puckColour, p1c4);

            ////testng p2
            //e.Graphics.FillRectangle(puckColour, p2r);
            //e.Graphics.FillRectangle(puckColour, p2t);
            //e.Graphics.FillRectangle(puckColour, p2l);
            //e.Graphics.FillRectangle(puckColour, p2b);
            //e.Graphics.FillRectangle(puckColour, p2c1);
            //e.Graphics.FillRectangle(puckColour, p2c2);
            //e.Graphics.FillRectangle(puckColour, p2c3);
            //e.Graphics.FillRectangle(puckColour, p2c4);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {


            //Move Puck
            puck.X += puckXSpeed;
            puck.Y += puckYSpeed;

            //Move Player 1

            if (wDown == true && player1.Y > 49)
            {
                player1.Y -= playerSpeed;
                p1l.Y -= playerSpeed;
                p1t.Y -= playerSpeed;
                p1r.Y -= playerSpeed;
                p1b.Y -= playerSpeed;
                p1c1.Y -= playerSpeed;
                p1c2.Y -= playerSpeed;
                p1c3.Y -= playerSpeed;
                p1c4.Y -= playerSpeed;
            }
            if (sDown == true && player1.Y < 316)
            {
                player1.Y += playerSpeed;
                p1l.Y += playerSpeed;
                p1t.Y += playerSpeed;
                p1r.Y += playerSpeed;
                p1b.Y += playerSpeed;
                p1c1.Y += playerSpeed;
                p1c2.Y += playerSpeed;
                p1c3.Y += playerSpeed;
                p1c4.Y += playerSpeed;
            }
            if (dDown == true && player1.X < 526)
            {
                player1.X += playerSpeed;
                p1l.X += playerSpeed;
                p1t.X += playerSpeed;
                p1r.X += playerSpeed;
                p1b.X += playerSpeed;
                p1c1.X += playerSpeed;
                p1c2.X += playerSpeed;
                p1c3.X += playerSpeed;
                p1c4.X += playerSpeed;
            }
            if (aDown == true && player1.X > 74)
            {
                player1.X -= playerSpeed;
                p1l.X -= playerSpeed;
                p1t.X -= playerSpeed;
                p1r.X -= playerSpeed;
                p1b.X -= playerSpeed;
                p1c1.X -= playerSpeed;
                p1c2.X -= playerSpeed;
                p1c3.X -= playerSpeed;
                p1c4.X -= playerSpeed;
            }


            //Move Player 2
            if (upArrowDown == true && player2.Y > 356)
            {
                player2.Y -= playerSpeed;
                p2l.Y -= playerSpeed;
                p2t.Y -= playerSpeed;
                p2r.Y -= playerSpeed;
                p2b.Y -= playerSpeed;
                p2c1.Y -= playerSpeed;
                p2c2.Y -= playerSpeed;
                p2c3.Y -= playerSpeed;
                p2c4.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < 619)
            {
                player2.Y += playerSpeed;
                p2l.Y += playerSpeed;
                p2t.Y += playerSpeed;
                p2r.Y += playerSpeed;
                p2b.Y += playerSpeed;
                p2c1.Y += playerSpeed;
                p2c2.Y += playerSpeed;
                p2c3.Y += playerSpeed;
                p2c4.Y += playerSpeed;
            }

            if (rightArrowDown == true && player2.X < 526)
            {
                player2.X += playerSpeed;
                p2l.X += playerSpeed;
                p2t.X += playerSpeed;
                p2r.X += playerSpeed;
                p2b.X += playerSpeed;
                p2c1.X += playerSpeed;
                p2c2.X += playerSpeed;
                p2c3.X += playerSpeed;
                p2c4.X += playerSpeed;
            }

            if (leftArrowDown == true && player2.X > 74)
            {
                player2.X -= playerSpeed;
                p2l.X -= playerSpeed;
                p2t.X -= playerSpeed;
                p2r.X -= playerSpeed;
                p2b.X -= playerSpeed;
                p2c1.X -= playerSpeed;
                p2c2.X -= playerSpeed;
                p2c3.X -= playerSpeed;
                p2c4.X -= playerSpeed;
            }

            //keep ball in

            if (puck.Y < 45 || puck.Y > 635)
            {
                puckYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed; 
                wallHit.Play();
            }
            if (puck.X < 70 || puck.X > 540)
            {
                puckXSpeed *= -1;
                wallHit.Play();
            }

            //wallsNO

            if (puck.X < 62)
            {
                puck.X = 72;
            }

            if (puck.X > 548)
            {
                puck.X = 528;
            }

            if (puck.Y < 42)
            {
                puck.Y = 52;
            }
            if (puck.Y > 665)
            {
                puck.Y = 645;
            }


            //Paddle interactions p1
            if (p1t.IntersectsWith(puck))
            {
                if (puckYSpeed > 0) //change direction
                {
                    puckYSpeed *= -1;
                    puck.Y = player1.Y - puck.Height;
                }
                else if (puckYSpeed < 0) //push puck
                {
                    puck.Y = player1.Y - puck.Height;

                }
                playerHit.Play();
            }

            if (p1b.IntersectsWith(puck))
            {
                if (puckYSpeed < 0)
                {
                    puckYSpeed *= -1;
                    puck.Y = p1b.Y + puck.Height;
                }
                else if (puckYSpeed > 0)
                {
                    puck.Y = p1b.Y + puck.Height;
                }
                else if (puckYSpeed == 0 && puckXSpeed == 0)
                {
                    puckYSpeed = 5;
                    puckXSpeed = Ranspeed.Next(1, 5);
                }
                playerHit.Play();

            }

            if (p1l.IntersectsWith(puck))
            {
                if (puckXSpeed > 0)
                {
                    puckXSpeed *= -1;
                    puck.X = player1.X - puck.Width;
                }
                else if (puckXSpeed < 0)
                {
                    puck.X = player1.X - puck.Width;
                }
                playerHit.Play();
            }

            if (p1r.IntersectsWith(puck))
            {
                if (puckXSpeed < 0)
                {
                    puckXSpeed *= -1;
                    puck.X = player1.X + puck.Width;
                }
                else if (puckXSpeed > 0)
                {
                    puck.X = player1.X + puck.Width;
                }
                playerHit.Play();
            }

            if (p1c1.IntersectsWith(puck) & !p1t.IntersectsWith(puck) & !p1l.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puckYSpeed *= -1;
                playerHit.Play();
            }

            if (p1c2.IntersectsWith(puck) & !p1t.IntersectsWith(puck) & !p1r.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puckYSpeed *= -1;
                playerHit.Play();
            }

            if (p1c3.IntersectsWith(puck) & !p1b.IntersectsWith(puck) & !p1l.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puckYSpeed *= -1;
                playerHit.Play();
            }

            if (p1c4.IntersectsWith(puck) & !p1b.IntersectsWith(puck) & !p1r.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puckYSpeed *= -1;
                playerHit.Play();
            }

            //paddle interactions p2

            if (p2t.IntersectsWith(puck))
            {
                if (puckYSpeed > 0)
                {
                    puckYSpeed *= -1;
                    puck.Y = player2.Y - puck.Height;
                }
                else if (puckYSpeed < 0)
                {
                    puck.Y = player2.Y - puck.Height;

                }
                else if (puckYSpeed == 0 && puckXSpeed == 0)
                {
                    puckYSpeed = 5;
                    puckXSpeed = Ranspeed.Next(1, 5);
                }
                playerHit.Play();
            }

            if (p2b.IntersectsWith(puck))
            {
                if (puckYSpeed < 0)
                {
                    puckYSpeed *= -1;
                    puck.Y = p2b.Y + 1;
                }
                else if (puckYSpeed > 0)
                {
                    puck.Y = p2b.Y + 1;
                }
                playerHit.Play();
            }

            if (p2l.IntersectsWith(puck))
            {
                if (puckXSpeed > 0)
                {
                    puckXSpeed *= -1;
                    puck.X = player2.X - puck.Width;
                }
                else if (puckXSpeed < 0)
                {
                    puck.X = player2.X - puck.Width;
                }
                playerHit.Play();
            }

            if (p2r.IntersectsWith(puck))
            {
                if (puckXSpeed < 0)
                {
                    puckXSpeed *= -1;
                    puck.X = player2.X + puck.Width;
                }
                else if (puckXSpeed > 0)
                {
                    puck.X = player2.X + puck.Width;
                }
                playerHit.Play();
            }

            if (p2c1.IntersectsWith(puck) & !p2t.IntersectsWith(puck) & !p2l.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puckYSpeed *= -1;
                playerHit.Play();
            }

            if (p2c2.IntersectsWith(puck) & !p2t.IntersectsWith(puck) & !p2r.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puckYSpeed *= -1;
                playerHit.Play();
            }

            if (p2c3.IntersectsWith(puck) & !p2b.IntersectsWith(puck) & !p2l.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puckYSpeed *= -1;
                playerHit.Play();
            }

            if (p2c4.IntersectsWith(puck) & !p2b.IntersectsWith(puck) & !p2r.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puckYSpeed *= -1;
                playerHit.Play();
            }




            //scores
            if (puck.IntersectsWith(goal1) && puck.X > 210 && puck.X < 400)
            {
                p2score++;
                puck.X = 305;
                puck.Y = 195;
                puckXSpeed = 0;
                puckYSpeed = 0;
                goalNoise.Play();
            }

            if (puck.IntersectsWith(goal2) && puck.X > 210 && puck.X < 400)
            {
                p1score++;
                puck.X = 305;
                puck.Y = 495;
                puckXSpeed = 0;
                puckYSpeed = 0;
                goalNoise.Play();
            }

            if (p1score == 3)
            {
                winLabel.Text = "Player 1 wins!";
                gameReset();
            }
            if (p2score == 3)
            {
                winLabel.Text = "Player 2 wins!";
                gameReset();
            }
            //point Reset
            //if (player1.IntersectsWith(puck) && puckYSpeed == 0 && puckXSpeed == 0)
            //{
            //    puck.Y = player1.Y + puck.Height;
            //    puckYSpeed = 4;
            //    puckXSpeed = 4;
            //}
            //else if (player2.IntersectsWith(puck) && puckYSpeed == 0 && puckXSpeed == 0)
            //{
            //    puck.Y = player2.Y - puck.Height;
            //    puckYSpeed -= 4;
            //    puckXSpeed -= 4;
            //}

            scoreLabel1.Text = $"{p1score}";
            scoreLabel2.Text = $"{p2score}";

            Refresh();

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            p1score = 0;
            p2score = 0;
            winLabel.Text = "";
            resetButton.Visible = false;
            resetButton.Enabled = false;
        }

        private void gameReset()
        {
            resetButton.Visible = true;
            resetButton.Enabled = true;
        }

    }
}
