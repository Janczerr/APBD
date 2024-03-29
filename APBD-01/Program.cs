﻿using System.Text.RegularExpressions;

namespace apbd1
{
    public class Program
    {
        public static async Task Main(String[] args)
        {
            Regex mail_rx = new Regex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])");

            Console.WriteLine("Podaj adres URL:");
            string adresUrl = Console.ReadLine();
            var httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(adresUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    foreach (Match match in mail_rx.Matches(result))
                    {
                        Console.WriteLine("Matched e-mail: " + match.Value);
                    }
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Niepoprawny format URL");
            }
        }
    }
}