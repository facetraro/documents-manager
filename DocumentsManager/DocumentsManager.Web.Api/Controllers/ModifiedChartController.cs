using DocumentsManager.Exceptions;
using DocumentsManager.ProxyAcces;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentsManager.Web.Api.Controllers
{
    public class ModifiedChartController : ApiController
    {
        private Proxy proxyAccess  { get; set; }
        public ModifiedChartController()
        {
            this.proxyAccess = new Proxy();
        }
        // GET: api/ModifiedChart
        public IHttpActionResult Get()
        {
            return NotFound();
        }
        [HttpGet]
        [Route("ModifiersChart")]
        // GET: api/ModifiedChart/5
        public string Get(Guid Id, string dateOne, string dateTwo, Guid token)
        {
            DateTime dateFrom =DateTime.Parse(dateOne);
            DateTime dateTo = DateTime.Parse(dateTwo);
            User user = new AdminUser();
            try
            {
                user = proxyAccess.GetAdminByID(Id, token);
            }
            catch (WrongUserType)
            {
                user = proxyAccess.GetEditorByID(Id, token);
            }
            catch (ObjectDoesNotExists ex) {
                return ex.Message;
            }
            return proxyAccess.GetChartModificationsByUser(user, dateFrom, dateTo, token).ToString();
        }

        // POST: api/ModifiedChart
        public IHttpActionResult Post([FromBody]string value)
        {
            return NotFound();
        }

        // PUT: api/ModifiedChart/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/ModifiedChart/5
        public IHttpActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
