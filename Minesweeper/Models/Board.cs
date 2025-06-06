﻿using Minesweeper;
using Minesweeper.Controls;
using Minesweeper.Enums;
using Minesweeper.Models;
using System.Diagnostics;

public class Board
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public int Mines { get; set; }
    public BoardCell[,] Cells { get; set; }

    public event EventHandler<CellChangedEventArgs> CellChanged;

    public bool IsGameOver { get; private set; } = false;

    public Board(GameLevel gameLevel)
    {
        switch (gameLevel)
        {
            case GameLevel.Beginner:
                Rows = 10;
                Columns = 10;
                Mines = 10;
                break;

            case GameLevel.Intermediate:
                Rows = 16;
                Columns = 16;
                Mines = 40;
                break;

            case GameLevel.Expert:
                Rows = 16;
                Columns = 30;
                Mines = 99;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(gameLevel), "Niveau de jeu inconnu.");
        }

        Cells = new BoardCell[Rows, Columns];
        InitializeCells();
        SetMines();
        CalculateMinesAround();
    }

    private void InitializeCells()
    {
        Cells = new BoardCell[Rows, Columns];

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                Cells[row, col] = new BoardCell();
            }
        }
    }

    private void SetMines()
    {
        Random random = new Random();
        int minesPlaced = 0;

        while (minesPlaced < Mines)
        {
            int row = random.Next(Rows);
            int col = random.Next(Columns);

            if (!Cells[row, col].HasMine)
            {
                Cells[row, col].HasMine = true;
                minesPlaced++;
            }
        }
    }

    public void DebugBoard()
    {
        for (int row = 0; row < Rows; row++)
        {
            string line = "";

            for (int col = 0; col < Columns; col++)
            {
                if (Cells[row, col].HasMine)
                {
                    line += "* ";
                }
                else
                {
                    line += ". ";
                }
            }

            Console.WriteLine(line);
            Debug.WriteLine(line);
        }
    }

    public void SetFlag(int row, int col)
    {
        var cell = Cells[row, col];

        if (cell.IsRevealed)
        {
            return;
        }

        int flagCount = 0;
        foreach (var c in Cells)
        {
            if (c.HasFlag)
                flagCount++;
        }

        if (!cell.HasFlag && flagCount >= Mines)
        {
            return;
        }

        cell.HasFlag = !cell.HasFlag;

        if (CellChanged != null) 
        {
            CellChanged(this, new CellChangedEventArgs(cell));
        }
    }

    public void RevealCell(int row, int col)
    {
        var cell = Cells[row, col];

        if (cell.IsRevealed || cell.HasFlag || IsGameOver)
            return;

        cell.IsRevealed = true;
        CellChanged?.Invoke(this, new CellChangedEventArgs(cell));

        if (cell.HasMine)
        {
            IsGameOver = true;
            RevealAllMines();
            MessageBox.Show("💥 BOOM ! Vous avez perdu.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        if (cell.MinesAround == 0)
        {
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    int newRow = row + dr;
                    int newCol = col + dc;

                    if (newRow >= 0 && newRow < Rows && newCol >= 0 && newCol < Columns)
                    {
                        RevealCell(newRow, newCol);
                    }
                }
            }
        }

        CheckVictory(); 
    }

    private void CalculateMinesAround()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (Cells[row, col].HasMine)
                {
                    Cells[row, col].MinesAround = -1;
                    continue;
                }

                int minesAround = 0;
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        int newRow = row + dr;
                        int newCol = col + dc;

                        if (newRow >= 0 && newRow < Rows && newCol >= 0 && newCol < Columns &&
                            Cells[newRow, newCol].HasMine)
                        {
                            minesAround++;
                        }
                    }
                }

                Cells[row, col].MinesAround = minesAround;
            }
        }
    }

    private void RevealAllMines()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                var cell = Cells[row, col];
                if (cell.HasMine)
                {
                    cell.IsRevealed = true;
                    CellChanged?.Invoke(this, new CellChangedEventArgs(cell));
                }
            }
        }
    }

    private void CheckVictory()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                var cell = Cells[row, col];

                if (!cell.HasMine && !cell.IsRevealed)
                    return;
            }
        }

        IsGameOver = true;
        RevealAllMines();
        MessageBox.Show("🎉 Bravo, vous avez gagné !", "Victoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
