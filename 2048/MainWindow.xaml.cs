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
        public Image[,] numbers;
        private bool isPressed = false;

        public MainWindow()
        {
            InitializeComponent();
            AllBitmapImages.IntializeImages();
            numbers = new Image[4, 4] { { Place_0_0, Place_0_1, Place_0_2, Place_0_3 }, { Place_1_0, Place_1_1, Place_1_2, Place_1_3 }, { Place_2_0, Place_2_1, Place_2_2, Place_2_3 }, { Place_3_0, Place_3_1, Place_3_2, Place_3_3 } };
            AddRandom2Place();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left && !isPressed)
            {
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
                                numbers[i, j].Source = OneNumberHigher(numbers[i,j].Source);
                                //iScore += iBoard[i][j];
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
            }

        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                isPressed = false;
        }
        //Zoek een random plek en returned een Tuple
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
        //dode code voor de button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Place_0_0.Source = AllBitmapImages.firstPic;
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

    }
}
