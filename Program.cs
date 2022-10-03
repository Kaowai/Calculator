using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static Button[] buttonList = new Button[10];
        static Label label1 = new Label();
        static Label label2 = new Label();
        static Button button_divide = new Button();
        static Button button_substract = new Button();
        static Button button_multiplex = new Button();
        static Button button_plus = new Button();
        static Button button_point = new Button();
        static Button button_equal = new Button();
        static Panel panel = new Panel();
        static double x = 0f;
        static string stringNotice = "";
        public static void Main(string[] args)
        {
            //create form and set backcolor for form
            Form form = new Form();
            form.BackColor = Color.Ivory;
            form.Size = new Size(435, 600);
            form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.None;


            // create text box to display result
            label1.BorderStyle = BorderStyle.None;
            label1.BackColor = Color.Tan;
            label1.Top = 25;
            label1.Left = 15;
            label1.Width = form.Width - 30;
            label1.Height = 75;
            label1.TextAlign = ContentAlignment.TopLeft;
            label1.Font = new Font("Time New Roman", 25);
            label1.ForeColor = Color.Black;
            form.Controls.Add(label1);
            label1.Text = "";

            label2.BorderStyle = BorderStyle.None;
            label2.BackColor = Color.Tan;
            label2.Top = 100;
            label2.Left = 15;
            label2.Width = form.Width - 30;
            label2.Height = 75;
            label2.TextAlign = ContentAlignment.BottomRight;
            label2.Font = new Font("Time New Roman", 25);
            label2.ForeColor = Color.Black;
            form.Controls.Add(label2);
            label2.Text = "0";


            // create position
            var y = 600;
            var x = 0;

            // create button
            for (int i = 0; i < 10; i++)
            {
                buttonList[i] = new Button();
                buttonList[i].Text = $"{i}";
                panel.Controls.Add(buttonList[i]);
                buttonList[i].Font = new Font("Microsoft YaHei", 15);
                buttonList[i].ForeColor = Color.Black;
                buttonList[i].Size = new Size(90, 50);
                buttonList[i].BackColor = Color.White;
            }
            buttonList[0].Click += Program_Click0;
            buttonList[1].Click += Program_Click1;
            buttonList[2].Click += Program_Click2;
            buttonList[3].Click += Program_Click3;
            buttonList[4].Click += Program_Click4;
            buttonList[5].Click += Program_Click5;
            buttonList[6].Click += Program_Click6;
            buttonList[7].Click += Program_Click7;
            buttonList[8].Click += Program_Click8;
            buttonList[9].Click += Program_Click9;


            buttonList[0].Location = new Point(x += 15, y -= (15 + buttonList[0].Size.Height));
            form.Controls.Add(buttonList[0]);
            x = 0; 
            for (int i = 1; i <= 7; i = i +3)
            {
                if (i == 1)
                {
                    buttonList[i].Location = new Point(15, y -= (15 + buttonList[0].Size.Height));
                }
                else 
                {
                    buttonList[i].Location = new Point(15, y -= (15 + buttonList[i - 3].Size.Height));
                }
                form.Controls.Add(buttonList[i]);
            }
            for (int i = 2; i <= 8; i = i +3)
            {
                buttonList[i].Location = new Point(buttonList[i - 1].Size.Width + 30, buttonList[i - 1].Location.Y);
                form.Controls.Add(buttonList[i]);
            }
            for (int i = 3; i <= 9; i = i+3)
            {
                buttonList[i].Location = new Point(buttonList[i - 1].Size.Width * 2 + 45, buttonList[i - 1].Location.Y);
                form.Controls.Add(buttonList[i]);
            }


            // calculator
            // button point
            button_point.Text = ".";
            button_point.Font = new Font("Microsoft YaHei", 15);
            button_point.ForeColor = Color.Black;
            button_point.Size = new Size(90, 50);
            button_point.BackColor = Color.White;
            button_point.Location = new Point(buttonList[0].Size.Width + 30, buttonList[0].Location.Y);
            form.Controls.Add(button_point);
            button_point.Click += Button_point_Click;

            // button equal
            button_equal.Text = "=";
            button_equal.Font = new Font("Microsoft YaHei", 15);
            button_equal.ForeColor = Color.Black;
            button_equal.Size = new Size(90, 50);
            button_equal.BackColor = Color.White;
            button_equal.Location = new Point(button_point.Size.Width * 2 + 45, buttonList[0].Location.Y);
            form.Controls.Add(button_equal);
            button_equal.Click += Button_equal_Click;

            // button divide
            button_divide.Text = "/";
            button_divide.Font = new Font("Microsoft YaHei", 15);
            button_divide.ForeColor = Color.Black;
            button_divide.Size = new Size(90, 50);
            button_divide.BackColor = Color.White;
            button_divide.Location = new Point(button_equal.Size.Width * 3 + 60, button_equal.Location.Y);
            form.Controls.Add(button_divide);
            button_divide.Click += Button_divide_Click;

            // button multiplex
            button_multiplex.Text = "x";
            button_multiplex.Font = new Font("Microsoft YaHei", 15);
            button_multiplex.ForeColor = Color.Black;
            button_multiplex.Size = new Size(90, 50);
            button_multiplex.BackColor = Color.White;
            button_multiplex.Location = new Point(button_equal.Size.Width * 3 + 60, buttonList[1].Location.Y);
            form.Controls.Add(button_multiplex);
            form.Show();
            button_multiplex.Click += Button_multiplex_Click; 

            // button substract
            button_substract.Text = "-";
            button_substract.Font = new Font("Microsoft YaHei", 15);
            button_substract.ForeColor = Color.Black;
            button_substract.Size = new Size(90, 50);
            button_substract.BackColor = Color.White;
            button_substract.Location = new Point(button_equal.Size.Width * 3 + 60, buttonList[4].Location.Y);
            form.Controls.Add(button_substract);
            button_substract.Click += Button_substract_Click;

            // button plus
            button_plus.Text = "+";
            button_plus.Font = new Font("Microsoft YaHei", 15);
            button_plus.ForeColor = Color.Black;
            button_plus.Size = new Size(90, 50);
            button_plus.BackColor = Color.White;
            button_plus.Location = new Point(button_equal.Size.Width * 3 + 60, buttonList[7].Location.Y);
            form.Controls.Add(button_plus);
            button_plus.Click += Button_plus_Click;
            form.Show();
            Application.Run(form);
        }

        private static void Button_point_Click(object sender, EventArgs e)
        {
            label1.Text += ".";
        }

        private static void Button_plus_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToDouble(label1.Text);
                stringNotice = "+";
            }
            catch { stringNotice = "+"; }; 
            label1.Text = "";
        }
        private static void Button_substract_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToDouble(label1.Text);
                stringNotice = "-";
            }
            catch
            {
                stringNotice = "-";
            };
            label1.Text = ""; 
        }
        private static void Button_multiplex_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToDouble(label1.Text);
                stringNotice = "x";
            }
            catch
            {
                stringNotice = "x";
            };
            label1.Text = "";
        }

        private static void Button_divide_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToDouble(label1.Text);
                stringNotice = "/";
            }
            catch
            {
                stringNotice = "/";
            };
            label1.Text = "";
        }

        private static void Button_equal_Click(object sender, EventArgs e)
        {
            try
            {
                switch (stringNotice)
                {
                    case "+":
                        x += Convert.ToDouble(label1.Text);
                        break;
                    case "-":
                        x -= Convert.ToDouble(label1.Text);
                        break;
                    case "x":
                        x *= Convert.ToDouble(label1.Text);
                        break;
                    case "/":
                        x /= Convert.ToDouble(label1.Text);
                        break;
                }
            }
            catch
            { }
            label2.Text = x.ToString();
            label1.Text = "";
        }

        private static void Program_Click0(object sender, EventArgs e)
        {
            label1.Text += buttonList[0].Text;
        }

        private static void Program_Click1(object sender, EventArgs e)
        {
            label1.Text += buttonList[1].Text;
        }

        private static void Program_Click2(object sender, EventArgs e)
        {
            label1.Text += buttonList[2].Text;
        }

        private static void Program_Click3(object sender, EventArgs e)
        {
            label1.Text += buttonList[3].Text;
        }
        private static void Program_Click4(object sender, EventArgs e)
        {
            label1.Text += buttonList[4].Text;
        }
        private static void Program_Click5(object sender, EventArgs e)
        {
            label1.Text += buttonList[5].Text;
        }
        private static void Program_Click6(object sender, EventArgs e)
        {
            label1.Text += buttonList[6].Text;
        }
        private static void Program_Click7(object sender, EventArgs e)
        {
            label1.Text += buttonList[7].Text;
        }
        private static void Program_Click8(object sender, EventArgs e)
        {
            label1.Text += buttonList[8].Text;
        }
        private static void Program_Click9(object sender, EventArgs e)
        {
            label1.Text += buttonList[9].Text;
        }

    }
}
