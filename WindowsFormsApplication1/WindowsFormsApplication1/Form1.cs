using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool serialDebug = false;
        private bool keyPressed = false;
        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();
        }
        void getAvailablePorts()
        {
            serialPort1.Close();
            comboBox1.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox4.Enabled = false;
            button1.Text = "Connect";
            textBox4.Text = Convert.ToString(vScrollBar1.Value);
            textBox3.Text = Convert.ToString(vScrollBar2.Value);
            textBox6.Text = Convert.ToString(vScrollBar4.Value);
            textBox5.Text = Convert.ToString(vScrollBar3.Value);
            textBox7.Text = Convert.ToString(vScrollBar5.Value);
            textBox8.Text = Convert.ToString(vScrollBar6.Value);
            textBox9.Text = Convert.ToString(vScrollBar7.Value);
            textBox10.Text = Convert.ToString(vScrollBar8.Value);
            button2.Text = "Connect";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox16_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    textBox13.Text = "Select Com port or Refresh the Control Panel.";

                }
                else if (comboBox2.Text == "")
                {
                    textBox13.Text = "Select Baudrate.";
                }
                else
                {
                    if (button1.Text == "Connect")
                    {
                        serialPort1.PortName = comboBox1.Text;
                        serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                        serialPort1.Open();
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button9.Enabled = false;
                        button10.Enabled = false;
                        button11.Enabled = true;
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        comboBox4.Enabled = true;
                        button1.Text = "Disconnect";
                    }
                    else
                    {
                        getAvailablePorts();
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                textBox13.Text = "Unauthorized Access Exception";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            getAvailablePorts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "")
            {
                comboBox4.Text = "ROBOT 1";
            }
            else if (button2.Text == "Connect")
            {
                button2.Text = "Disconnect";
                comboBox4.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
            else if (button2.Text == "Disconnect")
            {
                button2.Text = "Connect";
                comboBox4.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,M," + Convert.ToString(vScrollBar1.Value) + "," + Convert.ToString(vScrollBar2.Value) + ",1"); //MOTOR,I
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }
        private void serialPrint(String text)
        {
            textBox13.AppendText(">>" + text + "\n");
            serialPort1.WriteLine(text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,M," + Convert.ToString(vScrollBar1.Value) + "," + Convert.ToString(vScrollBar2.Value) + ",2"); //MOTOR,I
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,L," + Convert.ToString(vScrollBar8.Value) + "," + Convert.ToString(vScrollBar7.Value)); //MOTOR,L,Left motor,Right Motor
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,D," + Convert.ToString(vScrollBar6.Value) + "," + Convert.ToString(vScrollBar5.Value)); //MOTOR,D,Left motor,Right Motor
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,R"); //MOTOR,R
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,I"); //MOTOR,I
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,S,1"); //MOTOR,S,1/2
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,H," + Convert.ToString(numericUpDown1.Value) + "," + Convert.ToString(numericUpDown2.Value) + "," + Convert.ToString(numericUpDown3.Value) + ",1");  //MOTOR,H,kp,ki,kd,1/2
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,S,2"); //MOTOR,S,1/2
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint(Convert.ToString(comboBox4.Text) + ",MOTOR,H," + Convert.ToString(numericUpDown6.Value) + "," + Convert.ToString(numericUpDown5.Value) + "," + Convert.ToString(numericUpDown4.Value) + ",2");  //MOTOR,H,kp,ki,kd,1/2
            if (serialDebug)
            {
                textBox13.AppendText("<<" + serialPort1.ReadLine() + "\n");
                serialPort1.DiscardInBuffer();
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String dataRead = serialPort1.ReadLine();
            serialPort1.DiscardInBuffer(); //clear the RX line
            textBox13.Invoke(new EventHandler(delegate
            {
                textBox13.AppendText("Return: " + dataRead + "\n");
            }));
            int a, b, c, d;
            String s1 = "", s2 = "", s3 = "", s4 = "";
            String removeFstHeaderString = "";
            bool abcd = false;
            comboBox4.Invoke(new EventHandler(delegate
            {
                abcd = dataRead.StartsWith(comboBox4.Text);
            }));
            if (abcd)
            {
                a = dataRead.IndexOf(",");
                removeFstHeaderString = dataRead.Substring(a + 1);
                if (removeFstHeaderString.StartsWith("s"))
                {
                    a = removeFstHeaderString.IndexOf(",");
                    b = removeFstHeaderString.IndexOf(",", a + 1);
                    c = removeFstHeaderString.IndexOf(",", b + 1);
                    d = removeFstHeaderString.IndexOf(",", c + 1);
                    s1 = removeFstHeaderString.Substring(a + 1, b - a - 1);
                    s2 = removeFstHeaderString.Substring(b + 1, c - b - 1);
                    s3 = removeFstHeaderString.Substring(c + 1, d - c - 1);
                    s4 = removeFstHeaderString.Substring(d + 1);
                    if (s4.StartsWith("1"))
                    {
                        numericUpDown1.Invoke(new EventHandler(delegate
                        {
                            numericUpDown1.Value = Convert.ToDecimal(s1);
                        }));
                        numericUpDown2.Invoke(new EventHandler(delegate
                        {
                            numericUpDown2.Value = Convert.ToDecimal(s2);
                        }));
                        numericUpDown3.Invoke(new EventHandler(delegate
                        {
                            numericUpDown3.Value = Convert.ToDecimal(s3);
                        }));
                    }
                    else if (s4.StartsWith("2"))
                    {
                        numericUpDown6.Invoke(new EventHandler(delegate
                        {
                            numericUpDown6.Value = Convert.ToDecimal(s1);
                        }));
                        numericUpDown5.Invoke(new EventHandler(delegate
                        {
                            numericUpDown5.Value = Convert.ToDecimal(s2);
                        }));
                        numericUpDown4.Invoke(new EventHandler(delegate
                        {
                            numericUpDown4.Value = Convert.ToDecimal(s3);
                        }));
                    }
                }
                else if (dataRead.StartsWith("r"))
                {
                    a = removeFstHeaderString.IndexOf(",");
                    b = removeFstHeaderString.IndexOf(",", a + 1);
                    s1 = removeFstHeaderString.Substring(a + 1, b - a - 1);
                    s2 = removeFstHeaderString.Substring(b + 1);
                    textBox1.Invoke(new EventHandler(delegate
                    {
                        textBox1.Text = s1;
                    }));
                    textBox2.Invoke(new EventHandler(delegate
                    {
                        textBox2.Text = s2;
                    }));
                }
            }
            a = dataRead.IndexOf(",");
            b = dataRead.IndexOf(",", a + 1);
            s2 = dataRead.Substring(a + 1, b - a - 1);

            textBox13.Invoke(new EventHandler(delegate
            {
                textBox13.AppendText("Returnss: " + s2 + "\n");
            }));
            if (s2.StartsWith("IMU"))
            {
                if (dataRead.StartsWith("1"))
                {

                    a = dataRead.IndexOf(",", b + 1);
                    s3 = dataRead.Substring(b + 1, a - b - 1);
                    textBox11.Invoke(new EventHandler(delegate
                    {
                        textBox11.Text = s3;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox14.Invoke(new EventHandler(delegate
                    {
                        textBox14.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox15.Invoke(new EventHandler(delegate
                    {
                        textBox15.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox18.Invoke(new EventHandler(delegate
                    {
                        textBox18.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox17.Invoke(new EventHandler(delegate
                    {
                        textBox17.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox16.Invoke(new EventHandler(delegate
                    {
                        textBox16.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox19.Invoke(new EventHandler(delegate
                    {
                        textBox19.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox20.Invoke(new EventHandler(delegate
                    {
                        textBox20.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox21.Invoke(new EventHandler(delegate
                    {
                        textBox21.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1);
                    textBox22.Invoke(new EventHandler(delegate
                    {
                        textBox22.Text = s4;
                    }));

                }
                else if (dataRead.StartsWith("2"))
                {

                    a = dataRead.IndexOf(",", b + 1);
                    s3 = dataRead.Substring(b + 1, a - b - 1);
                    textBox32.Invoke(new EventHandler(delegate
                    {
                        textBox32.Text = s3;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox31.Invoke(new EventHandler(delegate
                    {
                        textBox31.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox30.Invoke(new EventHandler(delegate
                    {
                        textBox30.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox27.Invoke(new EventHandler(delegate
                    {
                        textBox27.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox28.Invoke(new EventHandler(delegate
                    {
                        textBox28.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox29.Invoke(new EventHandler(delegate
                    {
                        textBox29.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox24.Invoke(new EventHandler(delegate
                    {
                        textBox24.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox25.Invoke(new EventHandler(delegate
                    {
                        textBox25.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox26.Invoke(new EventHandler(delegate
                    {
                        textBox26.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1);
                    textBox23.Invoke(new EventHandler(delegate
                    {
                        textBox23.Text = s4;
                    }));

                }
                else if (dataRead.StartsWith("3"))
                {

                    a = dataRead.IndexOf(",", b + 1);
                    s3 = dataRead.Substring(b + 1, a - b - 1);
                    textBox42.Invoke(new EventHandler(delegate
                    {
                        textBox42.Text = s3;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox41.Invoke(new EventHandler(delegate
                    {
                        textBox41.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox40.Invoke(new EventHandler(delegate
                    {
                        textBox40.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox37.Invoke(new EventHandler(delegate
                    {
                        textBox37.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox38.Invoke(new EventHandler(delegate
                    {
                        textBox38.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox39.Invoke(new EventHandler(delegate
                    {
                        textBox39.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox34.Invoke(new EventHandler(delegate
                    {
                        textBox34.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox35.Invoke(new EventHandler(delegate
                    {
                        textBox35.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox36.Invoke(new EventHandler(delegate
                    {
                        textBox36.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1);
                    textBox33.Invoke(new EventHandler(delegate
                    {
                        textBox33.Text = s4;
                    }));

                }
                else if (dataRead.StartsWith("4"))
                {

                    a = dataRead.IndexOf(",", b + 1);
                    s3 = dataRead.Substring(b + 1, a - b - 1);
                    textBox52.Invoke(new EventHandler(delegate
                    {
                        textBox52.Text = s3;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox51.Invoke(new EventHandler(delegate
                    {
                        textBox51.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox50.Invoke(new EventHandler(delegate
                    {
                        textBox50.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox37.Invoke(new EventHandler(delegate
                    {
                        textBox47.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox48.Invoke(new EventHandler(delegate
                    {
                        textBox48.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox49.Invoke(new EventHandler(delegate
                    {
                        textBox49.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox44.Invoke(new EventHandler(delegate
                    {
                        textBox44.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox45.Invoke(new EventHandler(delegate
                    {
                        textBox45.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1, a - b - 1);
                    textBox46.Invoke(new EventHandler(delegate
                    {
                        textBox46.Text = s4;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1);
                    textBox43.Invoke(new EventHandler(delegate
                    {
                        textBox43.Text = s4;
                    }));

                }
            }
            else if (s2.StartsWith("DMP"))
            {
                if (dataRead.StartsWith("1"))
                {

                    a = dataRead.IndexOf(",", b + 1);
                    s3 = dataRead.Substring(b + 1, a - b - 1);
                    textBox55.Invoke(new EventHandler(delegate
                    {
                        textBox55.Text = s3;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox54.Invoke(new EventHandler(delegate
                    {
                        textBox54.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1);
                    textBox53.Invoke(new EventHandler(delegate
                    {
                        textBox53.Text = s4;
                    }));
                }
                else if (dataRead.StartsWith("2"))
                {

                    a = dataRead.IndexOf(",", b + 1);
                    s3 = dataRead.Substring(b + 1, a - b - 1);
                    textBox58.Invoke(new EventHandler(delegate
                    {
                        textBox58.Text = s3;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox57.Invoke(new EventHandler(delegate
                    {
                        textBox57.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1);
                    textBox56.Invoke(new EventHandler(delegate
                    {
                        textBox56.Text = s4;
                    }));
                }
                else if (dataRead.StartsWith("3"))
                {

                    a = dataRead.IndexOf(",", b + 1);
                    s3 = dataRead.Substring(b + 1, a - b - 1);
                    textBox61.Invoke(new EventHandler(delegate
                    {
                        textBox61.Text = s3;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox60.Invoke(new EventHandler(delegate
                    {
                        textBox60.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1);
                    textBox59.Invoke(new EventHandler(delegate
                    {
                        textBox59.Text = s4;
                    }));
                }

                else if (dataRead.StartsWith("4"))
                {

                    a = dataRead.IndexOf(",", b + 1);
                    s3 = dataRead.Substring(b + 1, a - b - 1);
                    textBox64.Invoke(new EventHandler(delegate
                    {
                        textBox64.Text = s3;
                    }));
                    b = dataRead.IndexOf(",", a + 1);
                    s4 = dataRead.Substring(a + 1, b - a - 1);
                    textBox63.Invoke(new EventHandler(delegate
                    {
                        textBox63.Text = s4;
                    }));
                    a = dataRead.IndexOf(",", b + 1);
                    s4 = dataRead.Substring(b + 1);
                    textBox62.Invoke(new EventHandler(delegate
                    {
                        textBox62.Text = s4;
                    }));
                }

            }

        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyPressed)
            { return; }
            if (serialPort1.IsOpen)
            {
                int correctKey = 0;
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        vScrollBar6.Value = 200;
                        vScrollBar5.Value = 200;
                        correctKey = 1;
                        break;
                    case Keys.Down:
                        vScrollBar6.Value = -200;
                        vScrollBar5.Value = -200;
                        correctKey = 1;
                        break;
                    case Keys.Left:
                        vScrollBar6.Value = -200;
                        vScrollBar5.Value = 200;
                        correctKey = 1;
                        break;
                    case Keys.Right:
                        vScrollBar6.Value = 200;
                        vScrollBar5.Value = -200;
                        correctKey = 1;
                        break;
                }
                if (correctKey == 1)
                    button6_Click(sender, e);
            }
            keyPressed = true;
        }

        private void textBox12_KeyUp(object sender, KeyEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Left:
                    case Keys.Right:
                        vScrollBar6.Value = 0;
                        vScrollBar5.Value = 0;
                        button6_Click(sender, e);
                        break;
                }
            }
            keyPressed = false;
         }
    }
    
}
