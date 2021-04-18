using ChessSimulator.Enums;
using ChessSimulator.Extensions;
using ChessSimulator.Gameboards;
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
        private ClickState clickState;
        private SolidColorBrush player1Brush = new SolidColorBrush();
        private SolidColorBrush player2Brush = new SolidColorBrush();

        public MainWindow()
        {
            InitializeComponent();
            player1Brush.Color = Colors.Red;
            player2Brush.Color = Colors.Black;
            gameBoard = GameBoard.GenerateStandardBoard();
            RefreshBoard();
        }

        private void RefreshBoard()
        {
            foreach (var boardStateInfo in gameBoard.GetBoard())
            {
                var currentButton = GetButton(boardStateInfo.Position);

                if (boardStateInfo.State == Colour.White)
                {
                    currentButton.Foreground = player1Brush;
                }
                else if (boardStateInfo.State == Colour.Black)
                {
                    currentButton.Foreground = player2Brush;
                }

                currentButton.Content = boardStateInfo.Representation;
            }
        }

        private Button GetButton(Position position)
        {
            return (Button)field.Children.Cast<UIElement>()
                .First(element => 
                    Grid.GetRow(element) == position.Y + 1 
                    && 
                    Grid.GetColumn(element) == position.X + 1);
        }

        private void Move(Position position)
        {
            if (clickState is null)
            {
                clickState = new ClickState { ClickPosition = position };
                var moves = gameBoard.GetMoves(position).ToList();
                foreach (var move in moves)
                {
                    // TODO make possible moves visible on the board.
                }
            }
            else
            {
                var moveResult = gameBoard.Move(clickState.ClickPosition, position);
                if (moveResult == MoveResult.SetMySelfToCheck) 
                {
                    MessageBox.Show("Invalid move: Set own King to check");                        
                }
                clickState = null;
                RefreshBoard();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Move((sender as Button).Name.Parse());
        }
    }
}
