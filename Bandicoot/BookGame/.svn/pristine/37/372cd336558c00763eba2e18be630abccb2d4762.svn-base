using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookGame.ViewModels;

namespace BookGame
{
    public partial class GameBoardView : UserControl
    {
        public GameBoardViewModel GameBoardViewModel { get; set; }

        public GameBoardView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            GameBoardViewModel = new GameBoardViewModel();
            
            InitializeTriangle();
            BindStonesToEllipsesInTriangle();

            BindStonesToEllipsesInLeftTurnPanel();
            BindStonesToEllipsesInRightTurnPanel();

            GameBoardViewModel.GenerateColors();
            GameBoardViewModel.DetermineAvailableStones();
        }

        private void BindStonesToEllipsesInLeftTurnPanel()
        {
            e211.DataContext = GameBoardViewModel.LeftTurnPanel[0, 0];
            e212.DataContext = GameBoardViewModel.LeftTurnPanel[0, 1];
            e213.DataContext = GameBoardViewModel.LeftTurnPanel[0, 2];

            e221.DataContext = GameBoardViewModel.LeftTurnPanel[1, 0];
            e222.DataContext = GameBoardViewModel.LeftTurnPanel[1, 1];
            e223.DataContext = GameBoardViewModel.LeftTurnPanel[1, 2];

            e231.DataContext = GameBoardViewModel.LeftTurnPanel[2, 0];
            e232.DataContext = GameBoardViewModel.LeftTurnPanel[2, 1];
            e233.DataContext = GameBoardViewModel.LeftTurnPanel[2, 2];

            e241.DataContext = GameBoardViewModel.LeftTurnPanel[3, 0];
            e242.DataContext = GameBoardViewModel.LeftTurnPanel[3, 1];
            e243.DataContext = GameBoardViewModel.LeftTurnPanel[3, 2];

            e251.DataContext = GameBoardViewModel.LeftTurnPanel[4, 0];
            e252.DataContext = GameBoardViewModel.LeftTurnPanel[4, 1];
            e253.DataContext = GameBoardViewModel.LeftTurnPanel[4, 2];

            e261.DataContext = GameBoardViewModel.LeftTurnPanel[5, 0];
            e262.DataContext = GameBoardViewModel.LeftTurnPanel[5, 1];
            e263.DataContext = GameBoardViewModel.LeftTurnPanel[5, 2];

            e271.DataContext = GameBoardViewModel.LeftTurnPanel[6, 0];
            e272.DataContext = GameBoardViewModel.LeftTurnPanel[6, 1];
            e273.DataContext = GameBoardViewModel.LeftTurnPanel[6, 2];

            e281.DataContext = GameBoardViewModel.LeftTurnPanel[7, 0];
            e282.DataContext = GameBoardViewModel.LeftTurnPanel[7, 1];
            e283.DataContext = GameBoardViewModel.LeftTurnPanel[7, 2];

            e291.DataContext = GameBoardViewModel.LeftTurnPanel[8, 0];
            e292.DataContext = GameBoardViewModel.LeftTurnPanel[8, 1];
            e293.DataContext = GameBoardViewModel.LeftTurnPanel[8, 2];

            e2101.DataContext = GameBoardViewModel.LeftTurnPanel[9, 0];
            e2102.DataContext = GameBoardViewModel.LeftTurnPanel[9, 1];
            e2103.DataContext = GameBoardViewModel.LeftTurnPanel[9, 2];

            e2111.DataContext = GameBoardViewModel.LeftTurnPanel[10, 0];
            e2112.DataContext = GameBoardViewModel.LeftTurnPanel[10, 1];
            e2113.DataContext = GameBoardViewModel.LeftTurnPanel[10, 2];
        }

        private void BindStonesToEllipsesInRightTurnPanel()
        {
            e111.DataContext = GameBoardViewModel.LeftTurnPanel[0, 0];
            e112.DataContext = GameBoardViewModel.LeftTurnPanel[0, 1];
            e113.DataContext = GameBoardViewModel.LeftTurnPanel[0, 2];

            e121.DataContext = GameBoardViewModel.LeftTurnPanel[1, 0];
            e122.DataContext = GameBoardViewModel.LeftTurnPanel[1, 1];
            e123.DataContext = GameBoardViewModel.LeftTurnPanel[1, 2];

            e131.DataContext = GameBoardViewModel.LeftTurnPanel[2, 0];
            e132.DataContext = GameBoardViewModel.LeftTurnPanel[2, 1];
            e133.DataContext = GameBoardViewModel.LeftTurnPanel[2, 2];

            e141.DataContext = GameBoardViewModel.LeftTurnPanel[3, 0];
            e142.DataContext = GameBoardViewModel.LeftTurnPanel[3, 1];
            e143.DataContext = GameBoardViewModel.LeftTurnPanel[3, 2];

            e151.DataContext = GameBoardViewModel.LeftTurnPanel[4, 0];
            e152.DataContext = GameBoardViewModel.LeftTurnPanel[4, 1];
            e153.DataContext = GameBoardViewModel.LeftTurnPanel[4, 2];

            e161.DataContext = GameBoardViewModel.LeftTurnPanel[5, 0];
            e162.DataContext = GameBoardViewModel.LeftTurnPanel[5, 1];
            e163.DataContext = GameBoardViewModel.LeftTurnPanel[5, 2];

            e171.DataContext = GameBoardViewModel.LeftTurnPanel[6, 0];
            e172.DataContext = GameBoardViewModel.LeftTurnPanel[6, 1];
            e173.DataContext = GameBoardViewModel.LeftTurnPanel[6, 2];

            e181.DataContext = GameBoardViewModel.LeftTurnPanel[7, 0];
            e182.DataContext = GameBoardViewModel.LeftTurnPanel[7, 1];
            e183.DataContext = GameBoardViewModel.LeftTurnPanel[7, 2];

            e191.DataContext = GameBoardViewModel.LeftTurnPanel[8, 0];
            e192.DataContext = GameBoardViewModel.LeftTurnPanel[8, 1];
            e193.DataContext = GameBoardViewModel.LeftTurnPanel[8, 2];

            e1101.DataContext = GameBoardViewModel.LeftTurnPanel[9, 0];
            e1102.DataContext = GameBoardViewModel.LeftTurnPanel[9, 1];
            e1103.DataContext = GameBoardViewModel.LeftTurnPanel[9, 2];

            e1111.DataContext = GameBoardViewModel.LeftTurnPanel[10, 0];
            e1112.DataContext = GameBoardViewModel.LeftTurnPanel[10, 1];
            e1113.DataContext = GameBoardViewModel.LeftTurnPanel[10, 2];
        }

        private void BindStonesToEllipsesInTriangle()
        {
            e11.DataContext = GameBoardViewModel.Triangle[0][0];
            GameBoardViewModel.TriangeDictionary.Add(e11.Name, GameBoardViewModel.Triangle[0][0]);

            e21.DataContext = GameBoardViewModel.Triangle[1][0];
            e22.DataContext = GameBoardViewModel.Triangle[1][1];
            GameBoardViewModel.TriangeDictionary.Add(e21.Name, GameBoardViewModel.Triangle[1][0]);
            GameBoardViewModel.TriangeDictionary.Add(e22.Name, GameBoardViewModel.Triangle[1][1]);

            e31.DataContext = GameBoardViewModel.Triangle[2][0];
            e32.DataContext = GameBoardViewModel.Triangle[2][1];
            e33.DataContext = GameBoardViewModel.Triangle[2][2];
            GameBoardViewModel.TriangeDictionary.Add(e31.Name, GameBoardViewModel.Triangle[2][0]);
            GameBoardViewModel.TriangeDictionary.Add(e32.Name, GameBoardViewModel.Triangle[2][1]);
            GameBoardViewModel.TriangeDictionary.Add(e33.Name, GameBoardViewModel.Triangle[2][2]);

            e41.DataContext = GameBoardViewModel.Triangle[3][0];
            e42.DataContext = GameBoardViewModel.Triangle[3][1];
            e43.DataContext = GameBoardViewModel.Triangle[3][2];
            e44.DataContext = GameBoardViewModel.Triangle[3][3];
            GameBoardViewModel.TriangeDictionary.Add(e41.Name, GameBoardViewModel.Triangle[3][0]);
            GameBoardViewModel.TriangeDictionary.Add(e42.Name, GameBoardViewModel.Triangle[3][1]);
            GameBoardViewModel.TriangeDictionary.Add(e43.Name, GameBoardViewModel.Triangle[3][2]);
            GameBoardViewModel.TriangeDictionary.Add(e44.Name, GameBoardViewModel.Triangle[3][3]);

            e51.DataContext = GameBoardViewModel.Triangle[4][0];
            e52.DataContext = GameBoardViewModel.Triangle[4][1];
            e53.DataContext = GameBoardViewModel.Triangle[4][2];
            e54.DataContext = GameBoardViewModel.Triangle[4][3];
            e55.DataContext = GameBoardViewModel.Triangle[4][4];
            GameBoardViewModel.TriangeDictionary.Add(e51.Name, GameBoardViewModel.Triangle[4][0]);
            GameBoardViewModel.TriangeDictionary.Add(e52.Name, GameBoardViewModel.Triangle[4][1]);
            GameBoardViewModel.TriangeDictionary.Add(e53.Name, GameBoardViewModel.Triangle[4][2]);
            GameBoardViewModel.TriangeDictionary.Add(e54.Name, GameBoardViewModel.Triangle[4][3]);
            GameBoardViewModel.TriangeDictionary.Add(e55.Name, GameBoardViewModel.Triangle[4][4]);

            e61.DataContext = GameBoardViewModel.Triangle[5][0];
            e62.DataContext = GameBoardViewModel.Triangle[5][1];
            e63.DataContext = GameBoardViewModel.Triangle[5][2];
            e64.DataContext = GameBoardViewModel.Triangle[5][3];
            e65.DataContext = GameBoardViewModel.Triangle[5][4];
            e66.DataContext = GameBoardViewModel.Triangle[5][5];
            GameBoardViewModel.TriangeDictionary.Add(e61.Name, GameBoardViewModel.Triangle[5][0]);
            GameBoardViewModel.TriangeDictionary.Add(e62.Name, GameBoardViewModel.Triangle[5][1]);
            GameBoardViewModel.TriangeDictionary.Add(e63.Name, GameBoardViewModel.Triangle[5][2]);
            GameBoardViewModel.TriangeDictionary.Add(e64.Name, GameBoardViewModel.Triangle[5][3]);
            GameBoardViewModel.TriangeDictionary.Add(e65.Name, GameBoardViewModel.Triangle[5][4]);
            GameBoardViewModel.TriangeDictionary.Add(e66.Name, GameBoardViewModel.Triangle[5][5]);
        }

        private void InitializeTriangle()
        {
            for (int i = 0; i < GameBoardViewModel.Triangle.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoardViewModel.Triangle[i].GetLength(0); j++)
                {
                    GameBoardViewModel.Triangle[i][j] = new Stone(i, j);
                }
            }
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse selectedEllipse = sender as Ellipse;
            Stone selectedStone = GameBoardViewModel.TriangeDictionary[selectedEllipse.Name];
            GameBoardViewModel.SelectStone(selectedStone);
            //GameBoardViewModel.Triangle[0][0].IsSelected = true;
            //GameBoardViewModel.Triangle[0][0].Stroke = Colors.Blue.ColorToBrush();
            //GameBoardViewModel.DetermineAvailableStones();
        }
    }
}
