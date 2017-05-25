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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalDrawing.Visualizations.LinkedList
{
    /// <summary>
    /// Interaction logic for NodeRepresentation.xaml
    /// </summary>
    public partial class NodeRepresentation : UserControl
    {
        public CircularLinkedListNode<int> Model { get; set; }

        public NodeRepresentation(CircularLinkedListNode<int> model)
        {
            InitializeComponent();
            Model = model;
            this.DataContext = Model;
        }
    }
}
