using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string opt = "";
        bool optdurum = false;
        double sonuc = 0;
        List<double> bellek = new List<double>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnes_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "+" || btn.Text == "-" || btn.Text == "*" || btn.Text == "/")
            {
                optdurum = true;
                string yeniopt = btn.Text;
                label1.Text = label1.Text + "" + txtsonuc.Text + "" + yeniopt;
                switch (opt)
                {
                    case "+": txtsonuc.Text = (sonuc + Double.Parse(txtsonuc.Text)).ToString(); break;
                    case "-": txtsonuc.Text = (sonuc - Double.Parse(txtsonuc.Text)).ToString(); break;
                    case "*": txtsonuc.Text = (sonuc * Double.Parse(txtsonuc.Text)).ToString(); break;
                    case "/": txtsonuc.Text = (sonuc / Double.Parse(txtsonuc.Text)).ToString(); break;
                }
                sonuc = Double.Parse(txtsonuc.Text);
                txtsonuc.Text = sonuc.ToString();
                opt = yeniopt;

            }
            else if (btn.Text == "CE")
            {
                txtsonuc.Text = "0";
            }
            else if (btn.Text == "C")
            {
                txtsonuc.Enabled = true;
                txtsonuc.Text = "0";
                label1.Text = "";
                opt = "";
                sonuc = 0;
                optdurum = false;

            }
            else if (btn.Text == "=")
            {
                label1.Text = "";
                optdurum = true;
                switch (opt)
                {
                    case "+": txtsonuc.Text = (sonuc + Double.Parse(txtsonuc.Text)).ToString(); break;
                    case "-": txtsonuc.Text = (sonuc - Double.Parse(txtsonuc.Text)).ToString(); break;
                    case "*": txtsonuc.Text = (sonuc * Double.Parse(txtsonuc.Text)).ToString(); break;
                    case "/": txtsonuc.Text = (sonuc / Double.Parse(txtsonuc.Text)).ToString(); break;
                }
                sonuc = Double.Parse(txtsonuc.Text);
                txtsonuc.Text = sonuc.ToString();
                opt = "";

            }
            else if (btn.Text == ".")
            {
                if (txtsonuc.Text == "0")
                {
                    txtsonuc.Text = "0";
                }
                else if (optdurum)
                {
                    txtsonuc.Text = "0";
                }
                if (!txtsonuc.Text.Contains(","))
                {
                    txtsonuc.Text += ",";
                }
                optdurum = false;
            }
            else if (btn.Text == "√")
            {
                double kok = Double.Parse(txtsonuc.Text);
                kok = Math.Sqrt(kok);
                txtsonuc.Text = kok.ToString();
            }
            else if (btn.Text == "x^2")
            {
                double kare = Double.Parse(txtsonuc.Text);
                kare = kare * kare;
                txtsonuc.Text = kare.ToString();

            }
            else if (btn.Text == "1/x")
            {
                if (txtsonuc.Text == "0")
                {
                    txtsonuc.Text = "Sıfıra Bölünmez Lütfen C Tuşuna Basınız";
                    txtsonuc.Enabled = false;
                  
                }
                else
                {
                    double ters = Double.Parse(txtsonuc.Text);
                    ters = Math.Pow(ters, -1);
                    txtsonuc.Text = ters.ToString();
                }
            }
            else if (btn.Text =="MC")
            {
                bellek.Clear();
            }
            else if (btn.Text == "M+")
            {
                optdurum = true;

                if (bellek.Count() == 0)
                {
                    bellek.Add(Double.Parse(txtsonuc.Text));

                }
                else
                {
                    double bdeger = bellek[0];
                    bdeger = bdeger + Double.Parse(txtsonuc.Text);
                    bellek[0] = bdeger;
                }
                    
            }
            else if (btn.Text == "MS")
            {
                bellek.Add(Double.Parse(txtsonuc.Text));
            }
            else if (btn.Text == "MR")
            {
                if(bellek.Count() == 0)
                {
                    txtsonuc.Text = "0";
                }
                else
                {
                    txtsonuc.Text = bellek[0].ToString();
                }
              
            }
            else if (btn.Text == "M-")
            {
                optdurum = true;
                if (bellek.Count() == 0)
                {
                    double bdeg = Double.Parse(txtsonuc.Text);
                    bdeg = -1 * bdeg;
                    bellek.Add(bdeg);

                }
                else
                {
                    double bdeger = bellek[0];
                    bdeger = bdeger -Double.Parse(txtsonuc.Text);
                    bellek[0] = bdeger;
                }

            }
            else if (btn.Text == "M")
            {
                if (bellek.Count() == 0)
                {
                    MessageBox.Show("Bellekte Herhangi Bir Değer Yoktur...!");

                }
                else
                {
                    string goster = "";
                    foreach (var item in bellek)
                    {
                        goster += "," + Convert.ToString(item);
                    }
                    MessageBox.Show("Bellekteki Değerler " + goster);
                }
                optdurum = true;
           
            }
            else
            {
                if (txtsonuc.Text == "0" || optdurum)
                {

                    txtsonuc.Clear();
                }

                optdurum = false;
                txtsonuc.Text += btn.Text;

            }

        }
    }
}
