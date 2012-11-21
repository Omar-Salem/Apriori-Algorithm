using System.Windows;
using AprioriAlgorithm;

namespace WPFClient
{
    public partial class Result : Window
    {
        public Result(Output output)
        {
            InitializeComponent();
            this.DataContext = output;
        }
    }
}
