using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FooWpf.Model;

namespace FooWpf;

public class Fetcher
{
    private static readonly string testDefault = @"https://mdn.github.io/learning-area/javascript/apis/fetching-data/can-store/products.json";
    public static async Task<string> Fetch(HttpClient client, string url)
    {
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        string result = string.Empty;
        url = string.IsNullOrWhiteSpace(url) ? testDefault : url;
        try
        {
            // mimic delay test to ui 
            await Task.Delay(5000);

            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);

            Console.WriteLine(result);
        }
        catch (HttpRequestException badhttp)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", badhttp.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", ex.Message);
        }
        return result;
    }
    public static async Task<List<Product>> FetchTyped(HttpClient client, string url)
    {
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        List <MDNProduct> result = new ();
        url = string.IsNullOrWhiteSpace(url) ? testDefault : url;
        try
        {
            // mimic delay test to ui 
            //await Task.Delay(5000);

            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<MDNProduct>>();
            }
        }
        catch (HttpRequestException badhttp)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", badhttp.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", ex.Message);
        }
        List<Product> products = new ();        
        foreach (var mdnProduct in result) 
        {
            products.Add(new Product { 
                ProductName = mdnProduct.Name,
                Price=mdnProduct.Price, 
                Image=mdnProduct.Image, 
                ProductType=mdnProduct.ProductType
            });
        }
        return products;
    }
}
