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
        public static DependencyProperty ProductNameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Product), new PropertyMetadata(null));
        public static DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(string), typeof(Product), new PropertyMetadata(null));
        public static DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(string), typeof(Product), new PropertyMetadata(null));
        public static DependencyProperty ProductTypeProperty = DependencyProperty.Register("ProductType", typeof(string), typeof(Product), new PropertyMetadata(null));

        [System.ComponentModel.Bindable(true)]
        public string ProductName
        {
            get
            {
                return (GetValue(ProductNameProperty) ?? "") as string;
            }
            set
            {
                SetValue(ProductNameProperty, value);
            }
        }

        [System.ComponentModel.Bindable(true)]
        public string Price
        {
            get
            {
                return (GetValue(PriceProperty) ?? "") as string;
            }
            set
            {
                SetValue(PriceProperty, value);
            }
        }
        [System.ComponentModel.Bindable(true)]
        public string Image
        {
            get
            {
                return (GetValue(ImageProperty) ?? "") as string;
            }
            set 
            { 
                SetValue(ImageProperty, value); 
            }
        }
        [System.ComponentModel.Bindable(true)]
        public string ProductType 
        { 
            get 
            { 
                return (GetValue(ProductTypeProperty) ?? "") as string; 
            }
            set 
                { SetValue(ProductTypeProperty, value); 
            }
        }

        public override string ToString()
        {
            return ProductName.ToString();
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
