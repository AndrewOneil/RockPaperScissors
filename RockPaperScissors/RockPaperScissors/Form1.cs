using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;

        string[] choiceCPUList = { "rock", "paper", "scissors", "rock", "paper", "scissors" };
        int randomNumber= 0;
        Random rnd = new Random();
        string choiceCPU;
        string choicePlayer;
        int playerScore;
        int cpuScore;

        public Form1()
        {
            InitializeComponent();
            CountDownTimer.Enabled = true;
            choicePlayer = "none";

            txtCountdown.Text = "5";
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            pbPlayer.Image = Properties.Resources.rock;
            choicePlayer = "rock";
        }        

        private void btnPaper_Click(object sender, EventArgs e)
        {
            pbPlayer.Image = Properties.Resources.paper;
            choicePlayer = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            pbPlayer.Image = Properties.Resources.scissors;
            choicePlayer = "scissors";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            cpuScore = 0;
            rounds = 3;
            txtScore.Text = "Player: " + playerScore + " - " + "CPU: " + cpuScore;

            choicePlayer = "none";

            CountDownTimer.Enabled = true;

            pbPlayer.Image = Properties.Resources.qq;
            pbCPU.Image = Properties.Resources.qq;

            gameOver = false;
        }

        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            txtCountdown.Text = timerPerRound.ToString();

            txtRounds.Text = "Rounds: " + rounds;

            if(timerPerRound < 1)
            {
                CountDownTimer.Enabled = false;

                timerPerRound = 6;

                randomNumber = rnd.Next(0, choiceCPUList.Length);

                choiceCPU = choiceCPUList[randomNumber];

                switch(choiceCPU)
                {
                    case "rock":
                        pbCPU.Image = Properties.Resources.rock;

                        break;
                    case "paper":
                        pbCPU.Image = Properties.Resources.paper;

                        break;
                    case "scissors":
                        pbCPU.Image = Properties.Resources.scissors;
                        break;
                }
                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if(playerScore > cpuScore)
                    {
                        MessageBox.Show("Player won the game");
                    }
                    else
                    {
                        MessageBox.Show("CPU won the game");
                    }

                    gameOver = true;
                }
            }

            
        }

        private void checkGame()
        {
            if(choicePlayer == "rock" && choiceCPU == "paper")
            {
                cpuScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Paper Covers Rock");
            }
            else if (choicePlayer == "scissors" && choiceCPU == "rock")
            {
                cpuScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Rock Breaks Scissors");
            }
            else if (choicePlayer == "paper" && choiceCPU == "scissors")
            {
                cpuScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Scissors Cut Paper");
            }
            else if (choicePlayer == "paper" && choiceCPU == "rock")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Paper Covers Rock");
            }
            else if (choicePlayer == "rock" && choiceCPU == "scissors")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Rock Breaks Scissors");
            }
            else if (choicePlayer == "scissors" && choiceCPU == "paper")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Scissors Cut Paper");
            }
            else if (choicePlayer == "none")
            {
                MessageBox.Show("Make a choice");
            }
            else
            {
                MessageBox.Show("Draw!!");
            }

            startNextRound();
        }

        private void startNextRound()
        {
            if(gameOver == true)
            {

                return;
            }

            txtScore.Text = "Player: " + playerScore + " - " + "CPU: " + cpuScore;

            choicePlayer = "none";

            CountDownTimer.Enabled = true;

            pbPlayer.Image = Properties.Resources.qq;
            pbCPU.Image = Properties.Resources.qq;
        }
    }
}
