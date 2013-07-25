using Newtonsoft.Json.Serialization;

namespace Infrastructure.PocFunApi.Formatters
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="MediaTypeFormatter"/> class to handle Json.
    /// </summary>
    public class JsonMediaTypeFormatter : System.Net.Http.Formatting.JsonMediaTypeFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonMediaTypeFormatter"/> class.
        /// </summary>
        /// <param name="jsonSerializerSettings">The JsonSerializerSettings.</param>
        public JsonMediaTypeFormatter(JsonSerializerSettings jsonSerializerSettings)
            : base()
        {
            this.SerializerSettings = jsonSerializerSettings;
        }

        /// <summary>
        /// Called during serialization to write an object of the specified <paramref name="type"/>
        /// to the specified <paramref name="writeStream"/>.
        /// </summary>
        /// <param name="type">The type of object to write.</param>
        /// <param name="value">The object to write.</param>
        /// <param name="writeStream">The <see cref="Stream"/> to which to write.</param>
        /// <param name="content">The <see cref="HttpContent"/> for the content being written.</param>
        /// <param name="transportContext">The <see cref="TransportContext"/>.</param>
        /// <returns>A <see cref="Task"/> that will write the value to the stream.</returns>
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var task = Task.Factory.StartNew(() =>
            {
                string json = JsonConvert.SerializeObject(value, Formatting.Indented, this.SerializerSettings);
                byte[] buf = System.Text.Encoding.Default.GetBytes(json);

                writeStream.Write(buf, 0, buf.Length);
                writeStream.Flush();
            });

            return task;
        }
    }
}