using DocumentsManager.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentsManager.Web.Api.Controllers
{
    public class LogOutController : ApiController
    {
        private UserBusinessLogic logic;
        public LogOutController()
        {
            logic = new UserBusinessLogic();
        }
        // GET: api/LogOut
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LogOut/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LogOut
        public void Post()
        {
            Guid token = LoggedToken.GetToken();
            LoggedToken.DeleteToken();
            logic.LogOut(token);

        }

        // PUT: api/LogOut/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LogOut/5
        public void Delete(int id)
        {
        }
    }
}
