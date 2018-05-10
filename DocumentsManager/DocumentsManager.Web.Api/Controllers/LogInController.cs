using DocumentsManager.BusinessLogic;
using DocumentsManager.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentsManager.Web.Api.Controllers
{
    public class LogInController : ApiController
    {
        private UserBusinessLogic logic;
        public LogInController() {
            logic = new UserBusinessLogic();
        }
        // GET: api/LogIn
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        // GET: api/LogIn/5
        public IHttpActionResult Get(int id)
        {
            return NotFound();
        }

        // POST: api/LogIn
        public void Post(string username,[FromBody]LogInModel model)
        {
            Guid token = logic.LogIn(username, model.Password);
            LoggedToken.SetToken(token);
        }

        // PUT: api/LogIn/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LogIn/5
        public void Delete(int id)
        {
        }
    }
}
