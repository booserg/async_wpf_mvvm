using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
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

            Submit = new AsyncCommand(async () =>
            {
                MyBackground = new SolidColorBrush(Colors.LightGray);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyBackground"));

                Console.WriteLine("before async thread id: " + Thread.CurrentThread.ManagedThreadId);

                var task = new Task<int>(() =>
                {
                    Console.WriteLine("inside async thread id: " + Thread.CurrentThread.ManagedThreadId);
                    return model.DoWork();
                });

                task.Start();

                var res = await task;

                Console.WriteLine("after async thread id: " + Thread.CurrentThread.ManagedThreadId);

                MyProp = model.WorkResult;

                MyBackground = new SolidColorBrush(Colors.Transparent);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyProp"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyBackground"));
            });
        }
    }
}
