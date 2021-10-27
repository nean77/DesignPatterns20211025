using System.IO;
using System.Net;

namespace PbLab.DesignPatterns.Communication
{
    public class HttpChanel : IChanel
    {
        public StreamReader Connect(string resource)
        {
            var request = WebRequest.Create(resource);
            var response = request.GetResponse();
            return new StreamReader(response.GetResponseStream());
        }
    }
}
