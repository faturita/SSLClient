using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bpf.Security.Common;

namespace Bpf.Common.Service
{
    public class TokenManager
    {
        private TokenManager() { }
        private AuthenticatedToken token;
        private static TokenManager _instance;


        public static TokenManager Instance
        {
            get {

                if (_instance == null) 
                {
                    _instance = new TokenManager();
                }
                return _instance;
            }
        }

        public void LoadToken(AuthenticatedToken t)
        {
            token = t;
        }

        public AuthenticatedToken RetrieveToken()
        {
            return token;
        }
    }
}
