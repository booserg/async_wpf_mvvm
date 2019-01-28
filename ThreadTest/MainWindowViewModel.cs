using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ThreadTest
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private Model model;

        public IAsyncCommand Submit { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public int MyProp { get; set; }

        public SolidColorBrush MyBackground { get; set; }

        public MainWindowViewModel()
        {
            model = new Model();

            Submit = new AsyncCommand(ExecuteSubmitAsync);
        }

        private async Task ExecuteSubmitAsync()
        {
            MyBackground = new SolidColorBrush(Colors.LightGray);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyBackground"));

            var res = await Task<int>.Run(() => { return model.DoWork(); });

            MyProp = res;

            MyBackground = new SolidColorBrush(Colors.Transparent);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyProp"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyBackground"));
        }
    }
}
