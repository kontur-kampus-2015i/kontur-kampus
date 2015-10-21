using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace CleanCode.Samples
{
    class Tetris_TooLowLevel
    {
        private readonly int width;
        private readonly int height;
        private Cell[,] cells;
        
        public void ClearFullLines(ref int score)
        {
            for (int i = 1; i < height + 1; i++)
            {
                int count = 0;
                int line = 0;
                for (int j = 1; j < width + 1; j++)
                    if (cells[j, i].getState() == 1)
                    {
                        count++;
                        if (count == width) line = i;
                    }
                if (count == width)
                {
                    score++;
                    for (int h = line; h < height; h++)
                        for (int k = 1; k < width + 1; k++)
                            cells[k, h] = new Cell(k, h, cells[k, h + 1].getState());
                    for (int k = 1; k < width + 1; k++)
                        cells[k, height] = new Cell(k, height, 0);
                }

            }
        }

        public void ClearFullLines_Refactored(ref int score)
        {
            for (int lineIndex = 1; lineIndex < height + 1; lineIndex++)
            {
                if (LineIsFull(lineIndex))
                {
                    score++;
                    ShiftLinesDown(lineIndex);
                    ClearTopmostLine();
                }
            }
        }

        private void ClearTopmostLine()
        {
            throw new NotImplementedException();
        }

        private void ShiftLinesDown(int lineIndex)
        {
            throw new NotImplementedException();
        }

        private bool LineIsFull(int y)
        {
            throw new NotImplementedException();
        }
    }



    class Cell
    {
        private readonly int x;
        private readonly int y;
        private readonly int state;

        public Cell()
        {
            this.x = 0;
            this.y = 0;
            this.state = 0;
        }

        public Cell(int _x, int _y, int state)
        {
            this.x = _x;
            this.y = _y;
            this.state = state;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public int getState()
        {
            return state;
        }

    }

}