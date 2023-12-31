using AddressBookWPF.ViewModels;
using SharedCode;
using System.Windows;

namespace AddressBookWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string jsonFilePath = @"C:\Projects\contacts.json";
            IFileService fileService = new FileService(jsonFilePath);
            IContactRepository contactRepository = new ContactRepository(fileService);
            DataContext = new MainViewModel(contactRepository);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}