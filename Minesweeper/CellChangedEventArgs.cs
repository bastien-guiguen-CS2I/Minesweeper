using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Models;

namespace Minesweeper
{
    public class CellChangedEventArgs : EventArgs
    {
        public BoardCell Cell { get; set; }

        public CellChangedEventArgs(BoardCell cell)
        {
            Cell = cell;
        }
    }
}

