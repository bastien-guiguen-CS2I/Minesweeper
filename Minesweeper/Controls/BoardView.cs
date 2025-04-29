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

        public BoardView()
        {
            InitializeComponent();
        }

        public event EventHandler? BoardResized;

        public void InitializeBoardView(Board board)
        {
            Controls.Clear();

            this.Width = board.Columns * CellSize;
            this.Height = board.Rows * CellSize;

            for (var row = 0; row < board.Rows; row++)
            {
                for (var col = 0; col < board.Columns; col++)
                {
                    var pictureBox = new PictureBox
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Left = col * CellSize,
                        Top = row * CellSize,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = GetCellImage(board.Cells[row, col]),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    pictureBox.Click += (sender, e) =>
                    {
                        
                    };

                    Controls.Add(pictureBox);
                }
            }

            BoardResized?.Invoke(this, EventArgs.Empty);
        }



        private Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private Image GetCellImage(BoardCell cell)
        {
            if (cell.HasMine)
            {
                return ByteArrayToImage(Properties.Resources.standard); 
            }
            else
            {
                switch (cell.MinesAround)
                {
                    case 0:
                        return ByteArrayToImage(Properties.Resources.cell0);
                    case 1:
                        return ByteArrayToImage(Properties.Resources.cell1);
                    case 2:
                        return ByteArrayToImage(Properties.Resources.cell2);
                    case 3:
                        return ByteArrayToImage(Properties.Resources.cell3);
                    case 4:
                        return ByteArrayToImage(Properties.Resources.cell4);
                    case 5:
                        return ByteArrayToImage(Properties.Resources.cell5);
                    case 6:
                        return ByteArrayToImage(Properties.Resources.cell6);
                    case 7:
                        return ByteArrayToImage(Properties.Resources.cell7);
                    case 8:
                        return ByteArrayToImage(Properties.Resources.cell8);
                    default:
                        return ByteArrayToImage(Properties.Resources.standard);
                }
            }
        }
    }
}
