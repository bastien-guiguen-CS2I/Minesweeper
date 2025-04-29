using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Minesweeper.Models;

namespace Minesweeper.Controls
{
    public partial class BoardView : UserControl
    {
        #region Constants
        public const int CellSize = 18;
        #endregion

        private Board board;

        public BoardView()
        {
            InitializeComponent();
        }

        public event EventHandler? BoardResized;

        public void InitializeBoardView(Board board)
        {
            this.board = board;
            Controls.Clear();

            this.Width = board.Columns * CellSize;
            this.Height = board.Rows * CellSize;

            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Columns; col++)
                {
                    var pictureBox = new PictureBox
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Left = col * CellSize,
                        Top = row * CellSize,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = GetCellImage(board.Cells[row, col]),
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = new Point(row, col) 
                    };

                    pictureBox.MouseClick += HandleMouseClick;

                    Controls.Add(pictureBox);
                }
            }

            BoardResized?.Invoke(this, EventArgs.Empty);
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HandleLeftClick(sender, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                HandleRightClick(sender, e);
            }
        }

        private void HandleLeftClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("You clicked on the left button!");
        }

        private void HandleRightClick(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag is Point point)
            {
                board.SetFlag(point.X, point.Y);
                var cell = board.Cells[point.X, point.Y];

                pictureBox.Image = cell.HasFlag
                    ? ByteArrayToImage(Properties.Resources.drapeau)
                    : GetCellImage(cell);
            }
        }

        private Image ByteArrayToImage(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        private Image GetCellImage(BoardCell cell)
        {
            if (cell.HasFlag)
                return ByteArrayToImage(Properties.Resources.drapeau);

            if (cell.HasMine)
                return ByteArrayToImage(Properties.Resources.standard);

            return cell.MinesAround switch
            {
                0 => ByteArrayToImage(Properties.Resources.cell0),
                1 => ByteArrayToImage(Properties.Resources.cell1),
                2 => ByteArrayToImage(Properties.Resources.cell2),
                3 => ByteArrayToImage(Properties.Resources.cell3),
                4 => ByteArrayToImage(Properties.Resources.cell4),
                5 => ByteArrayToImage(Properties.Resources.cell5),
                6 => ByteArrayToImage(Properties.Resources.cell6),
                7 => ByteArrayToImage(Properties.Resources.cell7),
                8 => ByteArrayToImage(Properties.Resources.cell8),
                _ => ByteArrayToImage(Properties.Resources.standard)
            };
        }
    }
}
