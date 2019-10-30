using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }


        /// <summary>
        /// locked level
        /// can't go up if platform
        /// level 7 breaks 6?
        /// </summary>
       
        int up = 0;
        int linear = 0;
        Boolean grounded = true;
        int level = 0;
        int x = 0;
        Boolean jumping = false;
        Boolean walledLeft = false;
        Boolean walledRight = false;
        Boolean touchingPlatform = false;


        PictureBox[] walls;




        private void Form1_Load(object sender, EventArgs e)
        {
            //floor
            checkLevel();
            walls = new PictureBox[7] {pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8};
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
     
            

            if (e.KeyCode == Keys.D)
            {

                int wallcount =0;
                int xy;
                int yx;
                foreach (PictureBox wall in walls)
                {
                    if (wall.Bounds.IntersectsWith(label1.Bounds))
                    {
                        xy = wall.Top - 61;
                        if (label1.Top > xy)
                        {
                            yx = wall.Left - 23;
                            if (label1.Left < yx)
                            {
                                wallcount++;
                            }
                        }
                    }
                }


                if (wallcount == 0)
                {
                    walledRight = false;
                   
                }
                else
                {
                    walledRight = true;
                    walledLeft = false;
                }

                if (walledRight == false)
                {
                    label1.Left = label1.Left + 10;
                    linear++;
                    label2.Text = linear.ToString();
                    checkIfGrounded();
                }
            }

            if (e.KeyCode == Keys.A)
            {
              
                int wallcount = 0;
                int xy;
                int yx;
                foreach (PictureBox wall in walls)
                {
                    if (wall.Bounds.IntersectsWith(label1.Bounds))
                    {
                        xy = wall.Top - 61;
                        if (label1.Top > xy)
                        {
                            yx = wall.Left - 23;
                            if (label1.Left > yx)
                            {
                                wallcount++;
                            }

                        }
                    }
                }

                if (wallcount == 0)
                {
                    walledLeft = false;
                }
                else
                {
                    walledLeft = true;
                    walledRight = false;
                }


                //moves him
                if (walledLeft == false)
                {

                        label1.Left = label1.Left - 10;
                        linear--;
                        checkIfGrounded();
                        label2.Text = linear.ToString();
                }
            }

            if (grounded == true)
            {
                if (e.KeyCode == Keys.W)
                {
                    if (level != 5)
                    {
                        grounded = false;
                        timer1.Enabled = true;
                    }
                    if(level ==5)
                    {
                        label1.Top = label1.Top - 10;
                        grounded = true;
                    }

                }
            }
           



            if (e.KeyCode == Keys.S)
            {
                if (level == 5)
                {
                    if (touchingPlatform == false)
                    {
                        label1.Top = label1.Top + 10;
                        up--;
                    }
                }
            }

            if (e.KeyCode == Keys.N)
            {
                level++;
                checkLevel();
            }

        }

        private void label1_LocationChanged(object sender, EventArgs e)
        {


        }
         int jumpdistance=12; 
        private void timer1_Tick(object sender, EventArgs e)
        {
            jumping = true;

            label3.Text = label1.Top.ToString();
            label1.Top = label1.Top - jumpdistance;
            jumpdistance -= 1;


            checkIfGrounded();
            if (grounded == true)
            {
                timer1.Stop();
                jumpdistance = 12;
                jumping = false;

            }

            }

            int xy = 0;
        private void checkIfGrounded()
        {
           
            int touchingwallcount = 0; 

            foreach (PictureBox wall in walls) {
                if (wall.Bounds.IntersectsWith(label1.Bounds))
                {
                    xy = wall.Top - 61;
                    if (label1.Top < xy)
                    {
                        touchingwallcount++;
                    }
                }
            }

            if (touchingwallcount == 0)
            {
                if (level != 5)
                {
                    grounded = false;
                }
                touchingPlatform = false;
            }
            else
            {
                grounded = true;
                touchingPlatform = true;
            }



            if (label1.Bounds.IntersectsWith(pictureBox1.Bounds))
            {

                    grounded = true;
                touchingPlatform = true;
                if(level == 7)
                {
                    checkLevel();
                }
            }
            else
            {
                touchingPlatform = false;
            }

            if (label1.Bounds.IntersectsWith(button1.Bounds))
            {
                    level++;
                    checkLevel();
               
            }

            if (level == 2)
            {
                if (label1.Bounds.IntersectsWith(button3.Bounds))
                {
                    pictureBox7.Visible = false;
                pictureBox7.Location = new Point(0, 0);
                }

            }

            if (level != 5)
            {
                if (grounded == false)
                {
                    if (jumping == false)
                    {
                        timer2.Enabled = true;
                    }
                }
                label5.Text = grounded.ToString();
            }

            if (level == 4)
            {

                if (label1.Bounds.IntersectsWith(label6.Bounds) || label1.Bounds.IntersectsWith(label7.Bounds))
                {
                    level = 4;
                    checkLevel();
                }
            }
                

             
        }







        private void checkLevel()
        {
            pictureBox9.Size = new Size(1, 5);
            if (level == 0)
            {
                pictureBox1.Visible = false;
                //levels
                button2.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button8.Visible = true;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox2.Location = new Point(0, 0);
                pictureBox3.Visible = false;
                pictureBox3.Location = new Point(0, 0);
                pictureBox4.Visible = false;
                pictureBox4.Location = new Point(0, 0);
                pictureBox5.Visible = false;
                pictureBox5.Location = new Point(0, 0);
                pictureBox6.Visible = false;
                pictureBox6.Location = new Point(0, 0);
                pictureBox7.Visible = false;
                pictureBox7.Location = new Point(0, 0);
                pictureBox8.Visible = false;
                pictureBox8.Location = new Point(0, 0);
                button1.Visible = false;
                button3.Visible = false;
                label1.Visible = false;
                button9.Visible = true;
                button10.Visible = true;


            }
            else
            {
                button1.Visible = true;
                pictureBox1.Visible = true;
                button2.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                label1.Visible = true;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;

            }

            if (level == 1)
            {
                linear = 0;


                //platforms
                pictureBox2.Visible = true;
                pictureBox2.Location = new Point(224, 255);
                pictureBox2.Size = new Size(103, 30);
                pictureBox3.Visible = true;
                pictureBox3.Location = new Point(325, 213);
                pictureBox3.Size = new Size(203, 23);
                pictureBox4.Visible = true;
                pictureBox4.Location = new Point(523, 177);
                pictureBox4.Size = new Size(103, 23);

                //starting location for anything else
                button1.Location = new Point(557, 119);
                label1.Location = new Point(11, 240);



                //needs to hide and be put off onto side
                pictureBox6.Visible = false;
                pictureBox6.Location = new Point(0, 0);
                pictureBox6.Size = new Size(1, 1);
                pictureBox5.Visible = false;
                pictureBox5.Location = new Point(0, 0);
                pictureBox5.Size = new Size(0, 0);
                pictureBox7.Visible = false;
                pictureBox7.Location = new Point(0, 0);
                pictureBox7.Size = new Size(1, 1);
                pictureBox8.Visible = false;
                pictureBox8.Location = new Point(0, 0);
                pictureBox8.Size = new Size(1, 1);
                pictureBox9.Visible = false;
                pictureBox9.Location = new Point(0, 0);

                //timer (no moving objects in this level
                timer3.Enabled = false;
            }

            if (level == 2)
            {
                //platforms
                pictureBox6.Visible = true;
                pictureBox6.Location = new Point(193, 229);
                pictureBox6.Size = new Size(197, 100);
                pictureBox7.Visible = true;
                pictureBox7.Location = new Point(3, 229);
                pictureBox7.Size = new Size(215, 23);
                pictureBox5.Visible = true;
                pictureBox5.Location = new Point(425, 264);
                pictureBox5.Size = new Size(103, 65);

                //things that need to be hidden and put off to side
                pictureBox2.Visible = false;
                pictureBox2.Location = new Point(0, 0);
                pictureBox2.Size = new Size(1, 1);
                pictureBox3.Visible = false;
                pictureBox3.Location = new Point(0, 0);
                pictureBox3.Size = new Size(1, 1);
                pictureBox4.Visible = false;
                pictureBox4.Location = new Point(0, 0);
                pictureBox4.Size = new Size(1, 1);
                pictureBox8.Visible = false;
                pictureBox8.Location = new Point(0, 0);
                pictureBox8.Size = new Size(1, 1);
                pictureBox9.Visible = false;
                pictureBox9.Location = new Point(0, 0);



                //starting location for anything else
                button3.Visible = true;
                button3.Location = new Point(12, 155);
                button1.Location = new Point(123, 267);
                label1.Location = new Point(566, 240);

                linear = 55;
                timer3.Enabled = false;
            }

            if (level == 3)
            {
                //platforms
                linear = 0;
                pictureBox2.Visible = true;
                pictureBox2.Location = new Point(190, 255);
                pictureBox2.Size = new Size(103, 30);
                pictureBox5.Location = new Point(97, 264);
                pictureBox5.Visible = true;
                pictureBox5.Size = new Size(103, 65);
                pictureBox4.Visible = true;
                pictureBox4.Location = new Point(523, 177);
                pictureBox4.Size = new Size(103, 23);



                //things that need to be hidden
                pictureBox6.Visible = false;
                pictureBox6.Location = new Point(0, 0);
                pictureBox6.Size = new Size(1, 1);
                pictureBox3.Visible = false;
                pictureBox3.Location = new Point(0, 0);
                pictureBox3.Size = new Size(1, 1);
                pictureBox7.Visible = false;
                pictureBox7.Location = new Point(0, 0);
                pictureBox7.Size = new Size(1, 1);
                pictureBox8.Visible = false;
                pictureBox8.Size = new Size(1, 1);
                pictureBox8.Location = new Point(0, 0);
                button3.Visible = false;
                button3.Location = new Point(0, 0);
                pictureBox9.Visible = false;
                pictureBox9.Location = new Point(0, 0);

                //starting location for anything else
                label1.Location = new Point(11, 240);
                button1.Location = new Point(557, 119);

                timer3.Enabled = true;
            }

            if (level == 4)
            {
                linear = 0;

                //platforms
                pictureBox5.Visible = true;
                pictureBox5.Location = new Point(97, 264);
                pictureBox5.Size = new Size(103, 65);
                pictureBox8.Location = new Point(523, 198);
                pictureBox8.Visible = true;
                pictureBox8.Size = new Size(103, 129);
                pictureBox6.Location = new Point(425, 264);
                pictureBox6.Size = new Size(195, 76);
                pictureBox6.Visible = true;
                pictureBox3.Visible = true;
                pictureBox3.Size = new Size(5, 200);
                pictureBox3.Location = new Point(334, 0);

                //things that need to be hidden
                pictureBox4.Visible = false;
                pictureBox4.Location = new Point(0, 0);
                pictureBox4.Size = new Size(1, 1);
                pictureBox2.Visible = false;
                pictureBox2.Location = new Point(0, 0);
                pictureBox2.Size = new Size(1, 1);
                pictureBox7.Visible = false;
                pictureBox7.Location = new Point(0, 0);
                pictureBox7.Size = new Size(1, 1);
                button3.Location = new Point(0, 0);
                pictureBox9.Visible = false;
                pictureBox9.Location = new Point(0, 0);
                button3.Visible = false;


                //location of anything else
                label1.Location = new Point(11, 240);
                button1.Location = new Point(553, 142);

                //enemies
                label6.Visible = true;
                label6.Location = new Point(204, 282);
                label7.Visible = true;
                label7.Location = new Point(414, 282);
                timer3.Enabled = true;

            }
            else
            {

                label6.Visible = false;
                label7.Visible = false;
            }

            if (level == 5)
            {
                //platforms
                pictureBox6.Visible = true;
                pictureBox6.Size = new Size(197, 236);
                pictureBox6.Location = new Point(159, 0);
                pictureBox3.Visible = true;
                pictureBox3.Size = new Size(197, 236);
                pictureBox3.Location = new Point(523, 130);

                //things that need to be hidden
                pictureBox2.Visible = false;
                pictureBox2.Location = new Point(0, 0);
                pictureBox2.Size = new Size(1, 1);
                pictureBox4.Visible = false;
                pictureBox4.Location = new Point(0, 0);
                pictureBox4.Size = new Size(1, 1);
                pictureBox5.Visible = false;
                pictureBox5.Location = new Point(0, 0);
                pictureBox5.Size = new Size(0, 0);
                pictureBox7.Visible = false;
                pictureBox7.Location = new Point(0, 0);
                pictureBox7.Size = new Size(1, 1);
                pictureBox8.Visible = false;
                pictureBox8.Location = new Point(0, 0);
                pictureBox8.Size = new Size(1, 1);
                pictureBox9.Visible = false;
                pictureBox9.Location = new Point(0, 0);
                button3.Visible = false;
                button3.Location = new Point(0, 0);


                //location of anything else
                button1.Location = new Point(621, 0);
                label1.Location = new Point(65, 130);


                //enemies
                label8.Location = new Point(437, 73);
                label8.Visible = true;
                label9.Location = new Point(339, 260);
                label9.Visible = true;
                label10.Location = new Point(364, 198);
                label10.Visible = true;

                //other
                this.BackColor = Color.DeepSkyBlue;
                pictureBox1.BackColor = Color.SandyBrown;
                timer3.Enabled = true;
                pictureBox6.BackColor = Color.SandyBrown;
                pictureBox3.BackColor = Color.SandyBrown;
            }
            else
            {
                this.BackColor = DefaultBackColor;
                if (level != 7)
                {
                    pictureBox1.BackColor = Color.FromArgb(0, 192, 0);
                }
                label8.Location = new Point(0, 0);
                label8.Visible = false;
                label9.Location = new Point(0, 0);
                label9.Visible = false;
                label10.Location = new Point(0, 0);
                label10.Visible = false;
                pictureBox6.BackColor = Color.FromArgb(0, 192, 0);
                pictureBox3.BackColor = Color.FromArgb(0, 192, 0);
            }

            if (level == 6)
            {
                //platforms
                pictureBox5.Visible = true;
                pictureBox5.Location = new Point(88, 262);
                pictureBox5.Size = new Size(103, 65);
                pictureBox6.Location = new Point(147, 213);
                pictureBox6.Visible = true;
                pictureBox6.Size = new Size(72, 10);
                pictureBox7.Visible = true;
                pictureBox7.Location = new Point(245, 144);
                pictureBox7.Size = new Size(215, 23);
                pictureBox3.Location = new Point(447, 101);
                pictureBox3.Visible = true;
                pictureBox3.Size = new Size(149, 236);

                //lasers
                pictureBox2.Visible = true;
                pictureBox4.Visible = true;
                pictureBox8.Visible = true;
                pictureBox2.BackColor = Color.Red;
                pictureBox8.BackColor = Color.Red;
                pictureBox4.BackColor = Color.Red;
                pictureBox2.Size = new Size(95, 5);
                pictureBox2.Location = new Point(346, 60);
                pictureBox4.Size = new Size(281, 5);
                pictureBox4.Location = new Point(201, 21);
                pictureBox8.Size = new Size(5, 96);
                pictureBox8.Location = new Point(599, 0);

                //other things
                button1.Location = new Point(621, 262);
                label1.Location = new Point(11, 240);
                timer3.Enabled = true;

            }
            else
            {
                pictureBox2.BackColor = Color.FromArgb(0, 192, 0);
                pictureBox8.BackColor = Color.FromArgb(0, 192, 0);
                pictureBox4.BackColor = Color.FromArgb(0, 192, 0);
            }

            if (level == 7)
            {
                //platforms
                pictureBox5.Location = new Point(26, 281);
                pictureBox5.Visible = true;
                pictureBox5.Size = new Size(74, 10);
                pictureBox6.Location = new Point(235, 260);
                pictureBox6.Visible = true;
                pictureBox6.Size = new Size(43, 10);
                pictureBox7.Location = new Point(344, 228);
                pictureBox7.Visible = true;
                pictureBox7.Size = new Size(56, 15);
                pictureBox3.Location = new Point(430, 198);
                pictureBox3.Visible = true;
                pictureBox3.Size = new Size(238, 141);
                pictureBox2.Location = new Point(498, 143);
                pictureBox2.Visible = true;
                pictureBox2.Size = new Size(95, 28);
                pictureBox4.Location = new Point(217, 89);
                pictureBox4.Visible = true;
                pictureBox4.Size = new Size(257, 10);
                pictureBox8.Location = new Point(217, 3);
                pictureBox8.Visible = true;
                pictureBox8.Size = new Size(51, 96);

                //location of other
                button1.Location = new Point(274, 29);
                label1.Location = new Point(37, 166);

                //hidden
                button3.Visible = false;
                button3.Location = new Point(0, 0);


                //else
                pictureBox1.BackColor = Color.Red;
                timer3.Enabled = true;
                counter = 0;

            }
            else
            {
                if (level != 5)
                {
                    pictureBox1.BackColor = Color.FromArgb(0, 192, 0);
                }
            }

            if(level == 8)
            {
                MessageBox.Show("Congrats! You've completed every level!");
                level = 0;
                checkLevel();
                  
            }



        }

        








        
        
        private void timer2_Tick(object sender, EventArgs e)
        {

            label1.Top = label1.Top + 10;
            checkIfGrounded();
            if(grounded == true)
            {
                timer2.Stop();
            }

           
        }

        int counter = 0;
        Boolean left = true;
        Boolean lefttwo = false;
        Boolean leftthree = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            label5.Text = x.ToString();
            checkIfGrounded();
            

            if (level == 3)
            {
                if (pictureBox2.Left < 190)
                {
                    left = true;
                }
                if (left == true)
                {
                    pictureBox2.Left = pictureBox2.Left + 10;
                }
                if (pictureBox2.Left > 490)
                {
                    left = false;
                }
                if (left == false)
                {
                    pictureBox2.Left = pictureBox2.Left - 10;
                }

            }

            if (level == 4)
            {
                if (label6.Left <= 204)
                {
                    left = true;
                }

                if (label6.Left >= 414)
                {
                    left = false;
                }
                if (left == true)
                {
                    label6.Left = label6.Left + 10;
                }
                if (left == false)
                {
                    label6.Left = label6.Left - 10;
                }


                if (label7.Left <= 204)
                {
                    lefttwo = true;
                }

                if (label7.Left >= 414)
                {
                    lefttwo = false;
                }
                if (lefttwo == true)
                {
                    label7.Left = label7.Left + 10;
                }
                if (lefttwo == false)
                {
                    label7.Left = label7.Left - 10;
                }

            }

            if(level == 5)
            {
                // left = red fish (label 8)
                //lefttwo = green fish (label10)
                //leftthree = blue fish(label9)

                if (label1.Bounds.IntersectsWith(label8.Bounds) || label1.Bounds.IntersectsWith(label9.Bounds) || label1.Bounds.IntersectsWith(label10.Bounds))
                {
                    checkLevel();
                }

                //red fish
                if (label8.Left < 360)
                {
                    left = true;
                    label8.Text = "><[[[*>";
                }
                if (label8.Left > 594)
                {
                    left = false;
                    label8.Text = "<*]]]><";
                }
                if(left == true)
                {
                    label8.Left = label8.Left + 10;
                }
                else
                {
                    label8.Left = label8.Left - 10;
                }

                //green fish
                if (label10.Left < 360)
                {
                    lefttwo = true;
                    label10.Text = "><(((*>";
                }
                if (label10.Left > 440)
                {
                    lefttwo = false;
                    label10.Text = "<*)))><";
                }
                if (lefttwo == true)
                {
                    label10.Left = label10.Left + 10;
                }
                else
                {
                    label10.Left = label10.Left - 10;
                }

                //purple fish
                if (label9.Left < -2)
                {
                    leftthree = true;
                    label9.Text = "><{{{*>";
                }
                if (label9.Left > 445)
                {
                    leftthree = false;
                    label9.Text = "<*}}}><";
                }
                if (leftthree == true)
                {
                    label9.Left = label9.Left + 10;
                }
                else
                {
                    label9.Left = label9.Left - 10;
                }

                //label going down?
                if (touchingPlatform == false)
                {
                    label1.Top = label1.Top + 5;
                }

            }


            if(level == 6)
            {
                counter++;

                if (counter > 3)
                {
                    pictureBox5.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox7.Location = new Point(0, 0);
                    pictureBox5.Location = new Point(0, 0);
                } else if(counter < 3)
                {
                    pictureBox5.Visible = true;
                    pictureBox7.Visible = true;
                    pictureBox7.Location = new Point(245, 144);
                    pictureBox5.Location = new Point(88, 262);
                }

                if(counter == 7)
                {
                    counter = 0;
                }

                //left = pictureBox2
                //lefttwo == pictureBox4
                //leftthree == pictureBox
                if(label1.Bounds.IntersectsWith(pictureBox2.Bounds) || label1.Bounds.IntersectsWith(pictureBox4.Bounds)|| label1.Bounds.IntersectsWith(pictureBox8.Bounds))
                {
                    checkLevel();
                }

                if (pictureBox2.Top >= 157)
                {
                    left = true;
                }
                if (left == true)
                {
                    pictureBox2.Top = pictureBox2.Top - 7;
                }
                if (pictureBox2.Top <= 0)
                {
                    left = false;
                }
                if (left == false)
                {
                    pictureBox2.Top = pictureBox2.Top + 7;
                }


                if (pictureBox4.Top >= 288)
                {
                    lefttwo = true;
                }
                if(lefttwo == true)
                {
                    pictureBox4.Top = pictureBox4.Top - 7;
                }
                if (pictureBox4.Top <= 0)
                {
                    lefttwo = false;
                }
                if (lefttwo == false)
                {
                    pictureBox4.Top = pictureBox4.Top + 7;
                }

                if (pictureBox8.Left >= 599)
                {
                    leftthree = true;
                }
                if (leftthree == true)
                {
                    pictureBox8.Left = pictureBox8.Left - 7;
                }
                if (pictureBox8.Left <= 0)
                {
                    leftthree = false;
                }
                if (leftthree == false)
                {
                    pictureBox8.Left = pictureBox8.Left + 7;
                }


            }

            if(level == 7)
            {
                counter++;
                if (counter == 5)
                {
                    foreach (PictureBox wall in walls)
                    {
                        wall.Visible = false;
                    }
                }

                
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            level = 1;
            checkLevel();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            level = 2;
            checkLevel();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            level = 3;
            checkLevel();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            level = 4;
            checkLevel();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            level = 0;
            checkLevel();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            level = 5;
            checkLevel();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            level = 6;
            checkLevel();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            level = 7;
            checkLevel();
        }
    }
}



