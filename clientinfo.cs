using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class clientInfoPlugin : IPlugin
  {
    protected static Dictionary<String, int> statDictionary = null;
    public clientInfoPlugin()
    {
    }

    public void PreProcessing(HTTPRequest request)
    {
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();

      // Siripa Aungwattana 650615032
      string client_info = request.getPropertyByKey("RemoteEndPoint");
      string client_ip = client_info.Split(':')[0];
      string client_port = client_info.Split(':')[1];
      string browser_info = request.getPropertyByKey("User-Agent");
      string accept_language = request.getPropertyByKey("Accept-Language");
      string accept_encoding = request.getPropertyByKey("Accept-Encoding");

      sb.Append("Client IP: " + client_ip + "<br/><br/>");
      sb.Append("Client Port: " + client_port + "<br/><br/>");
      sb.Append("Browser Information: " + browser_info + "<br/><br/>");
      sb.Append("Accept Language: " + accept_language + "<br/><br/>");
      sb.Append("Accept Encoding: " + accept_encoding + "<br/><br/>");
      
      sb.Append("</body></html>");
      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }
  }
}