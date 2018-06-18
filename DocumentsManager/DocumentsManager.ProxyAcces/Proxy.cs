using DocumentsManager.BusinessLogic;
using DocumentsManager.ProxyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.BusinessLogic.Charts;

namespace DocumentsManager.ProxyAcces
{
    public class Proxy : IUserBusinessLogic, IDocumentBusinessLogic, IAdminsBusinessLogic, IEditorsBusinessLogic, IFormatsBusinessLogic, IStyleClassBusinessLogic, IChartsBusinessLogic
    {
        private UserBusinessLogic uBL;
        private DocumentBusinessLogic dBL;
        private AdminBusinessLogic aBL;
        private EditorBusinessLogic eBL;
        private FormatBusinessLogic fBL;
        private StyleClassBusinessLogic sBL;
        public Proxy()
        {
            uBL = new UserBusinessLogic();
            dBL = new DocumentBusinessLogic();
            aBL = new AdminBusinessLogic();
            eBL = new EditorBusinessLogic();
            fBL = new FormatBusinessLogic();
            sBL = new StyleClassBusinessLogic();
        }
        #region UserBL
        public Guid CreateADocument(Document doc, Guid tokenId)
        {
            AccessControl(tokenId);
            return uBL.CreateADocument(doc, tokenId);
        }

        public bool DeleteADocument(Document aDocument, Guid tokenId)
        {
            AccessControl(tokenId);
            return uBL.DeleteADocument(aDocument, tokenId);
        }
        public bool UpdateADocument(Guid id, Document aDocument, Guid tokenId)
        {
            AccessControl(tokenId);
            return uBL.UpdateADocument(id, aDocument, tokenId);
        }
        #endregion
        #region DocumentBL
        public IEnumerable<Document> GetAllDocuments(Guid tokenId)
        {
            AccessControl(tokenId);
            return dBL.GetAllDocuments(tokenId);
        }
        public Document GetDocumentById(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return dBL.GetDocumentById(id, tokenId);
        }

        public Document GetFullDocument(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return dBL.GetFullDocument(id, tokenId);
        }

        public string PrintDocument(Document aDocument, Guid tokenId)
        {
            AccessControl(tokenId);
            return dBL.PrintDocument(aDocument, tokenId);
        }
        #endregion
        #region AdminBL
        public IEnumerable<AdminUser> GetAllAdmins(Guid tokenId)
        {
            AccessControl(tokenId);
            return aBL.GetAllAdmins(tokenId);
        }

        public AdminUser GetAdminByID(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return aBL.GetAdminByID(id, tokenId);
        }

        public Guid AddAdmin(AdminUser admin, Guid tokenId)
        {
            AccessControl(tokenId);
            return aBL.AddAdmin(admin, tokenId);
        }

        public Guid AddEditor(EditorUser editor, Guid tokenId)
        {
            AccessControl(tokenId);
            return aBL.AddEditor(editor, tokenId);
        }

        public bool DeleteAdmin(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return aBL.DeleteAdmin(id, tokenId);
        }

        public bool DeleteAdmin(User user, Guid tokenId)
        {
            AccessControl(tokenId);
            return aBL.DeleteAdmin(user, tokenId);
        }

        public bool UpdateAdmin(Guid id, AdminUser newAdmin, Guid tokenId)
        {
            AccessControl(tokenId);
            return aBL.UpdateAdmin(id, newAdmin, tokenId);
        }
        #endregion
        #region EditorBL
        public IEnumerable<EditorUser> GetAllEditors(Guid tokenId)
        {
            AccessControl(tokenId);
            return eBL.GetAllEditors(tokenId);
        }

        public EditorUser GetEditorByID(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return eBL.GetEditorByID(id, tokenId);
        }

        public bool UpdateEditor(Guid id, EditorUser newEditor, Guid tokenId)
        {
            AccessControl(tokenId);
            return eBL.UpdateEditor(id, newEditor, tokenId);
        }
        public bool DeleteEditor(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return eBL.DeleteEditor(id, tokenId);
        }
        #endregion
        #region FormatBL
        public IEnumerable<Format> GetAllFormats(Guid tokenId)
        {
            AccessControl(tokenId);
            return fBL.GetAllFormats(tokenId);
        }

        public Format GetFormatByID(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return fBL.GetFormatByID(id, tokenId);
        }

        public Guid AddFormat(Format format, Guid tokenId)
        {
            AccessControl(tokenId);
            return fBL.AddFormat(format, tokenId);
        }

        public bool UpdateFormat(Guid id, Format newFormat, Guid tokenId)
        {
            AccessControl(tokenId);
            return fBL.UpdateFormat(id, newFormat, tokenId);
        }
        public bool DeleteFormat(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return fBL.DeleteFormat(id, tokenId);
        }
        #endregion
        #region styleBL
        public IEnumerable<StyleClass> GetAllStyleClasses(Guid tokenId)
        {
            AccessControl(tokenId);
            return sBL.GetAllStyleClasses(tokenId);
        }

        public StyleClass GetStyleById(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return sBL.GetStyleById(id,tokenId);
        }

        public Guid AddStyle(StyleClass style, Guid tokenId)
        {
            AccessControl(tokenId);
            return sBL.AddStyle(style,tokenId);
        }

        public bool DeleteStyle(Guid id, Guid tokenId)
        {
            AccessControl(tokenId);
            return sBL.DeleteStyle(id,tokenId);
        }

        public bool UpdateStyle(Guid id, StyleClass newStyle, Guid tokenId)
        {
            AccessControl(tokenId);
            return sBL.UpdateStyle(id, newStyle, tokenId);
        }
        #endregion
        #region Charts
        public ChartIntDate GetChartModificationsByUser(User user, DateTime since, DateTime until, Guid tokenId) {
            AccessControl(tokenId);
            return aBL.GetChartModificationsByUser(user, since, until, tokenId);
        }
        public ChartIntDate GetChartCreationByUser(User user, DateTime since, DateTime until, Guid tokenId) {
            AccessControl(tokenId);
            return aBL.GetChartCreationByUser(user, since, until, tokenId);
        }
        #endregion
        public void AccessControl(Guid tokenId)
        {
            User responsibleUser = uBL.GetUserByToken(tokenId);
            //throw exceptions here
        }
        public Guid LogIn(string username, string password) {
            return uBL.LogIn(username, password);
        }
        public void LogOut(Guid token) {
            uBL.LogOut(token);
        }



    }
}
