using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;

namespace WmRestClients
{
    public class NewsJsonWebService
    {
        #region Constants

        private const string WEB_SERVICE_URL = "http://alednb:82/ayoooapi/v1/getAllTerbaru";

        #endregion //Constants

        public NewsResultsCache QueryINews()
        {
            string uri = WEB_SERVICE_URL; // string.Format(WEB_SERVICE_URL, searchText);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.Headers.Add("Authorization", "7e8f60e325cd06e164799af1e317d7a7");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            string jsonString = null;
            using (StreamReader reader = new StreamReader(responseStream))
            {
                jsonString = reader.ReadToEnd();
                reader.Close();
            }

            JObject jResult = JObject.Parse(jsonString);
            List<JToken> jResults = jResult["dataset"].Children().ToList(); //dataset is object from json
            List<NewsResult> result = new List<NewsResult>();
            foreach (JToken jNewsResult in jResults)
            {
                NewsResult newsResult = JsonConvert.DeserializeObject<NewsResult>(jNewsResult.ToString());
                result.Add(newsResult);
            }
            return new NewsResultsCache(result);
        }

        public NewsResultsCache Login(string emailId, string loginCode, string password)
        {
            string uri = @"http://alednb:82/ayoooapi/v1/userlogin"; // string.Format(WEB_SERVICE_URL, searchText);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.Headers.Add("Authorization", "7e8f60e325cd06e164799af1e317d7a7");
            //request.AllowWriteStreamBuffering = true;

            //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            //{
            //    string json = "{\"emailId\":\""+emailId+"\"," +
            //                  "\"loginCode\":\""+loginCode+"\"," +
            //                  "\"password\":\""+password+"\"}";

            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}

            string paramz = "emailId="+emailId+"&loginCode="+loginCode+"&password="+password;


            byte[] formData = UTF8Encoding.UTF8.GetBytes(paramz.ToString());
            request.ContentLength = formData.Length;

            using (Stream post = request.GetRequestStream())
            {
                post.Write(formData, 0, formData.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            string jsonString = null;
            using (StreamReader reader = new StreamReader(responseStream))
            {
                jsonString = reader.ReadToEnd();
                reader.Close();
            }

            JObject jResult = JObject.Parse(jsonString);
            List<JToken> jResults = jResult["dataset"].Children().ToList(); //dataset is object from json
            List<NewsResult> result = new List<NewsResult>();
            foreach (JToken jNewsResult in jResults)
            {
                NewsResult newsResult = JsonConvert.DeserializeObject<NewsResult>(jNewsResult.ToString());
                result.Add(newsResult);
            }
            return new NewsResultsCache(result);
        }

        public bool UploadFile(string PostURL)
        {
            try
            {
                //string directoryName = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)+ "\img1.png";

                //byte[] data = File.ReadAllBytes(path);

                //// Prepare web request...
                //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(PostURL);
                //webRequest.Method = "POST";
                //webRequest.ContentType = "multipart/form-data";
                //webRequest.ContentLength = data.Length;
                //using (Stream postStream = webRequest.GetRequestStream())
                //{
                //    // Send the data.
                //    postStream.Write(data, 0, data.Length);
                //    postStream.Close();
                //}
                return true;
            }
            catch (Exception ex)
            {
                //Log exception here...
                return false;
            }
        }

        
    }

    
}
