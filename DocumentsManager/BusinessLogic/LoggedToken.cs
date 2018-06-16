//using DocumentsManager.Exceptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DocumentsManager.BusinessLogic
//{
//    public class LoggedToken
//    {
//        static Guid notInitialized = new Guid();
//        private static Guid token;
//        public static Guid GetToken()
//        {
//            if (token == notInitialized)
//            {
//                throw new NoUserLoggedException();
//            }
//            return token;
//        }
//        public static void SetToken(Guid loggedToken)
//        {
//            token = loggedToken;
//        }
//        public static void DeleteToken()
//        {
//            token = notInitialized;
//        }
//    }
//}
