using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Sudoku
{
    public partial class Form1 : Form
    {
        int[,] cucc = new int[9, 9];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sudokuGrid.Rows.Add(9);
            grid2.Rows.Add(8);
            
        }
        private void FillGrid(DataGridView grid, int[,] chart)
        {           
            if (grid.Rows.Count != chart.GetLength(0) || grid.Columns.Count != chart.GetLength(1)){MessageBox.Show("Grid and chart extension does not match"); return;}
            for (int r = 0; r < chart.GetLength(1);r++)// go through every row
            {
                for (int c = 0; c < chart.GetLength(0); c++)//go through every column
                {
                    grid.Rows[r].Cells[c].Value = chart[r, c]; // assign the corresponding value
                }
            }
        }
        private int[,] ReadGrind(DataGridView grid)
        {
            int[,] chart = new int[9, 9];
            for (int r = 0; r < chart.GetLength(0); r++)// go through every row
            {
                for (int c = 0; c < chart.GetLength(1); c++)//go through every column
                {
                 chart[r, c] = Convert.ToInt32(grid.Rows[r].Cells[c].Value); 
                }
            }
            return chart;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FillGrid(sudokuGrid, Sudoku.Make());
           
            FillGrid(sudokuGrid, Sudoku.Solve(cucc));
            int[,] test = new int[9,9];
            int i = 0;
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    test[r, c] = i;
                    i++;
                }
            }
          //  FillGrid(sudokuGrid, test);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cucc = ReadGrind(sudokuGrid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> valueSet = new List<int>(Enumerable.Range(-9, 9));
        }
    
    }





    public static class Sudoku
    {
        public static int[,] Generate()
        {
            int[,] chart = new int[9,9]; 
            int[] allValues = {1,2,3,4,5,6,7,8,9};

            List<int> currentRowValues = new List<int>(); // all the values in the current row 
            List<int> currentColumnValues = new List<int>();// all the values in the current column
            List<int> currentBoxValues = new List<int>();// all the values in the current box

            List<int> possibleValues = new List<int>();

            Random rnd = new Random();
          
            for (int r = 0; r <=8; r++)//rows
            {
                for (int c = 0; c <= 8; c++)//columns in every row
                {
                    currentColumnValues = RangeOf2DArrayToList(chart,0,8,c,c);
                    currentRowValues = RangeOf2DArrayToList(chart,r,r,0,8);
                    currentColumnValues = currentColumnValues.Concat(currentRowValues).ToList();
                    possibleValues = allValues.Except(currentColumnValues).ToList();
                    int fff = rnd.Next(possibleValues.Count);
                    int result = possibleValues[fff];
                    chart[r, c] = result;
                    currentRowValues.Add(result);
                }
                currentRowValues.Clear();
            }
            return chart;
        }
        private static List<int> RangeOf2DArrayToList(int[,] source, int rowMin, int rowMax, int columnMin, int columnMax)
        {
            List<int> result = new List<int>();
            for (int i = rowMin; i <= rowMax; i++ )
            {
                for (int k = columnMin; k <= columnMax; k++)
                {
                    result.Add(source[i, k]);
                }
            }
            return result;
        }

        public static int[,] Make()
        {
            int[,] result = new int[9,9];
            List<int>[,] array_Possibilities = new List<int>[9, 9]; 
            
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //the default possibilites for a blank sudoku

            for (int r = 0; r <= 8; r++)// fill in the array
                for (int c = 0; c <= 8; c++)
                    array_Possibilities[r, c] = new List<int>(input);


            Random rnd = new Random();
            for (int i = 0; i <= 80; i++)
            {
                int lowest = 9;
                List<List<int>> shortlist = new List<List<int>>();
                List<int> x = new List<int>();
                List<int> y = new List<int>();
                int finalR = 0;
                int finalC = 0;
                foreach (List<int> intlist in array_Possibilities)
                    if (intlist.Count != 0 && intlist.Count < lowest)
                    {
                        lowest = intlist.Count;
                    }
                for (int r = 0; r <= 8; r++)
                    for (int c = 0; c <= 8; c++)
                        if (array_Possibilities[r, c].Count == lowest)
                        {
                            shortlist.Add(array_Possibilities[r, c]);
                            x.Add(r);
                            y.Add(c);
                        }
                int[] counter = new int[9];

                for (int k = 1; k <= 9; k++)
                    foreach (List<int> intlist in shortlist)
                        if (intlist.Contains(k)) { counter[k - 1]++; }
                int minAmount = 420;
                List<int> minValues = new List<int>();
                int min;
                foreach (int number in counter)
                    if (number < minAmount && number != 0)
                    {
                        minAmount = number;
                    }
                if (minAmount == 420) { break; }
                for (int s = 1; s <= 9; s++)
                    if (counter[s - 1] == minAmount) { minValues.Add(s); }
                min = minValues[rnd.Next(minValues.Count)];
                for (int p = 0; p < shortlist.Count; p++)
                {
                    if (shortlist[p].Contains(min))
                    {
                        finalR = x[p];
                        finalC = y[p];
                        break;
                    }
                }



                List<int> cl = array_Possibilities[finalR, finalC];
                int res = cl[cl.IndexOf(min)];
                result[finalR, finalC] = res;
                cl.Clear();

                for (int c = 0; c <= 8; c++)
                { array_Possibilities[finalR, c].Remove(res); }

                for (int r = 0; r <= 8; r++)
                { array_Possibilities[r, finalC].Remove(res); }

                RemoveChickens(0, 0, 2, 2, array_Possibilities, res, finalR, finalC);
                RemoveChickens(0, 3, 2, 5, array_Possibilities, res, finalR, finalC);
                RemoveChickens(0, 6, 2, 8, array_Possibilities, res, finalR, finalC);
                RemoveChickens(3, 0, 5, 2, array_Possibilities, res, finalR, finalC);
                RemoveChickens(3, 3, 5, 5, array_Possibilities, res, finalR, finalC);
                RemoveChickens(3, 6, 5, 8, array_Possibilities, res, finalR, finalC);
                RemoveChickens(6, 0, 8, 2, array_Possibilities, res, finalR, finalC);
                RemoveChickens(6, 3, 8, 5, array_Possibilities, res, finalR, finalC);
                RemoveChickens(6, 6, 8, 8, array_Possibilities, res, finalR, finalC);
              /*  if (finalR <=2 && finalC <= 2)
                {
                    for (int r = 0; r <= 2; r++)
                        for (int c = 0; c <= 2; c++)
                            array_Possibilities[r, c].Remove(res);
                }*/
               
            }
               return result;
            

            
        }
        public static int[,] Solve(int[,] chart)
        {
            int[,] result = new int[9, 9];
            List<int>[,] array_Possibilities = new List<int>[9, 9];

            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //the default possibilites for a blank sudoku

            for (int r = 0; r <= 8; r++)// fill in the array
                for (int c = 0; c <= 8; c++)
                    array_Possibilities[r, c] = new List<int>(input);

            for (int r = 0; r <= 8; r++)
                for (int c = 0; c <= 8; c++)
                    if (chart[r,c] != 0)
                    {
                        int res = chart[r, c];
                        result[r, c] = res;
                        List<int> cl = array_Possibilities[r, c];
                        cl.Clear();
                        for (int c2 = 0; c2 <= 8; c2++)
                        { array_Possibilities[r, c2].Remove(res); }

                        for (int r2 = 0; r2 <= 8; r2++)
                        { array_Possibilities[r2, c].Remove(res); }

                        RemoveChickens(0, 0, 2, 2, array_Possibilities, res, r, c);
                        RemoveChickens(0, 3, 2, 5, array_Possibilities, res, r, c);
                        RemoveChickens(0, 6, 2, 8, array_Possibilities, res, r, c);
                        RemoveChickens(3, 0, 5, 2, array_Possibilities, res, r, c);
                        RemoveChickens(3, 3, 5, 5, array_Possibilities, res, r, c);
                        RemoveChickens(3, 6, 5, 8, array_Possibilities, res, r, c);
                        RemoveChickens(6, 0, 8, 2, array_Possibilities, res, r, c);
                        RemoveChickens(6, 3, 8, 5, array_Possibilities, res, r, c);
                        RemoveChickens(6, 6, 8, 8, array_Possibilities, res, r, c);
                    }
            Random rnd = new Random();
            do
            {
                int lowest = 9;
                List<List<int>> shortlist = new List<List<int>>();
                List<int> x = new List<int>();
                List<int> y = new List<int>();
                int finalR = 0;
                int finalC = 0;
                foreach (List<int> intlist in array_Possibilities)
                    if (intlist.Count != 0 && intlist.Count < lowest)
                    {
                        lowest = intlist.Count;
                    }
                for (int r = 0; r <= 8; r++)
                    for (int c = 0; c <= 8; c++)
                        if (array_Possibilities[r, c].Count == lowest)
                        {
                            shortlist.Add(array_Possibilities[r, c]);
                            x.Add(r);
                            y.Add(c);
                        }
                int[] counter = new int[9];

                for (int k = 1; k <= 9; k++)
                    foreach (List<int> intlist in shortlist)
                        if (intlist.Contains(k)) { counter[k - 1]++; }
                int minAmount = 420;
                List<int> minValues = new List<int>();
                int min;
                foreach (int number in counter)
                    if (number < minAmount && number != 0)
                    {
                        minAmount = number;
                    }
                if (minAmount == 420) { break; }
                for (int s = 1; s <= 9; s++)
                    if (counter[s - 1] == minAmount) { minValues.Add(s); }
                min = minValues[rnd.Next(minValues.Count)];
                for (int p = 0; p < shortlist.Count; p++)
                {
                    if (shortlist[p].Contains(min))
                    {
                        finalR = x[p];
                        finalC = y[p];
                        break;
                    }
                }



                List<int> cl = array_Possibilities[finalR, finalC];
                int res = cl[cl.IndexOf(min)];
                result[finalR, finalC] = res;
                cl.Clear();

                for (int c = 0; c <= 8; c++)
                { array_Possibilities[finalR, c].Remove(res); }

                for (int r = 0; r <= 8; r++)
                { array_Possibilities[r, finalC].Remove(res); }

                RemoveChickens(0, 0, 2, 2, array_Possibilities, res, finalR, finalC);
                RemoveChickens(0, 3, 2, 5, array_Possibilities, res, finalR, finalC);
                RemoveChickens(0, 6, 2, 8, array_Possibilities, res, finalR, finalC);
                RemoveChickens(3, 0, 5, 2, array_Possibilities, res, finalR, finalC);
                RemoveChickens(3, 3, 5, 5, array_Possibilities, res, finalR, finalC);
                RemoveChickens(3, 6, 5, 8, array_Possibilities, res, finalR, finalC);
                RemoveChickens(6, 0, 8, 2, array_Possibilities, res, finalR, finalC);
                RemoveChickens(6, 3, 8, 5, array_Possibilities, res, finalR, finalC);
                RemoveChickens(6, 6, 8, 8, array_Possibilities, res, finalR, finalC);
            } while (true);

                    return result;
        }
        public static void RemoveChickens(int minR, int minC, int maxR, int maxC, List<int>[,] a_P, int res, int candiR, int candiC)
        {
            if (candiR >= minR && candiR <= maxR && candiC >= minC && candiC <= maxC)
            {
                for (int r = minR; r <= maxR; r++)
                    for (int c = minC; c <= maxC; c++)
                        a_P[r, c].Remove(res);
            }
        }
        public static int[,] AmountOfPossibilitiesTo2DArray(List<int>[,] source)
        {
            int[,] result = new int[9, 9];
            for (int r = 0; r <= 8 ; r++)
            {
                for (int c = 0; c <= 8; c++)
                {
                    result[r, c] = source[r, c].Count();
                }
            }
            return result;
        }
    }
}
