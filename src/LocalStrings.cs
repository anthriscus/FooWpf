using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Windows.Controls;
using System.Windows.Data;
namespace FooWpf;

public class LocalStrings
{
    private readonly Dictionary<string, string> _resource;
    public LocalStrings() =>    
        _resource = new Dictionary<string, string>() { { "foo", "baa" },
                        { "ProductName","Product foo Name"},
                        { "Price","Price"}, 
                        { "Image","Image File"},
                        { "ProductType","Product Type"}};    

    public String this[String index]
    {
        get
        {
            String s = "";
            if (_resource.TryGetValue(index, out string? value))
                return value;
           
            return string.Empty;
        }
    }

}
