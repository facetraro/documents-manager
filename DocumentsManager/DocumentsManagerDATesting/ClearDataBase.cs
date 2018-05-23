using DocumentsManager.Data.DA.Handler;
using DocumentsManagerDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerDATesting
{
    public class ClearDataBase
    {
        public static void ClearAll()
        {
            ClearAllFriendship();
            ClearAllHistories();
            ClearAllParragraph();
            ClearAllDocuments();
            ClearAllFormats();
            ClearAllFooters();
            ClearAllHeaders();
            ClearAllTexts();
            ClearAllUsers();
            ClearAllStyleClasses(); 
        }

        private static void ClearAllStyleClasses()
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            context.ClearAll();
        }
        private static void ClearAllUsers()
        {
            UserContext context = new UserContext();
            context.ClearAll();
        }

        private static void ClearAllFormats()
        {
            FormatContext context = new FormatContext();
            context.ClearAll();
        }

        private static void ClearAllTexts()
        {
            TextContext context = new TextContext();
            context.ClearAll();
        }
        private static void ClearAllParragraph()
        {
            ParragraphContext context = new ParragraphContext();
            context.ClearAll();
        }
        private static void ClearAllFooters()
        {
            FooterContext context = new FooterContext();
            context.ClearAll();
        }
        private static void ClearAllHeaders()
        {
           HeaderContext context = new HeaderContext();
            context.ClearAll();
        }
        private static void ClearAllDocuments()
        {
            DocumentContext context = new DocumentContext();
            context.ClearAll();
        }
        private static void ClearAllHistories()
        {
            ModifyDocumentHistoryContext context = new ModifyDocumentHistoryContext();
            context.ClearAll();
        }
        private static void ClearAllFriendship()
        {
            FriendshipContext context = new FriendshipContext();
            context.ClearAll();
        }
    }
}
