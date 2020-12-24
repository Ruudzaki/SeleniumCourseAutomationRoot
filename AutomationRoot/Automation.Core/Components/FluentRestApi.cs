using Automation.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Components
{
    public class FluentRestApi : FluentBase
    {
        public FluentRestApi(HttpClient httpClient, ILogger logger) : base(logger)
        {
            HttpClient = httpClient ?? new HttpClient();
        }

        public FluentRestApi(HttpClient httpClient)
            : this(httpClient, new TraceLogger())
        {
        }

        public HttpClient HttpClient { get; }

        public override T ChangeContext<T>(string application)
        {
            HttpClient.BaseAddress = new Uri(application);
            return Create<T>(null, null);
        }

        public override T ChangeContext<T>(string application, ILogger logger)
        {
            HttpClient.BaseAddress = new Uri(application);
            return Create<T>(null, logger);
        }

        public override T ChangeContext<T>(string type, string application)
        {
            var t = GetTypeByName(type);
            HttpClient.BaseAddress = new Uri(application);
            return Create<T>(t, null);
        }

        internal override T Create<T>(Type type, ILogger logger)
        {
            if (type == null)
            {
                type = typeof(T);
            }

            return logger == null
                ? (T)Activator.CreateInstance(type, new object[] { HttpClient })
                : (T)Activator.CreateInstance(type, new object[] { HttpClient, logger });
        }


    }
}
