using System;
using System.Windows.Forms;

namespace Uno
{
    public partial class FrmUserData : Form
    {
        public FrmUserData()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameData.PlayerName = txtPlayerName.Text.Trim();
            if (GameData.PlayerName.Length == 0)
            {
                MessageBox.Show("Please enter assembly name.", "Uh oh!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPlayerName.Focus();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}