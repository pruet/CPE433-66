using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientInfoPlugin : IPlugin
  {
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
      sb.Append("<html><head>");
      sb.Append("<style>");
      sb.Append("body { font-family: courier new; }");
      sb.Append("</style>");
      sb.Append("</head><body>");


      // Accessing client's IP address and port number
      string clientIP_Port = request.getPropertyByKey("RemoteEndPoint");
      string clientIP = clientIP_Port.Split(':')[0];
      string clientPort = clientIP_Port.Split(':')[1];

      string browserInfo = request.getPropertyByKey("User-Agent");
      string acceptLanguage = request.getPropertyByKey("Accept-Language");
      string acceptEncoding = request.getPropertyByKey("Accept-Encoding");


      sb.Append($"Client IP Address: {clientIP}<br />");
      sb.Append($"Client Port: {clientPort}<br />");
      sb.Append($"Browser Information: {browserInfo}<br />");
      sb.Append($"Accept Language: {acceptLanguage}<br />");
      sb.Append($"Accept Encoding: {acceptEncoding}<br />");


      sb.Append("</body></html>");
      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      return response;
    }
  }
}