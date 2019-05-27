using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool player1Turn = true;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            bool gameOver = false;

            try
            {
                Button buttonClicked = (Button)sender;

                if(player1Turn)
                {
                    buttonClicked.Text = "X";
                }
                else
                {
                    buttonClicked.Text = "O";
                }

                buttonClicked.Enabled = false;

                gameOver = gameWon();

                if(gameOver)
                {
                    disableButtons();

                    if(player1Turn)
                    {
                        MessageBox.Show("X wins!");
                    }
                    else
                    {
                        MessageBox.Show("O wins!");
                    }
                }
                else if(turnCount >= 8)
                {
                    MessageBox.Show("The game was a tie!");
                }
                else
                {
                    turnCount++;
                    player1Turn = !player1Turn;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private Boolean gameWon()
        {
            if(!buttonTopLeft.Enabled)
            {
                if((buttonTopLeft.Text.Equals(buttonTopMiddle.Text)) && (buttonTopMiddle.Text.Equals(buttonTopRight.Text)))
                {
                    //x x x
                    //. . .
                    //. . .
                    return true;
                }
                else if((buttonTopLeft.Text.Equals(buttonMiddleLeft.Text)) && (buttonMiddleLeft.Text.Equals(buttonBottomLeft.Text)))
                {
                    //x . .
                    //x . .
                    //x . .
                    return true;
                }
                else if((buttonTopLeft.Text.Equals(buttonMiddleMiddle.Text)) && (buttonMiddleMiddle.Text.Equals(buttonBottomRight.Text)))
                {
                    //x . .
                    //. x .
                    //. . x
                    return true;
                }
            }

            if(!buttonBottomRight.Enabled)
            {
                if((buttonBottomRight.Text.Equals(buttonMiddleRight.Text)) && (buttonMiddleRight.Text.Equals(buttonTopRight.Text)))
                {
                    //. . x
                    //. . x
                    //. . x
                    return true;
                }
                else if((buttonBottomRight.Text.Equals(buttonBottomMiddle.Text)) && (buttonBottomMiddle.Text.Equals(buttonBottomLeft.Text)))
                {
                    //. . .
                    //. . .
                    //x x x
                    return true;
                }
            }

            if(!buttonMiddleMiddle.Enabled)
            {
                if((buttonMiddleMiddle.Text.Equals(buttonTopMiddle.Text)) && (buttonTopMiddle.Text.Equals(buttonBottomMiddle.Text)))
                {
                    //. x .
                    //. x .
                    //. x .
                    return true;
                }
                else if((buttonMiddleMiddle.Text.Equals(buttonMiddleLeft.Text)) && (buttonMiddleLeft.Text.Equals(buttonMiddleRight.Text)))
                {
                    //. . .
                    //x x x
                    //. . .
                    return true;
                }
                else if((buttonMiddleMiddle.Text.Equals(buttonBottomLeft.Text)) && (buttonBottomLeft.Text.Equals(buttonTopRight.Text)))
                {
                    //. . x
                    //. x .
                    //x . .
                    return true;
                }
            }

            return false;
        }

        private void disableButtons()
        {
            foreach(Control c in Controls)
            {
                if(c is Button)
                {
                    c.Enabled = false;
                }
            }
        }
    }
}
