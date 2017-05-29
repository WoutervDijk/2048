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
        public MainWindow()
        {
            IntializeArray();
            InitializeComponent();
            //Place_0_0.Source = new BitmapImage(new Uri(@"2048/tail.png", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Place_0_0.Source = AllBitmapImages.firstPic;
            var x = GetRandomPlace();
            numbers[x.Item1, x.Item2].Source = AllBitmapImages.firstPic;
        }
        private Tuple<int, int> GetRandomPlace()
        {
            Random rand = new Random();
            
            int a = rand.Next(0, 3);
            int b = rand.Next(0, 3);
            var tuble = new Tuple<int, int>(a, b);
            return tuble;
        }
        private void IntializeArray()
        {
            numbers = new Image[3, 3];
            numbers[0, 0] = Place_0_0;
            numbers[0, 1] = Place_0_1;
            numbers[0, 2] = Place_0_2;
            numbers[0, 3] = Place_0_3;
            numbers[1, 0] = Place_1_0;
            numbers[1, 1] = Place_1_1;
            numbers[1, 2] = Place_1_2;
            numbers[1, 3] = Place_1_3;
            numbers[2, 0] = Place_2_0;
            numbers[2, 1] = Place_2_1;
            numbers[2, 2] = Place_2_2;
            numbers[2, 3] = Place_2_3;
            numbers[3, 0] = Place_3_0;
            numbers[3, 1] = Place_3_1;
            numbers[3, 2] = Place_3_2;
            numbers[3, 3] = Place_3_3;
        }
    }
}
