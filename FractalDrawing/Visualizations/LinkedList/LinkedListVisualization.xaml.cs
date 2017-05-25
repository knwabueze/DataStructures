using DataStructures.Collections;
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
using System.Windows.Shapes;

namespace FractalDrawing.Visualizations.LinkedList
{
    /// <summary>
    /// Interaction logic for LinkedListVisualization.xaml
    /// </summary>
    public partial class LinkedListVisualization : Window
    {
        CircularLinkedList<int> list;
        public LinkedListVisualization()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            list = new CircularLinkedList<int>();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            list.Add(int.Parse(InsertBox.Text));
            UpdateUI();
        }

        private void UpdateUI()
        {
            this.Viz.Children.Clear();
            list.ToList().ForEach(item => this.Viz.Children.Add(new NodeRepresentation(item)));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            list.Remove(list.IndexOf(int.Parse(RemoveBox.Text)));
            UpdateUI();
        }
    }
}
