using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientInfoPlugin : IPlugin
  {
    protected static Dictionary<String, int> statDictionary = null;
    public ClientInfoPlugin()
    {
      
      
    }

    public void PreProcessing(HTTPRequest request)
    {
      
      
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
      
      String ClientInfo = request.getPropertyByKey("RemoteEndPoint");
      String ClientIP = ClientInfo.Split(':')[0];
      String ClientPort = ClientInfo.Split(':')[1];
      String browserInfo = request.getPropertyByKey("User-Agent");
      String acceptLanguage = request.getPropertyByKey("Accept-Language");
      String acceptEncoding = request.getPropertyByKey("Accept-Encoding");

      
      sb.Append("<html><body><h1>ClientInfo:</h1>");
      sb.Append("Client IP:" + ClientIP + "<br/>");
      sb.Append("Client Port:" + ClientPort + "<br/>");
      sb.Append("Client Browser Information:" + browserInfo + "<br/>");
      sb.Append("Client Accept Language:" + acceptLanguage + "<br/>");
      sb.Append("Client Accept Encoding:" + acceptEncoding + "<br/>");
      
      
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