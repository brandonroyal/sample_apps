using Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Web.Repositories
{
    public class BackendMetadataRepository : IBackendMetadataRepository
    {
        private string metaDataPath = "api/metadata";
        public MetaData GetMetaData()
        {
            MetaData metaData;
            var apiHostname = Environment.GetEnvironmentVariable("API_HOSTNAME");
            if (String.IsNullOrEmpty(apiHostname))
            {
                return null;
            }
            var baseUrl = new Uri(string.Format("http://{0}", apiHostname));
            var url = new Uri(baseUrl, metaDataPath);
            WebRequest request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                var response = request.GetResponse();
                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream); 
                var responseFromServer = reader.ReadToEnd();
                metaData = JsonConvert.DeserializeObject<MetaData>(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (WebException exception)
            {
                return null;
            }
            return metaData;
        }
    }
}