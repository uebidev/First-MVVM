using Newtonsoft.Json;
using RJAplicationWPF.Model;
using RJAplicationWPF.Services.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RJAplicationWPF.Services
{
    public class ProductService
    {
        private bool disposedValue;
        public static async Task<List<Product>> GetAllAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(PathService.PathProductsUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var productsJson = await response.Content.ReadAsStringAsync();
                        ProductList ListProduct = JsonConvert.DeserializeObject<ProductList>(productsJson);
                        List<Product> products = ListProduct.Products.ToList();
                        return products;
                    }
                    else
                    {
                        throw new Exception("erro");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public static async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(PathService.PathProductId + id);
                    if (response.IsSuccessStatusCode)
                    {
                        var productJson = await response.Content.ReadAsStringAsync();
                        Product product = JsonConvert.DeserializeObject<Product>(productJson);
                        return product;
                    }
                    else
                    {
                        throw new Exception("Produto não encontrado.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task<List<Product>> GetNameAsync(string name)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(PathService.PathProductSearch + name);
                    if (response.IsSuccessStatusCode)
                    {
                        var productJson = await response.Content.ReadAsStringAsync();
                        ProductList ListProduct = JsonConvert.DeserializeObject<ProductList>(productJson);
                        List<Product> products = ListProduct.Products.ToList();
                        return products;
                    }
                    else
                    {
                        throw new Exception("Erro ao obter Produtos pelo nome");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static async Task<Product> AddProductAsync(Product product)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(product);

            using (var response = await httpClient.PostAsync(PathService.PathProductAdd,
                new StringContent(json, Encoding.UTF8, "application/json")))
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return response.StatusCode == HttpStatusCode.NoContent
                    ? null
                    : JsonConvert.DeserializeObject<Product>(responseBody);
            }
        }
        public static async Task<Product> UpdateProductAsync(long id, Product product)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string updateUrl = $"{PathService.PathProductDelete}{id}";

                    string productJson = JsonConvert.SerializeObject(product);
                    StringContent content = new StringContent(productJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(updateUrl, content);

                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public static async Task<bool> DeleteProductAsync(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(PathService.PathProductDelete + id);
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

