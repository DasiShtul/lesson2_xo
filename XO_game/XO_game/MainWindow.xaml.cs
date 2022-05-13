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

namespace XO_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 0;
        private string[,] Game = new string[3,3];
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Grid_Click(object sender, RoutedEventArgs e)
        {
           Button b = e.OriginalSource as Button;

            if ((string)b.Content == "?")
            if (count % 2 == 0)
                print("X",b,2 );
            else
               print("O", b,1);

        }

        private void print(string i,Button b,int num)
        {
            b.Content = i;

            if (isFinish(i, b))
                MessageBox.Show("ניצחון ל" + my_name.Content);
            else
            {
                count++;
                my_name.Content = "שחקן " + num;
            }
        }

        private bool isFinish(string i, Button b)
        {
            int r_count = 0, c_count = 0,d_count1=0,d_count2=0;
            int row = (int)b.GetValue(Grid.RowProperty);
            int col = (int)b.GetValue(Grid.ColumnProperty);
            Game[row, col] = i;
            for (int x = 0; x < 3; x++)
            {
                if (Game[row, x] == i)
                    r_count++;
                if (Game[x, col] == i)
                    c_count++;
                if (Game[x, x] == i)
                    d_count1++;
                if (Game[x, Game.GetLength(0)-1 - x] == i)
                    d_count2++;
            }
            if (c_count == 3 || r_count == 3|| d_count1 == 3 || d_count2 == 3)
                return true;
            return false;
        }
    }
}
