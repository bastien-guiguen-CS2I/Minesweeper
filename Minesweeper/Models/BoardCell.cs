using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Models
{
    public class BoardCell
    {
        public bool HasMine {  get; set; } = false;
        public bool HasFlag {  get; set; } = false;
        public int MinesAround { get; set; } = -1;
        public bool IsRevealed { get; set; } = false;

    }
}
