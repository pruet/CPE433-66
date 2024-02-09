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
      /*if (statDictionary == null)
      {
        statDictionary = new Dictionary<String, int>();

      }*/
    }

    public void PreProcessing(HTTPRequest request)
    {
      /*if (statDictionary.ContainsKey(request.Url))
      {
        statDictionary[request.Url] = (int)statDictionary[request.Url] + 1;
      }
      else
      {
        statDictionary[request.Url] = 1;
      }*/
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
 
      string clientInfo = request.getPropertyByKey("RemoteEndPoint");
      string clientIP = clientInfo.Split(':')[0]; //the zero mean the right side
      string clientPort = clientInfo.Split(':')[1];
      string browserInfo = request.getPropertyByKey("User-Agent");
      string acceptLanguage = request.getPropertyByKey("Accept-Language");
      string acceptEncoding = request.getPropertyByKey("Accept-Encoding");


      sb.Append("<html><body><h1> 650615034 Savaree Srivolakul </h1>");
      sb.Append("<html><body><h2> ==== ClientInfo ==== </h2>");
      sb.Append("Client IP:  " + clientIP + "<br/>");
      sb.Append("Client Port:  " + clientPort + "<br/>");
      sb.Append("Client Browser Information:  " + browserInfo + "<br/>");
      sb.Append("Client Accept Language:  " + acceptLanguage + "<br/>");
      sb.Append("Client Accept Encoding:  " + acceptEncoding + "<br/>");

     





     
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