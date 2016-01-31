using System.Windows;
using BeThe2016.Worker;

namespace BeThe2016
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btPlayer_W_Click(object sender, RoutedEventArgs e)
        {
            var manager = new Manager();
            manager.SelectPlayer_W();
        }

        private void btPlayer_Click(object sender, RoutedEventArgs e)
        {
            var manager = new Manager();
            manager.SelectPlayer();
        }

        private void btSchedule_Click(object sender, RoutedEventArgs e)
        {
            var manager = new Manager();
            manager.SelectSchedule();
        }

        private void btSituation_Click(object sender, RoutedEventArgs e)
        {
            var manager = new Manager();
            manager.SelectSituation_W();
        }

        private void btBoxScore_Click(object sender, RoutedEventArgs e)
        {
            var manager = new Manager();
            manager.SelectBoxScore_W();
        }
    }
}
