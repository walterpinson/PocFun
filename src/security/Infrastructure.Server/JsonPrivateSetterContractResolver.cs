using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Server
{
    public class JsonPrivateSetterContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var propertyOrField = base.CreateProperty(member, memberSerialization);

            if (!propertyOrField.Writable)
            {
                var property = member as PropertyInfo;
                if (property != null)
                {
                    var hasPrivateSetter = property.GetSetMethod(true) != null;
                    propertyOrField.Writable = hasPrivateSetter;
                }
            }

            return propertyOrField;
        }
    }
}