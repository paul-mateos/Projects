using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BookGame.ViewModels
{
    public class GameBoardViewModel
    {
        public Stone[][] Triangle { get; set; }
        public Dictionary<string, Stone> TriangeDictionary { get; set; }

        public Stone[,] LeftTurnPanel { get; set; }
        public Stone[,] RightTurnPanel { get; set; }

        public List<Point> SelectedStones { get; set; }
        public List<string> StoneColors { get; set; }

        public Dictionary<string, int> ColorSequence { get; set; }

        public GameBoardViewModel()
        {
            //saving rainbow color sequence
            ColorSequence = new Dictionary<string,int>();
            ColorSequence.Add(Colors.Red, 0);
            ColorSequence.Add(Colors.Orange, 1);
            ColorSequence.Add(Colors.Yellow, 2);
            ColorSequence.Add(Colors.Green, 3);
            ColorSequence.Add(Colors.Blue, 4);
            ColorSequence.Add(Colors.Purple, 5);

            //creating triangular structures
            Triangle = new Stone[6][];
            for (int i = 0; i < Triangle.GetLength(0); i++)
			{
			    Triangle[i] = new Stone[i+1];
			}
            TriangeDictionary = new Dictionary<string, Stone>();

            //list of colors to attribute to stones
            StoneColors = new List<string>() 
            {
                Colors.Red, Colors.Red, Colors.Red, Colors.Red, Colors.Red, Colors.Red,
                Colors.Orange, Colors.Orange, Colors.Orange, Colors.Orange, Colors.Orange,
                Colors.Yellow,  Colors.Yellow, Colors.Yellow, Colors.Yellow,
                Colors.Green, Colors.Green, Colors.Green,
                Colors.Blue, Colors.Blue,
                Colors.Purple,
            };
            
            //initializing turn panels
            LeftTurnPanel = new Stone[11, 3];
            RightTurnPanel = new Stone[11, 3];
            InitializePanel(LeftTurnPanel);
            InitializePanel(RightTurnPanel);

            SelectedStones = new List<Point>();

        }

        //initializes turn panels with empty stones
        public void InitializePanel(Stone[,] panel)
        {
            for (int i = 0; i < panel.GetLength(0); i++)
            {
                for (int j = 0; j < panel.GetLength(1); j++)
                {
                    panel[i,j] = new Stone(i, j);
                }
            }
        }

        //generates stone colors at the beginning of the game
        public void GenerateColors()
        {
            Random rnd = new Random();

            for (int i = 0; i < Triangle.GetLength(0); i++)
			{
			    for (int j = 0; j < Triangle[i].GetLength(0); j++)
			    {
			        int rand = rnd.Next(StoneColors.Count);
                    Triangle[i][j].Fill = StoneColors[rand].ColorToBrush();
                    Triangle[i][j].Visibility = System.Windows.Visibility.Visible;
                    StoneColors.RemoveAt(rand);
			    }
			}
        }

        //helper function for DetermineAvailableStones
        //sets IsAvailable to false and changes stroke to default for all stones
        private void ClearAllAvailable()
        {
            for (int i = 0; i < Triangle.GetLength(0); i++)
            {
                for (int j = 0; j < Triangle[i].GetLength(0); j++)
                {
                    Triangle[i][j].IsAvailable = false;

                    if (!Triangle[i][j].IsSelected)
                    {
                        Triangle[i][j].Stroke = Colors.Grey.ColorToBrush();
                        Triangle[i][j].StrokeThickness = 1;
                    }
                }
            }
        }





















//??????????????????
        private void MakeAvailable(Stone currentStone)
        {
            currentStone.IsAvailable = true;
            currentStone.IsSelected = false;
            ChangeStroke(currentStone, Colors.StrokeAvailable);
        }





        private void MakeSelected(Stone selectedStone)
        {
            selectedStone.IsAvailable = false;
            selectedStone.IsSelected = true;
            ChangeStroke(selectedStone, Colors.StrokeSelected);
            SelectedStones.Add(selectedStone.Location);
        }

        private void ChangeStroke(Stone selectedStone, string color, double thickness = 3.5)
        {
            selectedStone.Stroke = color.ColorToBrush();
            selectedStone.StrokeThickness = thickness;
        }





        private void AddStoneOfSameColorToAvailable(Stone selectedStone, Stone currentStone)
        {
            if (currentStone.Fill.ToString().Equals(selectedStone.Fill.ToString()))
            {
                MakeAvailable(currentStone);
            }
        }





        private bool IsANeighboringColor(Brush selectedStoneFill, Brush currentStoneFill)
        {
            bool isNeighboring = false;

            int indexDifference = ColorSequence[selectedStoneFill.ToString()] - ColorSequence[currentStoneFill.ToString()];

            if ((indexDifference == 1) || (indexDifference == -1))
            {
                isNeighboring = true;
            }

            return isNeighboring;
        }

        private bool IsOnTheSameDiagonal(Stone selectedStone, Stone currentStone)
        {
            int differenceOnSelected = selectedStone.Location.Row - selectedStone.Location.Column;
            int differenceOnCurrent = currentStone.Location.Row - currentStone.Location.Column;

            if (differenceOnSelected == differenceOnCurrent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void MakeStoneOfANeighboringColorAvailable(Stone selectedStone, Stone currentStone)
        {
            bool isNeighboring = IsANeighboringColor(selectedStone.Fill, currentStone.Fill);
            bool sameRow = currentStone.Location.Row == selectedStone.Location.Row;
            bool sameColumn = currentStone.Location.Column == selectedStone.Location.Column;
            bool sameDiagonal = IsOnTheSameDiagonal(selectedStone, currentStone);
            bool sameRowColumnOrDiagonal = sameRow || sameColumn || sameDiagonal;
            bool colorIsAlreadySelected = SelectedStones.Where(s => Triangle[s.Row][s.Column].Fill.ToString().Equals(currentStone.Fill.ToString())).Count() > 0;
            if (sameRowColumnOrDiagonal && isNeighboring && !colorIsAlreadySelected)
            {
                MakeAvailable(currentStone);
            }
        }















        public void DetermineAvailableStones()
        {
            ClearAllAvailable();

            //no stones are selected
            //makes all on board available
            if(SelectedStones.Count.Equals(0))
            {
                for (int i = 0; i < Triangle.GetLength(0); i++)
                {
                    for (int j = 0; j < Triangle[i].GetLength(0); j++)
                    {
                        MakeAvailable(Triangle[i][j]);
                    }
                }
            }





            //one stone is selected
            else if (SelectedStones.Count.Equals(1))
            {
                //takes the only stone from Selected stones
                Stone selectedStone = Triangle[SelectedStones[0].Row][SelectedStones[0].Column];

                for (int i = 0; i < Triangle.GetLength(0); i++)
                {
                    for (int j = 0; j < Triangle[i].GetLength(0); j++)
                    {
                        //stone reached in the matrix
                        Stone currentStone = Triangle[i][j];

                        //if stone reached is not selected
                        if (!currentStone.IsSelected)
                        {
                            //checks if it is of the same color as the stone in Selected stone
                            AddStoneOfSameColorToAvailable(selectedStone, currentStone);
                            MakeStoneOfANeighboringColorAvailable(selectedStone, currentStone);
                        }                      
                    }
                }
            }




            //two stones are selected
            else if (SelectedStones.Count.Equals(2))
            {
                Stone selectedStone1 = Triangle[SelectedStones[0].Row][SelectedStones[0].Column];
                Stone selectedStone2 = Triangle[SelectedStones[1].Row][SelectedStones[1].Column];

                for (int i = 0; i < Triangle.GetLength(0); i++)
                {
                    for (int j = 0; j < Triangle[i].GetLength(0); j++)
                    {
                        //stone reached in the matrix
                        Stone currentStone = Triangle[i][j];
 
                        //if the two selected stones are of the same color
                        if ((selectedStone1.Fill.ToString() == selectedStone2.Fill.ToString()) && !currentStone.IsSelected)
                        {
                            AddStoneOfSameColorToAvailable(selectedStone1, currentStone);
                        }
                        //if the two selected stones are of different colors
                        else
                        {
                            MakeStoneOfANeighboringColorAvailable(selectedStone1, currentStone);
                            MakeStoneOfANeighboringColorAvailable(selectedStone2, currentStone);
                        }
                    }
                }
            }
        }






   

        public void SelectStone(Stone selectedStone)
        {
            if (selectedStone.IsAvailable && !selectedStone.IsSelected)
            {
                MakeSelected(selectedStone);
                DetermineAvailableStones();
            }
            else if (selectedStone.IsSelected)
            {
                SelectedStones.Remove(selectedStone.Location);
                MakeAvailable(selectedStone);
                DetermineAvailableStones();
            }

        }

 






        //public void MakeTriangleVisible()
        //{
        //    for (int i = 0; i < Triangle.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < Triangle[i].GetLength(0); j++)
        //        {
        //            Triangle[i][j].Visibility = System.Windows.Visibility.Visible;
        //        }
        //    }
        //}

    }
}
