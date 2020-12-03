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

namespace SalaryCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            Exception exp = new Exception();
            try
            {
                double oklad = double.Parse(TBoklad.Text);
                double premia = double.Parse(TBpremia.Text);
                double rKoeff = double.Parse(TBrKoeff.Text);
                int rDays = int.Parse(TBrDays.Text);
                int otrDays = int.Parse(TBotrDays.Text);

                if (rDays <= 0 || otrDays < 0) throw exp;

                double ZPfull = oklad * rKoeff * otrDays / rDays + premia;
                double ndfl = ZPfull * 0.13;
                double ZP = ZPfull - ndfl;

                out1.Content = "Полная ЗП - " + ZPfull.ToString();
                out2.Content = "НДФЛ - " + ndfl.ToString();
                out3.Content = "ЗП на руки - " + ZP.ToString();

                out1.Visibility = out2.Visibility = out3.Visibility = Visibility.Visible;
                
            }
            catch (Exception)
            {
                out1.Content = "Неверные данные";
                out1.Visibility = Visibility.Visible;
                out2.Visibility = out3.Visibility = Visibility.Hidden;
            }
        }
    }
}
