using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using FooWpf.Model;

namespace FooWpf.ViewModel;

public class ViewModelMain : INotifyPropertyChanged
{

    // this is one per app! stick it here for the mo.
    private readonly HttpClient client = new();

    private RelayCommand<Window>? uICommand;

    private string textEntry = string.Empty;
    private string textResult = string.Empty;
    private List<Product> products = new List<Product>();

    public ViewModelMain() 
    {
        products.Add(new Product { ProductName = "The quick brown fox jumps over the lazy dog."});
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string info)
    {
        PropertyChangedEventHandler? handler = PropertyChanged;
        try
        {
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} {1}", new string[] { nameof(OnPropertyChanged), ex.Message });
        }
    }
    public RelayCommand<Window> UICommand => uICommand ?? (uICommand = new RelayCommand<Window>(
               async x =>
               {
                   //await Task.FromResult(0);
                   // var result = await Fetcher.Fetch(client, "https://mdn.github.io/learning-area/javascript/apis/fetching-data/can-store/products.json");
                   //if (string.IsNullOrWhiteSpace(textEntry))
                   //{
                   //    await Task.FromResult(0);
                   //}
                   //else
                   {
                       // set the bound property
                       TextResult = await Fetcher.Fetch(client, textEntry);
                       // have a look at local
                       Console.WriteLine(textResult);

                       products = await Fetcher.FetchTyped(client, "");
                       OnPropertyChanged("Products");
                   }
               }));

    public string TextEntry
    {
        get
        {
            return textEntry;
        }
        set
        {
            textEntry = value;
            OnPropertyChanged("TextEntry");
        }
    }
    public string TextResult
    {
        get
        {
            return textResult;
        }
        set
        {
            textResult = value;
            OnPropertyChanged("TextResult");
        }
    }
    public List<Product> Products
    {
        get
        {
            return products;
        }
        set
        {
            OnPropertyChanged("Products");
        }
    }


}
