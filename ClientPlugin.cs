using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientPlugin : IPlugin
  {
    protected static Dictionary<String, int> statDictionary = null;
    public ClientPlugin()
    {
      if (statDictionary == null)
      {
        statDictionary = new Dictionary<String, int>();

      }
    }

    public void PreProcessing(HTTPRequest request)
    {
      if (statDictionary.ContainsKey(request.Url))
      {
        statDictionary[request.Url] = (int)statDictionary[request.Url] + 1;
      }
      else
      {
        statDictionary[request.Url] = 1;
      }
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
      string Client = request.getPropertyByKey("RemoteEndPoint");
      string ClientIP_Split = Client.Split(':')[0];
      string ClientPort = Client.Split(':')[1];
      string Browser_Information = request.getPropertyByKey("User-Agent");
      string Accept_Language = request.getPropertyByKey("Accept-Language");
      string Accept_Encoding = request.getPropertyByKey("Accept-Encoding");

      sb.Append("<html><body><h1><center><u><font color='red'>PC Client Info:</font></u></center></h1>");
      sb.Append("<b>Client IP: </b>" + ClientIP_Split + "</br>");
      sb.Append("<b>Client Port: </b>" + ClientPort + "</br>");
      sb.Append("<b>Browser Information: </b>" + Browser_Information + "</br>");
      sb.Append("<b>Accept Language: </b>" + Accept_Language + "</br>");
      sb.Append("<b>Accept Encoding: </b>" + Accept_Encoding + "</br>");


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