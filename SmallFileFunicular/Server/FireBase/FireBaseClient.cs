using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;

namespace Server.FireBase
{
    class FireBaseClient
    {
        private static IFirebaseConfig fConfig = new FirebaseConfig()
        {
            BasePath = "https://smallfilefunicular-default-rtdb.firebaseio.com/",
            AuthSecret = "zy45dOIje35M51x1eBa7QB3kVxphfBcchSMvrnyP"
        };

        private static IFirebaseClient client;

        public static void Connect()
        {
            try
            {
                client = new FireSharp.FirebaseClient(fConfig);
            } catch { Console.WriteLine("Error occured while server tried to establish connection with Google Firebase..."); }
        }
    }
}
