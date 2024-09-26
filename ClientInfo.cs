using System;
using System.Collections.Generic;
using System.Security.AccessControl;
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
      string Clientinfo = request.getPropertyByKey("RemoteEndPoint");
      string ClientIP = Clientinfo.Split(':')[0];
      string ClientPort = Clientinfo.Split(':')[1];
      string browserInfo = request.getPropertyByKey("User-Agent");
      string acceptLanguage = request.getPropertyByKey("Accept-Language");
      string acceptEncoding = request.getPropertyByKey("Accept-Encoding");


      sb.Append("<html><head><style>body {font-family: courier new: 20px;}</style></head>");
      sb.Append("<body> <h1>ClientInfo:</h1></html> <br/>");
      sb.Append("ClientInfo IP: " + ClientIP + "<br/>");
      sb.Append("ClientInfo Port: " + ClientPort + "<br/>");
      sb.Append("ClientInfo Browser Information: " + browserInfo + "<br/>");
      sb.Append("ClientInfo Accept Language: " + acceptLanguage + "<br/>");
      sb.Append("ClientInfo Accept Encoding: " + acceptEncoding + "<br/>");

      sb.Append("</body>");

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