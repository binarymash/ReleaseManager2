namespace ReleaseManager.Api.Host.Hal
{
    using System;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Net.Http.Headers;
    using Newtonsoft.Json;
    using WebApi.Hal;
    using WebApi.Hal.JsonConverters;

    public class JsonHalMediaTypeOutputFormatter: JsonOutputFormatter
    {
        private readonly ResourceListConverter resourceListConverter = new ResourceListConverter();
        private readonly ResourceConverter resourceConverter = new ResourceConverter();
        private readonly LinksConverter linksConverter = new LinksConverter();
        private readonly EmbeddedResourceConverter embeddedResourceConverter = new EmbeddedResourceConverter();

        public JsonHalMediaTypeOutputFormatter(IHypermediaResolver hypermediaConfiguration)
        {
            if (hypermediaConfiguration == null)
            {
                throw new ArgumentNullException("hypermediaConfiguration");
            }
            this.resourceConverter = new ResourceConverter(hypermediaConfiguration);
            this.Initialize();
        }

        public JsonHalMediaTypeOutputFormatter()
        {
            this.resourceConverter = new ResourceConverter();
            this.Initialize();
        }

        private void Initialize()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/hal+json"));
            ((JsonSerializerSettings)this.SerializerSettings).Converters.Add((JsonConverter)this.linksConverter);
            ((JsonSerializerSettings)this.SerializerSettings).Converters.Add((JsonConverter)this.resourceListConverter);
            ((JsonSerializerSettings)this.SerializerSettings).Converters.Add((JsonConverter)this.resourceConverter);
            ((JsonSerializerSettings)this.SerializerSettings).Converters.Add((JsonConverter)this.embeddedResourceConverter);
            ((JsonSerializerSettings)this.SerializerSettings).NullValueHandling = NullValueHandling.Ignore;
        }

        protected override bool CanWriteType(Type declaredType, Type runtimeType)
        {
            //TODO: check
            return typeof(Representation).IsAssignableFrom(runtimeType);
        }
    }
}

