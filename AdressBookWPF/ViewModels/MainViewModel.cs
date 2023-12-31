using SharedCode.Models;
using SharedCode;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace AddressBookWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IContactRepository _contactRepository;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _address;

        public ICommand AddContactCommand { get; }

        public ObservableCollection<Contact> Contacts { get; set; }

        public MainViewModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            Contacts = new ObservableCollection<Contact>(_contactRepository.GetAllContacts());
            AddContactCommand = new RelayCommand(AddContactExecute);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddContactExecute(object obj)
        {
            Contact newContact = new Contact
            {
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email,
                PhoneNumber = _phoneNumber,
                Address = _address
            };
            _contactRepository.AddContact(newContact);
            Contacts.Add(newContact);
            FirstName = LastName = Email = PhoneNumber = Address = string.Empty;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}