using DocumentsManager.Dtos;
using DocumentsManager.Exceptions;
using DocumentsManager.ProxyAcces;
using DocumentsManager.Web.Api.Models;
using DocumentsMangerEntities;
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
        private Proxy proxyAccess;
        public LogInController()
        {
            proxyAccess = new Proxy();
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
        public IHttpActionResult Post(string username, [FromBody]LogInModel model)
        {
            try
            {
                Guid token = proxyAccess.LogIn(username, model.Password);
                LogInDto newLogIn = new LogInDto();
                newLogIn.Id = token;
                User userLogged = proxyAccess.GetUserByToken(token);
                if (userLogged is AdminUser)
                {
                    newLogIn.Role = "Admin";
                }
                else
                {
                    newLogIn.Role = "Editor";
                }
                return Ok(newLogIn);
            }
            catch (LostConnectionWithDataBase exception)
            {
                return BadRequest(exception.Message);
            }
            catch (UserAlreadyLogged alreadyLogged)
            {
                return BadRequest(alreadyLogged.Message);
            }
            catch (InvalidCredentialException credentialsException)
            {
                return BadRequest(credentialsException.Message);
            }
        }

        // PUT: api/LogIn/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/LogIn/5
        public IHttpActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
