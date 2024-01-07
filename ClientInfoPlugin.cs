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
      sb.Append("body { font-family: courier new; margin: 20px; }");
      sb.Append(".container { width: 60%; margin: 0 auto; }");
      sb.Append(".box { background-color: #f9f9f9; padding: 20px; margin-bottom: 20px; border-radius: 5px; }");
      sb.Append(".title { font-size: 18px; font-weight: bold; margin-bottom: 10px; }");
      sb.Append(".item { margin-bottom: 8px; }");
      sb.Append("</style>");
      sb.Append("</head><body>");

      sb.Append("<div class='container'>");
      sb.Append("<div class='box'>");
      sb.Append("<div class='title'>Client INFORMATION:</div>");

      // Accessing client's IP address and port number
      string clientIP_Port = request.getPropertyByKey("RemoteEndPoint");
      string clientIP = clientIP_Port.Split(':')[0];
      string clientPort = clientIP_Port.Split(':')[1];
      string browserInfo = request.getPropertyByKey("User-Agent");
      string acceptLanguage = request.getPropertyByKey("Accept-Language");
      string acceptEncoding = request.getPropertyByKey("Accept-Encoding");

      sb.Append("<div class='item'>Client IP Address: " + clientIP + "</div>");
      sb.Append("<div class='item'>Client Port: " + clientPort + "</div>");
      sb.Append("<div class='item'>Browser Information: " + browserInfo + "</div>");
      sb.Append("<div class='item'>Accept Language: " + acceptLanguage + "</div>");
      sb.Append("<div class='item'>Accept Encoding: " + acceptEncoding + "</div>");

      sb.Append("</div></div>");

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