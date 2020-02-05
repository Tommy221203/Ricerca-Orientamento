using System;
using System.Collections.Generic;
using System.IO;
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

namespace Ricerca_Orientamento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const string filetesto = "file.txt";
        public MainWindow()
            
        {
            InitializeComponent();
            StreamReader r = new StreamReader(filetesto);
            string line;
            while((line =r.ReadLine())!=null)
            {
                nomistudenti.Add(line);
            }
            OrdinaEVisualizza();
        }
        List<string> nomistudenti = new List<string>();

        private void btnaggiungi_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtstudente.Text;
            nomistudenti.Add(nome);
            txtstudente.Clear();
            txtstudente.Focus();
            nomistudenti.Sort();

        }

        private void visualizza_Click(object sender, RoutedEventArgs e)
        {
            OrdinaEVisualizza();
        }

        private void OrdinaEVisualizza()
        {
            nomistudenti.Sort();
            foreach (var name in nomistudenti)
                lblresult.Content += ($"{name} \n");
        }

        private void salva_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter w = new StreamWriter(filetesto,true);
            nomistudenti.Sort();
            foreach (var name in nomistudenti)
            {
                w.WriteLine($"{name}");
            }
            w.Close();
            lblresult.Content = "";
           
        }

        private void btnpulici_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(filetesto);
            File.Create(filetesto);
        }
    }
}
