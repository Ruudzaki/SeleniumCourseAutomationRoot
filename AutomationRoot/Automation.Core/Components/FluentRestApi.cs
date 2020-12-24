using Automation.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Components
{
    class FluentRestApi : IFluent
    {
        protected FluentRestApi(HttpClient httpClient, ILogger logger)
        {
            HttpClient = httpClient;
            Logger = logger;
        }

        protected FluentRestApi(HttpClient httpClient)
            : this(httpClient, new TraceLogger())
        {
        }

        public HttpClient HttpClient { get; }
        public ILogger Logger { get; }

        public T ChangeContext<T>()
        {
            throw new NotImplementedException();
        }

        public T ChangeContext<T>(ILogger logger)
        {
            throw new NotImplementedException();
        }

        public T ChangeContext<T>(string application)
        {
            throw new NotImplementedException();
        }

        public T ChangeContext<T>(string application, ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
