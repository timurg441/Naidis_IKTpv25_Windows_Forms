using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naidis_IKTpv25_Windows_Forms
{
    public partial class MatchingGameForm : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private Label firstClicked = null;
        private Label secondClicked = null;
        private Timer timer;

        private Random random = new Random();
        private List<string> icons = new List<string>()
        {
            "b", "b", "N", "N", "m", "m", "v", "v",
            "w", "w", "z", "z", "N", "N", "k", "k"
        };

        public MatchingGameForm()
        {
            this.Text = "Sarnaste piltide leidmise mäng";
            this.Size = new Size(550, 550);
            this.StartPosition = FormStartPosition.CenterScreen;

            timer = new Timer { Interval = 750 };
            timer.Tick += Timer_Tick;

            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.CornflowerBlue,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                ColumnCount = 4,
                RowCount = 4
            };

            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }

            this.Controls.Add(tableLayoutPanel);
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            for (int i = 0; i < 16; i++)
            {
                Label label = new Label
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Font = new Font("Webdings", 48, FontStyle.Bold),
                    ForeColor = Color.CornflowerBlue
                };

                int randomNumber = random.Next(icons.Count);
                label.Text = icons[randomNumber];
                icons.RemoveAt(randomNumber);

                label.Click += Label_Click;
                tableLayoutPanel.Controls.Add(label);
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("Oled leidnud kõik paarid!", "Õnnitleme!");
            Close();
        }
    }
}
