using System.Windows;
using AprioriAlgorithm;
using System.ComponentModel.Composition;

namespace WPFClient
{
    [Export(typeof(IResult))]
    public partial class Result : Window, IResult
    {
        public Result()
        {
            InitializeComponent();
        }

        public void Show(Output output)
        {
            this.DataContext = output;
            this.ShowDialog();
        }
    }
}