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
        public int[,] numbers;
        public MainWindow()
        {
            numbers = new int[3, 3];
            InitializeComponent();
            //Place_0_0.Source = new BitmapImage(new Uri(@"2048/tail.png", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Place_0_0.Source = AllBitmapImages.firstPic;
            
        }
        private Tuple<int, int> GetRandomPlace()
        {
            Random rand = new Random();
            rand.Next(0, 3);
        }
    }
}
