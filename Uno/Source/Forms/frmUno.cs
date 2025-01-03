using System;
using System.Windows.Forms;

namespace Uno
{
    public partial class FrmUno : Form
    {
        public string[] Args { get; }

        public FrmUno(string[] args)
        {
            Args = args;
            InitializeComponent();
            Game.Init();
            GameData.InitData(this);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Game.Started)
            {
                Game.StartNewGame();
            }
            else
            {
                if (!Game.Over)
                {
                    var res = MessageBox.Show(this, "Do you want to abort this game?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                Game.StartNewGame();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (Game.Started && !Game.Over)
            {
                tableLayoutPanel.Enabled = false;
                Logic.Play(sender, e);
                Application.DoEvents();
                tableLayoutPanel.Enabled = true;
            }
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Game.Started)
            {
                Painter.PaintCards(sender, e);
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            Logger.FuncInit("frmUno.btnPass_Click");
            Logic.PlayerTurn = false;
            btnPass.Enabled = false;
            Logger.FuncInit("frmUno.btnPass_Click");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAbout())
            {
                frm.ShowDialog();
            }
        }

        private void frmUno_Load(object sender, EventArgs e)
        {
            Logger.FuncInit("frmUno.frmUno_Load");
                Tools.CalculateCardRegions();
            Logger.FuncExit("frmUno.frmUno_Load");
        }

        private void frmUno_Resize(object sender, EventArgs e)
        {
            Logger.FuncInit("frmUno.frmUno_Resize");
                Tools.CalculateCardRegions();
            Logger.FuncExit("frmUno.frmUno_Resize");
        }
    }
}