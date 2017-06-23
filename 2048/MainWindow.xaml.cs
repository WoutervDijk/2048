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

namespace _2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentScore;
        public Image[,] numbers;
        private bool isPressed = false;
        public bool gameOver;
        //Standaard dingen die moeten gedaan worden als het spel opstart. Zoals het spelbord maken etc.
        public MainWindow()
        {
            InitializeComponent();
            AllBitmapImages.IntializeImages();
            numbers = new Image[4, 4] { { Place_0_0, Place_0_1, Place_0_2, Place_0_3 }, { Place_1_0, Place_1_1, Place_1_2, Place_1_3 }, { Place_2_0, Place_2_1, Place_2_2, Place_2_3 }, { Place_3_0, Place_3_1, Place_3_2, Place_3_3 } };
            AddRandom2Place();
            gameOver = false;
            currentScore = 0;
            UpdateScore();
        }
        //Als een knop ingedrukt wordt, moet heel het veld veranderen. Hier zijn for loops voor gebruikt, zodat je een stuk minder code hoeft te gebruiken en het makkelijker te lezen is. 
        //Tevens staan er nog wat extra dingen bij om te controleren of er iets in het spel is veranderd en of je bijvoorbeeld af bent.
        //Elke richting is bijna hetzelfde qua code alleen de richting is natuurlijk anders.
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && !isPressed && !gameOver)
            {
                ImageSource[,] currentGameState = new ImageSource[4, 4];
                CopyArraySource(numbers, currentGameState);
                isPressed = true;
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int k = i + 1; k < 4; k++)
                        {
                            if (numbers[k, j].Source == null)
                            {
                                continue;
                            }
                            else if (numbers[k, j].Source == numbers[i, j].Source)
                            {
                                numbers[i, j].Source = OneNumberHigher(numbers[i, j].Source);
                                currentScore += CalculateNewScore(numbers[i, j].Source);
                                numbers[k, j].Source = null;
                                UpdateScore();
                                //bAdd = true;
                                break;
                            }
                            else
                            {
                                if (numbers[i, j].Source == null && numbers[k, j].Source != null)
                                {
                                    numbers[i, j].Source = numbers[k, j].Source;
                                    numbers[k, j].Source = null;
                                    i--;
                                    //bAdd = true;
                                    break;
                                }
                                else if (numbers[i, j].Source != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                if (CheckIfGameChanges(numbers, currentGameState))
                {
                    AddRandom2Place();
                }
                if(IsGameOver(numbers))
                {
                    gameOver = true;
                    MessageBox.Show("Aah dat is spijtig je hebt verloren, je totale score was: " + currentScore.ToString() + ". Als je op de restart knopt klikt kan je nog een keer spelen!", "Noob");
                }
            }
            if (e.Key == Key.Right && !isPressed && !gameOver)
            {
                ImageSource[,] currentGameState = new ImageSource[4, 4];
                CopyArraySource(numbers, currentGameState);
                isPressed = true;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 3; j >= 0; j--)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (numbers[i, k].Source == null)
                            {
                                continue;
                            }
                            else if (numbers[i, k].Source == numbers[i, j].Source)
                            {
                                numbers[i, j].Source = OneNumberHigher(numbers[i, j].Source);
                                currentScore += CalculateNewScore(numbers[i, j].Source);
                                UpdateScore();
                                numbers[i, k].Source = null;
                                //bAdd = true;
                                break;
                            }
                            else
                            {
                                if (numbers[i, j].Source == null && numbers[i, k].Source != null)
                                {
                                    numbers[i, j].Source = numbers[i, k].Source;
                                    numbers[i, k].Source = null;
                                    j++;
                                    //bAdd = true;
                                    break;
                                }
                                else if (numbers[i, j].Source != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                if (CheckIfGameChanges(numbers, currentGameState))
                {
                    AddRandom2Place();
                }
                if (IsGameOver(numbers))
                {
                    gameOver = true;
                    MessageBox.Show("Aah dat is spijtig je hebt verloren, je totale score was: " + currentScore.ToString() + ". Als je op de restart knopt klikt kan je nog een keer spelen!", "Noob");
                }
            }
            if (e.Key == Key.Down && !isPressed && !gameOver)
            {
                ImageSource[,] currentGameState = new ImageSource[4, 4];
                CopyArraySource(numbers, currentGameState);
                isPressed = true;
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 3; i >= 0; i--)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (numbers[k, j].Source == null)
                            {
                                continue;
                            }
                            else if (numbers[k, j].Source == numbers[i, j].Source)
                            {
                                numbers[i, j].Source = OneNumberHigher(numbers[i, j].Source);
                                currentScore += CalculateNewScore(numbers[i, j].Source);
                                UpdateScore();
                                numbers[k, j].Source = null;
                                //bAdd = true;
                                break;
                            }
                            else
                            {
                                if (numbers[i, j].Source == null && numbers[k, j].Source != null)
                                {
                                    numbers[i, j].Source = numbers[k, j].Source;
                                    numbers[k, j].Source = null;
                                    i++;
                                    //bAdd = true;
                                    break;
                                }
                                else if (numbers[i, j].Source != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                if (CheckIfGameChanges(numbers, currentGameState))
                {
                    AddRandom2Place();
                }
                if (IsGameOver(numbers))
                {
                    gameOver = true;
                    MessageBox.Show("Aah dat is spijtig je hebt verloren, je totale score was: " + currentScore.ToString() + ". Als je op de restart knopt klikt kan je nog een keer spelen!", "Noob");
                }
            }
            if (e.Key == Key.Left && !isPressed && !gameOver)
            {
                ImageSource[,] currentGameState = new ImageSource[4, 4];
                CopyArraySource(numbers, currentGameState);

                isPressed = true;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (numbers[i, k].Source == null)
                            {
                                continue;
                            }
                            else if (numbers[i, k].Source == numbers[i, j].Source)
                            {
                                numbers[i, j].Source = OneNumberHigher(numbers[i, j].Source);
                                currentScore += CalculateNewScore(numbers[i,j].Source);
                                UpdateScore();
                                numbers[i, k].Source = null;
                                //bAdd = true;
                                break;
                            }
                            else
                            {
                                if (numbers[i, j].Source == null && numbers[i, k].Source != null)
                                {
                                    numbers[i, j].Source = numbers[i, k].Source;
                                    numbers[i, k].Source = null;
                                    j--;
                                    //bAdd = true;
                                    break;
                                }
                                else if (numbers[i, j].Source != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                if (CheckIfGameChanges(numbers, currentGameState))
                {
                    AddRandom2Place();
                }
                if (IsGameOver(numbers))
                {
                    gameOver = true;
                    MessageBox.Show("Aah dat is spijtig je hebt verloren, je totale score was: " + currentScore.ToString() + ". Als je op de restart knopt klikt kan je nog een keer spelen!", "Noob");
                }
            }
        }
        //Pas als de knop los gelaat wordt kan je op de volgende klikken. Anders is het mogelijk dat de code meerdere malen per seconde runt als je de pijltjes in houdt.
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                isPressed = false;
            if (e.Key == Key.Right)
                isPressed = false;
            if (e.Key == Key.Up)
                isPressed = false;
            if (e.Key == Key.Down)
                isPressed = false;
        }
        //Zoek een random plek en returned een Tuple. Deze Tuple wordt gebruikt om allebei de de getallen makkelijk te kunnen kopiëren.
        private Tuple<int, int> GetRandomPlace()
        {
            Random rand = new Random();

            int a = rand.Next(0, 4);
            int b = rand.Next(0, 4);
            var tuble = new Tuple<int, int>(a, b);
            return tuble;
        }
        //Zoekt een random ongebruikte plaats en plaats daar een 2
        private void AddRandom2Place()
        {
            bool reDoLoop;
            do
            {
                reDoLoop = false;
                var x = GetRandomPlace();
                if (numbers[x.Item1, x.Item2].Source == null)
                {
                    numbers[x.Item1, x.Item2].Source = AllBitmapImages.firstPic;
                }
                else
                    reDoLoop = true;
            } while (reDoLoop);
        }
        //Als je op de restart knop klikt, wordt heel het bord gereset en de score op 0 gezet.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            numbers[0, 0].Source = null;
            numbers[0, 1].Source = null;
            numbers[0, 2].Source = null;
            numbers[0, 3].Source = null;
            numbers[1, 0].Source = null;
            numbers[1, 1].Source = null;
            numbers[1, 2].Source = null;
            numbers[1, 3].Source = null;
            numbers[2, 0].Source = null;
            numbers[2, 1].Source = null;
            numbers[2, 2].Source = null;
            numbers[2, 3].Source = null;
            numbers[3, 0].Source = null;
            numbers[3, 1].Source = null;
            numbers[3, 2].Source = null;
            numbers[3, 3].Source = null;
            gameOver = false;
            AddRandom2Place();
            currentScore = 0;
            UpdateScore();
        }
        //returns an ImageSource die een niveau hoger is.
        private BitmapImage OneNumberHigher(ImageSource current)
        {
            if (current == AllBitmapImages.allPics[0])
                return AllBitmapImages.allPics[1];
            if (current == AllBitmapImages.allPics[1])
                return AllBitmapImages.allPics[2];
            if (current == AllBitmapImages.allPics[2])
                return AllBitmapImages.allPics[3];
            if (current == AllBitmapImages.allPics[3])
                return AllBitmapImages.allPics[4];
            if (current == AllBitmapImages.allPics[4])
                return AllBitmapImages.allPics[5];
            if (current == AllBitmapImages.allPics[5])
                return AllBitmapImages.allPics[6];
            if (current == AllBitmapImages.allPics[6])
                return AllBitmapImages.allPics[7];
            if (current == AllBitmapImages.allPics[7])
                return AllBitmapImages.allPics[8];
            if (current == AllBitmapImages.allPics[8])
                return AllBitmapImages.allPics[9];
            if (current == AllBitmapImages.allPics[9])
                return AllBitmapImages.allPics[10];
            if (current == AllBitmapImages.allPics[10])
                return AllBitmapImages.allPics[11];
            if (current == AllBitmapImages.allPics[11])
                return AllBitmapImages.allPics[12];
            else
                return AllBitmapImages.allPics[0];

        }
        //maakt een copy van het originele veld, die wordt later gebruikt om te kijken of de copy hetzelfde is als de originele bord state(dat wordt hieronder gechecked bij regel 367 - 374).
        private void CopyArraySource(Image[,] arraytoCopy, ImageSource[,] copiedArray)
        {
            copiedArray[0, 0] = arraytoCopy[0, 0].Source;
            copiedArray[0, 1] = arraytoCopy[0, 1].Source;
            copiedArray[0, 2] = arraytoCopy[0, 2].Source;
            copiedArray[0, 3] = arraytoCopy[0, 3].Source;
            copiedArray[1, 0] = arraytoCopy[1, 0].Source;
            copiedArray[1, 1] = arraytoCopy[1, 1].Source;
            copiedArray[1, 2] = arraytoCopy[1, 2].Source;
            copiedArray[1, 3] = arraytoCopy[1, 3].Source;
            copiedArray[2, 0] = arraytoCopy[2, 0].Source;
            copiedArray[2, 1] = arraytoCopy[2, 1].Source;
            copiedArray[2, 2] = arraytoCopy[2, 2].Source;
            copiedArray[2, 3] = arraytoCopy[2, 3].Source;
            copiedArray[3, 0] = arraytoCopy[3, 0].Source;
            copiedArray[3, 1] = arraytoCopy[3, 1].Source;
            copiedArray[3, 2] = arraytoCopy[3, 2].Source;
            copiedArray[3, 3] = arraytoCopy[3, 3].Source;
        }
        //Kijkt of de copy nog hetzelfde is als de current game.
        private bool CheckIfGameChanges(Image[,] current, ImageSource[,] copy)
        {
            if (numbers[0, 0].Source == copy[0, 0] && numbers[0, 1].Source == copy[0, 1] && numbers[0, 2].Source == copy[0, 2] && numbers[0, 3].Source == copy[0, 3] && numbers[1, 0].Source == copy[1, 0] && numbers[1, 1].Source == copy[1, 1] && numbers[1, 2].Source == copy[1, 2] && numbers[1, 3].Source == copy[1, 3] && numbers[2, 0].Source == copy[2, 0] && numbers[2, 1].Source == copy[2, 1] && numbers[2, 2].Source == copy[2, 2] && numbers[2, 3].Source == copy[2, 3] && numbers[3, 0].Source == copy[3, 0] && numbers[3, 1].Source == copy[3, 1] && numbers[3, 2].Source == copy[3, 2] && numbers[3, 3].Source == copy[3, 3])
            {
                return false;
            }
            return true;
        }
        //Returns de score die hoort bij een bepaalde image
        private int CalculateNewScore(ImageSource image)
        {
            if (image == AllBitmapImages.allPics[1])
                return 4;
            if (image == AllBitmapImages.allPics[2])
                return 8;
            if (image == AllBitmapImages.allPics[3])
                return 16;
            if (image == AllBitmapImages.allPics[4])
                return 32;
            if (image == AllBitmapImages.allPics[5])
                return 64;
            if (image == AllBitmapImages.allPics[6])
                return 128;
            if (image == AllBitmapImages.allPics[7])
                return 256;
            if (image == AllBitmapImages.allPics[8])
                return 512;
            if (image == AllBitmapImages.allPics[9])
                return 1024;
            if (image == AllBitmapImages.allPics[10])
                return 2048;
            if (image == AllBitmapImages.allPics[11])
                return 4096;
            if (image == AllBitmapImages.allPics[12])
                return 8192;
            return 0;
                    }
        //Controleert of het spel over is
        private bool IsGameOver(Image[,] gameBoard)
        {
            if(gameBoard[0,0].Source != null && gameBoard[0, 1].Source != null && gameBoard[0, 2].Source != null && gameBoard[0, 3].Source != null && gameBoard[1, 0].Source != null && gameBoard[1, 1].Source != null && gameBoard[1, 2].Source != null && gameBoard[1, 3].Source != null && gameBoard[2, 0].Source != null && gameBoard[2, 1].Source != null && gameBoard[2, 2].Source != null && gameBoard[2, 3].Source != null && gameBoard[3, 0].Source != null && gameBoard[3, 1].Source != null && gameBoard[3, 2].Source != null && gameBoard[3, 3].Source != null)
            {
                return true;
            }
            return false;
        }
        //Updates the score of de scorebord
        private void UpdateScore()
        {
            ScoreTextBox.Text = currentScore.ToString();
        }
    }
}
