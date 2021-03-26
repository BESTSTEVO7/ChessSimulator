using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ChessSimulator.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGameBoard gameBoard;

        public MainWindow()
        {
            InitializeComponent();
            gameBoard = GameBoard.GenerateStandardBoard();
            RefreshBoard();
        }

        private void RefreshBoard()
        {
            foreach (var boardStateInfo in gameBoard.GetBoard())
            {
                var currentButton = ((System.Windows.Controls.Button)field.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == boardStateInfo.Position.Y + 1 && Grid.GetColumn(e) == boardStateInfo.Position.X + 1));
                //bla.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffaacc"));
                currentButton.Content = boardStateInfo.Representation;
                //boardStateInfo[0]
            }
        }
    }
}
