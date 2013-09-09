using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        tttBoard board;
        bool xTurn;

        public Window1()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = (MenuItem)sender;
            initBoard(Int32.Parse((mnu.Tag.ToString())));
            xTurn = true;
        }

        private void initBoard(int rank)
        {
            Button newButton;
            board = new tttBoard(rank);
            boardGrid.Children.Clear();
            boardGrid.Rows = rank;
            for (int i=0; i<rank; i++)
                for (int j=0; j<rank; j++)
                {
                    newButton = new Button();
                    newButton.Tag = new Point(i,j);
                    newButton.Content = newButton.Tag;
                    boardGrid.Children.Add(newButton);
                }
        }

        private void boardGrid_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.OriginalSource as Button;
            if (b == null) return;  // reject if not a Button
            
            Point p = new Point();
            p = (Point)b.Tag;       // grab Button index from Tag

            if (xTurn)      // handle play for x
            {
                b.Content = "X";
                board[(int)p.X, (int)p.Y] = tictactoe.tttBoard.boardState.x;
            }
            else
            {
                b.Content = "O";
                board[(int)p.X, (int)p.Y] = tttBoard.boardState.o;
            }
            b.IsEnabled = false;
            tttBoard.boardState result = board.testWin();
            if (result == tttBoard.boardState.x)
                MessageBox.Show("X Wins!");
            if (result == tttBoard.boardState.o)
                MessageBox.Show("O Wins!");
            xTurn = !xTurn;

        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }   // end class 
}
