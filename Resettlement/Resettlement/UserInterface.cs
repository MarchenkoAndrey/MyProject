using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Resettlement
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var strOne = new string[1]
            {
                squareOne_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            var strTwo = new string[1]
            {
                squareTwo_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            StartAndFinishProgram.Program(strOne,strTwo, false); 
//            var s1 = ReadFromFile.ReadFileOneRoom(strOne);
//            var s2 = ReadFromFile.ReadFileTwoRoom(strTwo);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void countFloor_input_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(countFloor_input.Text) != 0)
            {
                MessageBox.Show("Реализован расчет пока только для 1-го этажа");
            }
        }

        private void fullSearch_btn_Click(object sender, EventArgs e)
        {
            var strOne = new string[1]
            {
                squareOne_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            var strTwo = new string[1]
            {
                squareTwo_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            StartAndFinishProgram.Program(strOne, strTwo, true);
            //            var s1 = ReadFromFile.ReadFileOneRoom(strOne);
            //            var s2 = ReadFromFile.ReadFileTwoRoom(strTwo);
        }
    }
}
