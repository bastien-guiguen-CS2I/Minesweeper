using System;
using System.Windows.Forms;
using Minesweeper.Models;
using Minesweeper.Enums;

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        private Board board;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void StartNewGame(GameLevel level)
        {
            board = new Board(level);

            GameBoardView.BoardResized -= GameBoardView_BoardResized;
            GameBoardView.BoardResized += GameBoardView_BoardResized;

            GameBoardView.InitializeBoardView(board);
        }


        private void GameBoardView_BoardResized(object? sender, EventArgs e)
        {
            int padding = 40;
            int menuHeight = menuStrip1.Height;

            this.ClientSize = new Size(
                GameBoardView.Width + GameBoardView.Left + padding,
                GameBoardView.Height + GameBoardView.Top + menuHeight + padding
            );

            this.CenterToScreen();
        }

        private void nouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void debutantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame(GameLevel.Beginner);
        }

        private void intermediaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame(GameLevel.Intermediate);
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame(GameLevel.Expert);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
