using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace FooWpf.Model
{
    public class Product : UserControl, INotifyPropertyChanged
    {
        public static DependencyProperty ProductNameProperty = Register<string>("Name");
        public static DependencyProperty PriceProperty = Register<string>("Price");
        public static DependencyProperty ImageProperty = Register<string>("Image");
        public static DependencyProperty ProductTypeProperty = Register<string>("ProductType");

        private static DependencyProperty Register<T>(string name) 
        {
            // they are all going to be set on the product and have null property meta data.
            return DependencyProperty.Register(name, typeof(T), typeof(Product), new PropertyMetadata(null));
        }

        [System.ComponentModel.Bindable(true)]
        public Object ProductName
        {
            get
            {
                return (GetValue(ProductNameProperty));
            }
            set
            {
                SetValue(ProductNameProperty, value);
            }
        }
        [System.ComponentModel.Bindable(true)]
        public Object Price
        {
            get
            {
                return GetValue(PriceProperty);
            }
            set
            {
                SetValue(PriceProperty, value);
            }
        }
        [System.ComponentModel.Bindable(true)]
        public Object Image
        {
            get
            {
                return GetValue(ImageProperty);
            }
            set 
            { 
                SetValue(ImageProperty, value); 
            }
        }
        [System.ComponentModel.Bindable(true)]
        public Object ProductType 
        { 
            get 
            { 
                return GetValue(ProductTypeProperty); 
            }
            set 
                { SetValue(ProductTypeProperty, value); 
            }
        }

        public override string? ToString()
        {
            var s = ProductName?? String.Empty;
            return s as string;
        }
        #region PropertyChanging
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

    }
}
