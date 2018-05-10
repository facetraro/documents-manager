﻿using DocumentsManager.BusinessLogic;
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
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        // GET: api/LogOut/5
        public IHttpActionResult Get(int id)
        {
            return NotFound();
        }

        // POST: api/LogOut
        public IHttpActionResult Post()
        {
            Guid token = LoggedToken.GetToken();
            LoggedToken.DeleteToken();
            logic.LogOut(token);
            return Ok(200);
        }

        // PUT: api/LogOut/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/LogOut/5
        public IHttpActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}