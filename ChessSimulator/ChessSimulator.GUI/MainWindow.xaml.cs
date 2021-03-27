using ChessSimulator.Extensions;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChessSimulator.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGameBoard gameBoard;
        private Position marked;
        private ClickState clickState;

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

        private Button GetButton(Position position)
        {
            return (Button)field.Children.Cast<UIElement>()
                        .First(e => Grid.GetRow(e) == position.Y + 1 && Grid.GetColumn(e) == position.X + 1);
        }

        private void Move(Position position) 
        {
            if (clickState is null)
            {

                clickState = new ClickState { ClickPosition = position };
                var moves = gameBoard.GetMoves(position).ToList();
                foreach (var move in moves)
                {
                  //  GetButton(move).Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffaacc"));
                }
            }
            else
            {
                gameBoard.Move(clickState.ClickPosition, position);
                clickState = null;
                RefreshBoard();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Move((sender as Button).Name.Parse());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Move((sender as Button).Name.Parse());
        }
    }
}
