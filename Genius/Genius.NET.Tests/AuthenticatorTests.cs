using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Genius.NET.Tests
{
    [TestClass]
    public class AuthenticatorTests
    {
        [TestMethod]
        public void GetAuthenticationUrlCorrect()
        {
            Authenticator.ClientId = "clientId";
            Authenticator.RedirectUri = "redirectUri";
            Authenticator.Scope = "scope";
            Authenticator.State = "state";
            Assert.AreEqual(new Uri("https://api.genius.com/oauth/authorize?client_id=clientId&redirect_uri=redirectUri" +
                            "&scope=scope&state=state&response_type=code"), Authenticator.GetAuthenticationUrl());
        }

        [TestMethod]
        public void GetAuthenticationUrlInCorrect()
        {
            Authenticator.ClientId = null;
            Authenticator.RedirectUri = null;
            Authenticator.Scope = null;
            Authenticator.State = null;
            Assert.ThrowsException<ArgumentNullException>(Authenticator.GetAuthenticationUrl);
        }

        [TestMethod]
        public void GetAuthenticationUrlClientOnlyCorrect()
        {
            Authenticator.ClientId = "clientId";
            Authenticator.ClientId = "clientId";
            Authenticator.RedirectUri = "redirectUri";
            Authenticator.Scope = "scope";
            Authenticator.State = "state";
            Assert.AreEqual(new Uri("https://api.genius.com/oauth/authorize?client_id=clientId&redirect_uri=redirectUri" +
                            "&scope=scope&state=state&response_type=token"), Authenticator.GetAuthenticationUrlClientOnly());
        }

        [TestMethod]
        public void GetAuthenticationUrlClientOnlyInCorrect()
        {
            Authenticator.ClientId = null;
            Authenticator.RedirectUri = null;
            Authenticator.Scope = null;
            Authenticator.State = null;
            Assert.ThrowsException<ArgumentNullException>(Authenticator.GetAuthenticationUrlClientOnly);
        }
    }
}
