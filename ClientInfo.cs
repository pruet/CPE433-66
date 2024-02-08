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

      string ClientInfo = request.getPropertyByKey("RemoteEndPoint");
      string ClientIP = ClientInfo.Split(':')[0];
      string ClientPort = ClientInfo.Split(':')[1];
      string browserInfo = request.getPropertyByKey("User-Agent");
      string acceptLuaguage = request.getPropertyByKey("Accept-Language");
      string acceptEncoding = request.getPropertyByKey("Accept-Encoding");

      sb.Append("<html><head><style> body  {font-famiry: courier new: 15px} </style></head>");
      sb.Append("<html><body><h1>ClientInfo:</h1>");
      sb.Append("Client IP: " + ClientIP + "<br/>");
      sb.Append("Client Port: " + ClientPort + "<br/>");
      sb.Append("Client Browser Information: " + browserInfo + "<br/>");
      sb.Append("Client Accept Lanluage: " + acceptLuaguage + "<br/>");
      sb.Append("Client Accept Encoding: " + acceptEncoding + "<br/>");

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