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
    public class CreatorsChartController : ApiController
    {
        private Proxy proxyAccess;
        public CreatorsChartController()
        {
            this.proxyAccess = new Proxy();
        }
        // GET: api/CreatorsChart
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        [HttpGet]
        [Route("CreatorsChart")]
        // GET: api/CreatorsChart/5
        public string Get(Guid Id, string dateOne, string dateTwo, Guid token)
        {
            DateTime dateFrom = DateTime.Parse(dateOne);
            DateTime dateTo = DateTime.Parse(dateTwo);
            User user = new AdminUser();
            try
            {
                user = proxyAccess.GetAdminByID(Id,token);
            }
            catch (WrongUserType)
            {

                user = proxyAccess.GetEditorByID(Id, token);
            }
            catch (ObjectDoesNotExists ex)
            {
                return ex.Message;
            }

            return proxyAccess.GetChartCreationByUser(user, dateFrom, dateTo, token).ToString();
        }

        // POST: api/CreatorsChart
        public IHttpActionResult Post([FromBody]string value)
        {
            return NotFound();
        }

        // PUT: api/CreatorsChart/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/CreatorsChart/5
        public IHttpActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
