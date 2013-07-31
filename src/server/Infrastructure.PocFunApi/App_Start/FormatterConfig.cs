using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.PocFunApi
{
    public class FormatterConfig
    {
        /// <summary>
        /// Registers the global formatters.
        /// </summary>
        /// <param name="formatters">The formatters.</param>
        public static void RegisterGlobalFormatters(MediaTypeFormatterCollection formatters)
        {
            RegisterJsonFormatter(formatters);
        }

        /// <summary>
        /// Registers the Json formatters.
        /// </summary>
        /// <param name="formatters">The formatters.</param>
        private static void RegisterJsonFormatter(MediaTypeFormatterCollection formatters)
        {
            var jsonSerializerSettings = formatters.JsonFormatter.SerializerSettings;

            jsonSerializerSettings.Converters.Add(new IsoDateTimeConverter());
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.Insert(0, new Formatters.JsonMediaTypeFormatter(jsonSerializerSettings) { UseDataContractJsonSerializer = false });
        }
    }
}