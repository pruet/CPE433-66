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

      string clientinfo = request.getPropertyByKey("RemoteEndPoint");
      string clientIP = clientinfo.Split(":")[0];
      string clientPort = clientinfo.Split(":")[1];
      string browserinfo = request.getPropertyByKey("User-Agent");
      string acceptLanguage = request.getPropertyByKey("Accept-Language");
      string acceptEncoding = request.getPropertyByKey("Accept-Encoding");

      sb.Append("<html><body>");

      sb.Append("<h1>Kasidate Raumsook 650615012</h1><br/>");

      sb.Append("Client IP : " + clientIP + "<br/>");
      sb.Append("Client Port : " + clientPort + "<br/>");
      sb.Append("Browser Information : " + browserinfo + "<br/>");
      sb.Append("Accept Language : " + acceptLanguage + "<br/>");
      sb.Append("Accept Encoding : " + acceptEncoding + "<br/>");





      
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