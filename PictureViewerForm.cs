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