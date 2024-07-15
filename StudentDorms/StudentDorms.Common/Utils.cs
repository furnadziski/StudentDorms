using StudentDorms.Settings;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using StudentDorms.Models;
using StudentDorms.Common.Exceptions;
using StudentDorms.Models.Enums;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace StudentDorms.Common
{
    public static class Utils
    {
        public static IConfiguration _configuration { get; set; }

        public static Dictionary<string, string> userDefaultLanguage { get; set; }

        static Utils()
        {
            userDefaultLanguage = new Dictionary<string, string>();
        }

        public static string FormPost(string url, string postData)
        {
            byte[] byteArray = null;

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";

            if (!string.IsNullOrEmpty(postData))
            {
                byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;
            }

            request.ContentType = "application/x-www-form-urlencoded";

            Stream dataStream = request.GetRequestStream();
            // Send the data.
            if (!string.IsNullOrEmpty(postData))
                dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        public static string AjaxToApiController(string token, string controller, string method, string data, string methodType)
        {

            var webapiUrl = StudentDorms.Settings.ConfigurationManager.AppSettings.ApiUrl;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}/{2}", webapiUrl, controller, method));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = methodType;

            if (!string.IsNullOrEmpty(token))
                httpWebRequest.Headers.Add("Authorization", "Bearer " + token);

            if (!string.IsNullOrEmpty(data))
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            HttpWebResponse httpResponse = null;

            try
            {
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    var status = response.StatusCode;
                    if (!string.IsNullOrEmpty(status.ToString()))
                    {
                        var errorResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResult>(response.StatusDescription);
                        var error = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorMsg>(errorResult.error);
                        ThrowExceptionByStatusCode((int)status, error.Message);
                    }
                }
            }
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }

        public static void ThrowExceptionByStatusCode(int statusCode, string statusDescription)
        {
            switch (statusCode)
            {
                case (int)ErrorStatusCodeEnum.UserNotActive:
                    throw new UserNotActiveException();
                case (int)ErrorStatusCodeEnum.UserNotRegistered:
                    throw new UserNotRegisteredException();
                case (int)ErrorStatusCodeEnum.InvalidModel:
                case (int)ErrorStatusCodeEnum.StudentDormsError:
                    throw new StudentDormsException(statusDescription);
                case (int)ErrorStatusCodeEnum.Unauthorized:
                    throw new UnauthorizedAccessException();
                case (int)ErrorStatusCodeEnum.InternalServerError:
                    throw new ApplicationException(statusDescription);
                case (int)ErrorStatusCodeEnum.NotImplemented:
                    throw new NotImplementedException();
                default:
                    throw new Exception(statusDescription);
            }
        }

        public static IEnumerable<TSource> DistinctByMisc<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var knownKeys = new HashSet<TKey>();
            return source.Where(element => knownKeys.Add(keySelector(element)));
        }
        
        public static DataTable CreateIntDataTableFromListOfIntegers(List<int> listOfIntegers)
        {
            var listTemp = new List<int> { };
            listOfIntegers = listOfIntegers == null ? listTemp : listOfIntegers;
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));

            foreach (var i in listOfIntegers)
            {
                DataRow row = dt.NewRow();
                row["Id"] = i;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }

    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"));
        }


    }

    public class UppercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.First().ToString().ToUpper() + propertyName.Substring(1);
        }
    }



}
