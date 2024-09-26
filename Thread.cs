using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using System.Threading;

namespace DNWS
{
  class ThreadPlugin : IPlugin
  {
    protected static Dictionary<String, int> statDictionary = null;
    public ThreadPlugin()
    {
   
    }

    public void PreProcessing(HTTPRequest request)
    {
      
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      // create string builder
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();

      // thread extending
      Thread thread1 = new Thread(Th1assigned);
      Thread thread2 = new Thread(Th2assigned);


      sb.Append("Thread pages");



      
      // http Response
      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;


    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }
     

     // assignment of each threads
    public static void Th1assigned()
    {

    }
    public static void Th2assigned()
    {

    }
  }
}

