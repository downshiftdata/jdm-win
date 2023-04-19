namespace jdm_d35e
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private Models.File _ActiveFile = Handlers.FileHandler.GetNew();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var confirm = !_ActiveFile.IsDirty;
            if (!confirm)
            {
                var result = System.Windows.MessageBox.Show(
                    "Current game is not saved. Are you sure?",
                    base.Title,
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Warning,
                    System.Windows.MessageBoxResult.No);
                confirm = result == System.Windows.MessageBoxResult.Yes;
            }
            if (confirm) _ActiveFile = Handlers.FileHandler.GetNew();
        }

        private void FileOpen_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".jdm";
            dialog.Filter = "Games (*.jdm)|*.jdm";
            var result = dialog.ShowDialog();
            if (result == true)
            {
                _ActiveFile = Handlers.FileHandler.Load(dialog.FileName);
            }
        }

        private void FileSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_ActiveFile.Path == null) FileSaveAs_Click(sender, e);
            else Handlers.FileHandler.Save(_ActiveFile);
        }

        private void FileSaveAs_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.DefaultExt = ".jdm";
            dialog.Filter = "Games (*.jdm)|*.jdm";
            var result = dialog.ShowDialog();
            if (result == true)
            {
                Handlers.FileHandler.SaveAs(_ActiveFile, dialog.FileName);
            }
        }
    }
}
