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
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sliRGB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value)));

            PirosErtek.Content = (byte)sliPiros.Value;
            ZoldErtek.Content = (byte)sliZold.Value;
            KekErtek.Content = (byte)sliKek.Value;

        }

        private void btnRögzít_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.Items.Contains(Convert.ToByte(sliPiros.Value) + ";" + Convert.ToByte(sliZold.Value) + ";" + Convert.ToByte(sliKek.Value)))
            {
                MessageBox.Show("Ez már szerepel :c");
            }
            else
            {
                lbSzinek.Items.Add(Convert.ToByte(sliPiros.Value) + ";" + Convert.ToByte(sliZold.Value) + ";" + Convert.ToByte(sliKek.Value));
            }
        }

        private void btnTöröl_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs kiválasztva semmi :c");
            }
            else
            {
                lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
            }
        }

        private void btnÜrítés_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.Items.Count == 0)
            {
                MessageBox.Show("Már üres :c");
            }
            else
            {
                lbSzinek.Items.Clear();
            }
        }



        private void lbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string[] szinek = lbSzinek.SelectedItem.ToString().Split(";");
            sliPiros.Value = Convert.ToDouble(szinek[0]);
            sliZold.Value = Convert.ToDouble(szinek[1]);
            sliKek.Value= Convert.ToDouble( szinek[2]); 
        }


        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            //string[] mentes = File.ReadAllLines(lbSzinek.ToString()); /*meg nincs kesz*/
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            //string[] mentes = File.ReadAllLines(lbSzinek.ToString()); /*meg nincs kesz*/
        }
    }
}
