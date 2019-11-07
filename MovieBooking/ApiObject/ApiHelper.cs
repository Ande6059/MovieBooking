using MovieBooking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieBooking.ApiObject
{
    public class ApiHelper
    {
        public List<Movie> Start()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create
                (string.Format("http://simonsmoviebooking.azurewebsites.net/api/movie"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>
                (jsonString);

            return movies;
        }
    }
}
