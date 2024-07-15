using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace StudentDorms.Common
{
    public static class ModelStateExtensions
    {
        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                return (IEnumerable)Enumerable.ToList(Enumerable.SelectMany(Enumerable.Where<string>((IEnumerable<string>)modelState.Keys, (Func<string, bool>)(key => Enumerable.Any<ModelError>((IEnumerable<ModelError>)modelState[key].Errors))), (Func<string, IEnumerable<ModelError>>)(key => (IEnumerable<ModelError>)modelState[key].Errors), (key, error) => new
                {
                    Key = key,
                    Message = error.ErrorMessage
                }));
            return (IEnumerable)null;
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }

    public static class XMLSerializer
    {
        public static string XmlSerialize<T>(T objectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter)
            {
                Formatting = System.Xml.Formatting.Indented
            };

            xmlSerializer.Serialize(xmlWriter, objectToSerialize);
            return stringWriter.ToString();
        }
        public static T Deserialize<T>(string xml)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new StringReader(xml));
        }
    }
}
