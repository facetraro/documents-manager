using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsManager.ProxyInterfaces;
using DocumentsManager.BusinessLogic.Charts;

namespace DocumentsManager.BusinessLogic
{
    public class AdminBusinessLogic : UserBusinessLogic, IAdminsBusinessLogic, IChartsBusinessLogic
    {
        public User LogInWithoutToken(string username, string password)
        {
            User user = AuthenticateUser(username, password);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public void LogInWinApp(string username, string password)
        {
            User user = LogInWithoutToken(username, password);
            if (user != null)
            {
                if (user is AdminUser)
                {
                    return;
                }
                throw new UserNotAuthorizedException();
            }
        }
        public ChartIntDate GetChartModificationsByUser(User user, DateTime since, DateTime until, Guid tokenId)
        {
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            return GetChartFromDates(GetDatesFromModifyDocument(user, null), since, until);
        }
        public ChartIntDate GetChartCreationByUser(User user, DateTime since, DateTime until, Guid tokenId)
        {
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            return GetChartFromDates(GetDatesFromModifyDocument(user, ModifyState.Added), since, until);
        }
        public List<DateTime> GetDatesFromModifyDocument(User user, object state)
        {
            List<DateTime> allDates = new List<DateTime>();
            ModifyDocumentHistoryContext contextModify = new ModifyDocumentHistoryContext();
            foreach (var item in contextModify.GetAllHistories())
            {
                bool validation;
                try
                {
                    ModifyState status = (ModifyState)state;
                    validation = item.User.Equals(user) && item.State == status;
                }
                catch
                {
                    validation = item.User.Equals(user);
                }
                if (validation)
                {
                    allDates.Add(item.Date);
                }
            }
            return allDates;
        }
        private void AddRegisterByDate(List<DateTime> histories, ChartIntDate chart)
        {
            foreach (var item in histories)
            {
                chart.AddValueToDate(item);
            }
        }
        public ChartIntDate GetChartFromDates(List<DateTime> histories, DateTime since, DateTime until)
        {
            ChartIntDate chart = new ChartIntDate();
            chart.GenerateDates(since, until);
            AddRegisterByDate(histories, chart);
            return chart;
        }
        public Guid AddAdmin(AdminUser newAdmin, Guid tokenId)
        {
            newAdmin.Id = Guid.NewGuid();
            UserContext userContext = new UserContext();
            if (IdRegistered(newAdmin))
            {
                throw new ObjectAlreadyExistsException("Id");
            }
            if (EmailRegistered(newAdmin))
            {
                throw new ObjectAlreadyExistsException("email");
            }
            if (UserNameRegistered(newAdmin))
            {
                throw new ObjectAlreadyExistsException("username");
            }
            userContext.Add(newAdmin);
            return newAdmin.Id;
        }

        public bool DeleteAdmin(Guid id, Guid tokenId)
        {
            UserContext uContext = new UserContext();
            AdminUser idUser = new AdminUser();
            idUser.Id = id;
            if (uContext.Exists(idUser))
            {
                return uContext.Remove(id);
            }
            throw new ObjectDoesNotExists(idUser);
        }

        public IEnumerable<AdminUser> GetAllAdmins(Guid tokenId)
        {
            UserContext uContext = new UserContext();
            return uContext.GetAdmins();
        }

        public AdminUser GetAdminByID(Guid id, Guid tokenId)
        {
            AdminUser userToReturn = new AdminUser();
            UserContext uContext = new UserContext();
            User userToVerify = uContext.GetById(id);
            if (userToVerify is EditorUser)
            {
                throw new WrongUserType(userToReturn);
            }
            userToReturn = userToVerify as AdminUser;
            if (userToReturn == null)
            {
                throw new ObjectDoesNotExists(new EditorUser());
            }
            return userToReturn;
        }

        public bool UpdateAdmin(Guid id, AdminUser newAdmin, Guid tokenId)
        {
            UserContext uContext = new UserContext();
            bool updated = false;
            if (!uContext.Exists(newAdmin))
            {
                throw new ObjectDoesNotExists(newAdmin);
            }
            updated = uContext.Modify(newAdmin);
            User dbUser = GetAdminByID(id, Guid.NewGuid());
            if (!dbUser.hasSameInformation(newAdmin))
            {
                updated = false;
            }
            return updated;
        }

        public Guid AddEditor(EditorUser user, Guid tokenId)
        {
            EditorBusinessLogic logic = new EditorBusinessLogic();
            return logic.AddEditor(user, tokenId);
        }

        public bool DeleteAdmin(User user, Guid tokenId)
        {
            return DeleteAdmin(user.Id, tokenId);
        }
    }
}
