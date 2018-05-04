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
            ClearAllTexts();
            ClearAllFormats();
            ClearAllAdmins();
            ClearAllEditors();
            ClearAllStyleClasses(); 
        }

        private static void ClearAllStyleClasses()
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            context.ClearAll();
        }

        private static void ClearAllEditors()
        {
            EditorUserContext context = new EditorUserContext();
            context.ClearAll();
        }

        private static void ClearAllAdmins()
        {
            AdminUserContext context = new AdminUserContext();
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
    }
}
