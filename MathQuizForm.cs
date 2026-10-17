using System;
using System.Drawing;
using System.Windows.Forms;

namespace Naidis_IKTpv25_Windows_Forms
{
    public partial class MathQuizForm : Form
    {
        private Label taskLabel;
        private Label scoreLabel;
        private NumericUpDown answerBox;
        private Button checkButton;
        private Random random = new Random();
        private int a, b;
        private int score = 0;
        private int questionNr = 0;
        private const int QuestionCount = 5;

        public MathQuizForm()
        {
            InitializeComponent();
            Text = "Matemaatiline mäng";
            Size = new Size(350, 250);
            StartPosition = FormStartPosition.CenterScreen;

            taskLabel = new Label();
            taskLabel.Font = new Font("Arial", 18, FontStyle.Bold);
            taskLabel.AutoSize = true;
            taskLabel.Location = new Point(30, 30);

            answerBox = new NumericUpDown();
            answerBox.Location = new Point(30, 90);
            answerBox.Width = 100;
            answerBox.Maximum = 200;

            checkButton = new Button();
            checkButton.Text = "Kontrolli";
            checkButton.Location = new Point(150, 88);
            checkButton.Click += CheckButton_Click;

            scoreLabel = new Label();
            scoreLabel.Text = "Punktid: 0";
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(30, 150);

            Controls.Add(taskLabel);
            Controls.Add(answerBox);
            Controls.Add(checkButton);
            Controls.Add(scoreLabel);

            NextQuestion();
        }

        private void NextQuestion()
        {
            questionNr++;
            a = random.Next(1, 51);
            b = random.Next(1, 51);
            taskLabel.Text = $"{a} + {b} = ?";
            answerBox.Value = 0;
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            if (answerBox.Value == a + b)
            {
                score++;
                scoreLabel.Text = "Punktid: " + score;
            }

            if (questionNr == QuestionCount)
            {
                MessageBox.Show(
                    "Mäng läbi! Punkte: " + score + "/" + QuestionCount);
                Close();
            }
            else
            {
                NextQuestion();
            }
        }
    }
}
