﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace CornerShopSecialistDesktop
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        private static string BASE_URL = "http://web.socem.plymouth.ac.uk/FYP/WButler";

        private static string TEST_URL = "http://localhost:44308/";

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri(BASE_URL + "api/");
            ResetHeaders();
        }

        public static bool WebLogin(string username, string password)
        {
            HttpClient tempClient = new HttpClient();
            tempClient.BaseAddress = new Uri(BASE_URL);

            var request = new HttpRequestMessage(HttpMethod.Post, "token");

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("username", username));
            keyValues.Add(new KeyValuePair<string, string>("password", password));
            keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));
            keyValues.Add(new KeyValuePair<string, string>("login_type", "employee"));

            request.Content = new FormUrlEncodedContent(keyValues);

            try
            {
                var response = tempClient.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    JObject jsonResponse = JObject.Parse(jsonString);
                    string accessToken = (string)jsonResponse["access_token"];

                    // Store the bearer token in the global http client.
                    WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    return true;
                }
            } catch
            {
                return false;
            }

            return false;
        }

        public static void ResetHeaders()
        {
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}