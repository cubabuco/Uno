using System;
using System.Windows.Forms;

namespace Uno
{
    public partial class FrmColorSelection : Form
    {
        public UnoColours SelectedColor = UnoColours.NoColor;

        public FrmColorSelection()
        {
            InitializeComponent();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            SelectedColor = UnoColours.Red;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            SelectedColor = UnoColours.Green;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            SelectedColor = UnoColours.Yellow;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            SelectedColor = UnoColours.Blue;
        }
    }
}