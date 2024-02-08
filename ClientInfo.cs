using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientInfo : IPlugin
  {
    public ClientInfo()
    {
    }

    public void PreProcessing(HTTPRequest request)
    {
    }

    public HTTPResponse GetResponse(HTTPRequest request)
    {
      // Accessing client's IP address and port number
      string clientIP_Port = request.getPropertyByKey("RemoteEndPoint");
      string clientIP = clientIP_Port.Split(':')[0];
      string clientPort = clientIP_Port.Split(':')[1];
      string browserInfo = request.getPropertyByKey("User-Agent");
      string acceptLanguage = request.getPropertyByKey("Accept-Language");
      string acceptEncoding = request.getPropertyByKey("Accept-Encoding");

      // Generating HTML response
      string htmlContent = GenerateHtmlContent(clientIP, clientPort, browserInfo, acceptLanguage, acceptEncoding);

      HTTPResponse response = new HTTPResponse(200)
      {
        body = Encoding.UTF8.GetBytes(htmlContent)
      };

      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      return response;
    }

    private string GenerateHtmlContent(string clientIP, string clientPort, string browserInfo, string acceptLanguage, string acceptEncoding)
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("<html><head>");
      sb.Append($"Client IP Address: {clientIP} <br/>");
      sb.Append($"Client Port: {clientPort}<br/>");
      sb.Append($"Browser Information: {browserInfo} <br/>");
      sb.Append($"Accept Language: {acceptLanguage} <br/>");
      sb.Append($"Accept Encoding: {acceptEncoding} <br/>");
      sb.Append("</div></div>");
      sb.Append("</body></html>");

      return sb.ToString();
    }
  }
}
