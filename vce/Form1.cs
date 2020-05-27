using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace vce
{
   

    public partial class Form1 : Form
    {
        VceTest exam1 = new VceTest();
        int i = 0;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxQuestion_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
            textBoxQuestion.Text = exam1.qtest[0].QuestionToAnswer;
            radioButtonAnswer1.Text = exam1.qtest[0].False1Answer;
            radioButtonAnswer2.Text = exam1.qtest[0].CorrectAnswer;
            radioButtonAnswer3.Text = exam1.qtest[0].False2Answer;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
           int x= Calculate();
            label1.Text = i+1 + " of " + exam1.qtest.Length;
            i++;
            if ( i+1==exam1.qtest.Length-1)
            {
                buttonNext.Text = "End";
            }
            else if (i+1==exam1.qtest.Length)
            {
              
            }
                    
                    }
        private int Calculate() 
        {
            if (radioButtonAnswer1.Checked && radioButtonAnswer1.Text == exam1.qtest[i].CorrectAnswer)
                score++;
          else  if (radioButtonAnswer2.Checked && radioButtonAnswer2.Text == exam1.qtest[i].CorrectAnswer)
                score++;
           else if (radioButtonAnswer3.Checked && radioButtonAnswer3.Text == exam1.qtest[i].CorrectAnswer)
                score++;
            return score;
        }
    }
}
