﻿using SharedCode;
using AddressBookConsole.Services;

class Program
{
    static void Main(string[] args)
    {
        
        string filePath = @"C:\Contacts\Contacts.json";

        
        SharedCode.IServiceProvider serviceProvider = new SharedCode.ServiceProvider(new FileService(filePath));

        
        IContactRepository contactRepository = serviceProvider.GetContactRepository();

       
        MenuService menuService = new MenuService(contactRepository);

     
        menuService.ShowMainMenu();
    }
}