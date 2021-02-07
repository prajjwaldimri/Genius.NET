using Genius;
using Genius.Models.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Tests.Models;
using Tests.Utilities;

namespace Tests
{
    [TestClass]
    public class AnnotationClientTests
    {
        private static GeniusClient _geniusClient;
        private static TestInputData _inputData;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _geniusClient = GeniusClientInitializer.GetClient();
            _inputData = TestInputData.GetFromJsonFile();
        }

        [TestMethod]
        public async Task GetAnnotation()
        {
            foreach(ulong annotationId in _inputData.Annotations)
            {
                AnnotationResponse annotationResponse = await _geniusClient.AnnotationClient.GetAnnotation(annotationId);
                Assert.IsNotNull(annotationResponse);
            }           
        }
    }
}
