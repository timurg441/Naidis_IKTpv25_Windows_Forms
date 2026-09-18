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
    public partial class PictureViewerForm : Form
    {
        private PictureBox pictureBox;
        private CheckBox stretchCheckBox;
        private Button showButton;
        private Button clearButton;
        private Button backgroundButton;
        private Button closeButton;
        private FlowLayoutPanel buttonPanel;
        private TableLayoutPanel tableLayoutPanel;

        public PictureViewerForm()
        {
            this.Text = "Pildi vaatamise programm";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2
            };
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));

            pictureBox = new PictureBox
            {
                BorderStyle = BorderStyle.Fixed3D,
                Dock = DockStyle.Fill
            };
            tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel.SetColumnSpan(pictureBox, 2);

            stretchCheckBox = new CheckBox
            {
                Text = "Stretch",
                AutoSize = true,
                Dock = DockStyle.Fill
            };
            stretchCheckBox.CheckedChanged += (s, e) =>
            {
                pictureBox.SizeMode = stretchCheckBox.Checked
                    ? PictureBoxSizeMode.StretchImage
                    : PictureBoxSizeMode.Normal;
            };
            tableLayoutPanel.Controls.Add(stretchCheckBox, 0, 1);

            buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft
            };

            closeButton = new Button { Text = "Sule", AutoSize = true };
            closeButton.Click += (s, e) => this.Close();

            clearButton = new Button { Text = "Puhasta pilt", AutoSize = true };
            clearButton.Click += (s, e) => pictureBox.Image = null;

            backgroundButton = new Button { Text = "Määra taustavärv", AutoSize = true };
            backgroundButton.Click += (s, e) =>
            {
                using (ColorDialog colorDlg = new ColorDialog())
                {
                    if (colorDlg.ShowDialog() == DialogResult.OK)
                        pictureBox.BackColor = colorDlg.Color;
                }
            };

            showButton = new Button { Text = "Näita pilti", AutoSize = true };
            showButton.Click += (s, e) =>
            {
                using (OpenFileDialog openDlg = new OpenFileDialog())
                {
                    openDlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (openDlg.ShowDialog() == DialogResult.OK)
                        pictureBox.Load(openDlg.FileName);
                }
            };

            buttonPanel.Controls.Add(closeButton);
            buttonPanel.Controls.Add(clearButton);
            buttonPanel.Controls.Add(backgroundButton);
            buttonPanel.Controls.Add(showButton);

            tableLayoutPanel.Controls.Add(buttonPanel, 1, 1);
            this.Controls.Add(tableLayoutPanel);
        }
    }
}