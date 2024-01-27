using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientInfoPLugin : IPlugin
  {
    protected static Dictionary<String, int> statDictionary = null;
    public ClientInfoPLugin
()
    {
      

    }

    public void PreProcessing(HTTPRequest request)
    {
      
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();

      String clientInfo = request.getPropertyByKey("RemoteEndPoint");
      String clientIP = clientInfo.Split(':')[0];
      String clientPort = clientInfo.Split(':')[1];
      String browserInfo = request.getPropertyByKey("User-Agent");
      String acceptLanguage = request.getPropertyByKey("Accept-Language");
      String acceptEncoding = request.getPropertyByKey("Accept-Encoding");

    sb.Append("<html><head>");
    sb.Append("<style>");
    sb.Append(@"
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .container {
            text-align: left;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            background-color: #ffffff;
            width: 400px;
        }
        h1 {
            font-size: 28px;
            color: #333333;
            margin-bottom: 20px;
        }
        label {
            font-weight: bold;
            color: #555555;
        }
        span {
            display: block;
            margin-bottom: 10px;
            color: #777777;
        }
    ");
    sb.Append("</style>");
    sb.Append("</head><body>");
    sb.Append("<div class='container'>");
    sb.Append("<h1>Client Info:</h1>");
    sb.Append("<label>Client IP:</label><span>" + clientIP + "</span>");
    sb.Append("<label>Client Port:</label><span>" + clientPort + "</span>");
    sb.Append("<label>Client Browser Information:</label><span>" + browserInfo + "</span>");
    sb.Append("<label>Client Accept Language:</label><span>" + acceptLanguage + "</span>");
    sb.Append("<label>Client Accept Encoding:</label><span>" + acceptEncoding + "</span>");
    sb.Append("</div></body></html>");

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