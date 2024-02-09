using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientinfoPlugin : IPlugin
  {
    protected static Dictionary<String, int> statDictionary = null;
    public ClientinfoPlugin()
    {
    }

    public void PreProcessing(HTTPRequest request)
    {
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();

      string clientInfo = request.getPropertyByKey("RemoteEndPoint");
      string clientIP = clientInfo.Split(":")[0];
      string clientPort = clientInfo.Split(":")[1];
      string browser = request.getPropertyByKey("User-Agent");
      string acceptLang = request.getPropertyByKey("Accept-Language");
      string acceptEn = request.getPropertyByKey("Accept-Encoding");


      sb.Append("<html><body><h1>ClientInfo:</h1>");
      sb.Append("<h1>Client Info: " + clientInfo + "</h1>");
      sb.Append("<h1>Client IP: " + clientIP + "</h1>");
      sb.Append("<h1>Client Port: " + clientPort + "</h1>");
      sb.Append("<h1>Browser's Info: " + browser + "</h1>");
      sb.Append("<h1>Client Accept Language: " + acceptLang + "</h1>");
      sb.Append("<h1>Client Accept Encoding: " + acceptEn + "</h1>");

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