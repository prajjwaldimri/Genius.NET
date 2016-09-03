using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genius.NET.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ContentRetriever.AuthorizationToken = "ldslsxMqENSqAk5u1xExamNhiKVRv_IaVz_xQU2q--QYdhi-jlxGZ9LAM0Pvyffe";
            ContentRetriever.GetAnnotation(10225840);
            Console.ReadLine();
        }
    }
}
