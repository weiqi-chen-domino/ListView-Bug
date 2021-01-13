using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Binding : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private int num = 0;
        public int Num 
        { get=>num;
            set {
                num = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NextListViewItem"));
            }
        } 
        public ObservableCollection<string> Datas { get; } = new ObservableCollection<string>();
        public string NextListViewItem => string.Format("{0,10:D16}", Num);   
    }

    public partial class MainWindow : Window
    {
        int num = 0;
        Binding binding = new Binding();
        ListViewWindow listViewWindow = new ListViewWindow();
        
        public MainWindow()
        {
            InitializeComponent();
            listViewWindow.DataContext = binding;
            this.DataContext = binding;
            binding.Datas.CollectionChanged += listViewWindow.ListViewWindow_CollectionChanged;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            binding.Datas.Add(binding.NextListViewItem);
            binding.Num += 1;
        }
    }
}
