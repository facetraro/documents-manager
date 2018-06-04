using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;

namespace DocumentsManager.BusinessLogic
{
    public class AdminBusinessLogic : UserBusinessLogic, IAdminsBusinessLogic
    {
        public bool LogInWithoutToken(string username, string password)
        {
            if (AuthenticateUser(username, password) != null)
            {
                return true;
            }
            return false;
        }
        private void ValidateAuthorizations()
        {
            Guid Token = LoggedToken.GetToken();
            if (!(GetUserByToken(Token) is AdminUser))
            {
                throw new UserNotAuthorizedException();
            }
        }
        public ChartIntDate GetChartModificationsByUser(User user, DateTime since, DateTime until)
        {
            ValidateAuthorizations();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            return GetChartFromDates(GetDatesFromModifyDocument(user, null), since, until);
        }
        public ChartIntDate GetChartCreationByUser(User user, DateTime since, DateTime until)
        {
            ValidateAuthorizations();
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
        public Guid Add(AdminUser newAdmin)
        {
            ValidateAuthorizations();
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

        public bool Delete(Guid id)
        {
            ValidateAuthorizations();
            if (id.Equals(GetUserByToken(LoggedToken.GetToken())))
            {
                throw new CantDeleteLoggedUserException();
            }
            UserContext uContext = new UserContext();
            AdminUser idUser = new AdminUser();
            idUser.Id = id;
            if (uContext.Exists(idUser))
            {
                return uContext.Remove(id);
            }
            throw new ObjectDoesNotExists(idUser);
        }

        public IEnumerable<AdminUser> GetAllAdmins()
        {
            ValidateAuthorizations();
            UserContext uContext = new UserContext();
            return uContext.GetAdmins();
        }

        public AdminUser GetByID(Guid id)
        {
            ValidateAuthorizations();
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

        public bool Update(Guid id, AdminUser newAdmin)
        {
            ValidateAuthorizations();
            UserContext uContext = new UserContext();
            bool updated = false;
            if (!uContext.Exists(newAdmin))
            {
                throw new ObjectDoesNotExists(newAdmin);
            }
            updated = uContext.Modify(newAdmin);
            User dbUser = GetByID(id);
            if (!dbUser.hasSameInformation(newAdmin))
            {
                updated = false;
            }
            return updated;
        }

        public Guid Add(EditorUser user)
        {
            ValidateAuthorizations();
            EditorBusinessLogic logic = new EditorBusinessLogic();
            return logic.Add(user);
        }

        public bool Delete(User user)
        {
            ValidateAuthorizations();
            return Delete(user.Id);
        }
    }
}
