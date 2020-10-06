using System;
using System.Collections;
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
        //string output = "";
        string input = "";
        string value = "";
        List<string> listObj = new List<string>();
        List<int> listOpera = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtInput.Text = txtInput.Text + btn.Text;
            value += btn.Text;
            //input = input + listObj[listObj.Count - 1];
        }

        private void operator_click(object sender, EventArgs e)
        {
            listObj.Add(value);
            value = "";
            Button btn = (Button)sender;
            txtInput.Text = txtInput.Text + btn.Text;
            listObj.Add(btn.Text);
            if (btn.Text == "x" || btn.Text == "/")
                listOpera.Insert(0, listObj.Count - 1);
            else
                listOpera.Add(listObj.Count - 1);
            //input = input + listObj[listObj.Count - 1];
        }

        private void result_click(object sender, EventArgs e)
        {
            listObj.Add(value);
            value = "";
            string temp = "";
            for (int i = 0; i < listOpera.Count; i++)
            {
                
                //temp += listOpera[i].ToString();
                
                for (int j = i; j < listOpera.Count; j++)
                {
                    if (listOpera[j] > listOpera[i])
                    {
                        listOpera[j] -= 2;
                    }
                    temp += listOpera[j].ToString();
                }
                //temp += "/";
                
                
                int index = listOpera[i];
                temp = calculate(listObj[index - 1], listObj[index], listObj[index + 1]);
                listObj[index - 1] = temp;
                listObj.RemoveAt(index + 1);
                listObj.RemoveAt(index);
                
                /*
                if (listObj[i] == "+")
                {
                    temp = (Double.Parse(listObj[i - 1]) + Double.Parse(listObj[i + 1])).ToString();
                    listObj[i + 1] = temp;
                }
                else if (listObj[i] == "-")
                {
                    temp = (Double.Parse(listObj[i - 1]) - Double.Parse(listObj[i + 1])).ToString();
                    listObj[i + 1] = temp;
                }
                */
            }
            txtOutput.Text = temp;
        }
        private string calculate(string first, string ope, string second)
        {
            string result = "";
            switch (ope)
            {
                case "+":
                    result = (Double.Parse(first) + Double.Parse(second)).ToString();
                    break;
                case "-":
                    result = (Double.Parse(first) - Double.Parse(second)).ToString();
                    break;
                case "x":
                    result = (Double.Parse(first) * Double.Parse(second)).ToString();
                    break;
                case "/":
                    result = (Double.Parse(first) / Double.Parse(second)).ToString();
                    break;
            }
            return result;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
            listObj.Clear();
            listOpera.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            listObj.Add(value);
            value = "";
            listObj.RemoveAt(listObj.Count - 1);
            input = "";
            for (int i = 0; i < listObj.Count; i++)
                input = input + listObj[i];
            txtInput.Text = "";
            txtInput.Text = input;
        }

        private void btnXoa_KeyDown(object sender, KeyEventArgs e)
        {
            //e.KeyCode == Keys.Back;
        }
    }
}
