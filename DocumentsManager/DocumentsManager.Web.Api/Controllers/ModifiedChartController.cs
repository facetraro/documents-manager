using DocumentsManager.Exceptions;
using DocumentsManager.ProxyAcces;
using DocumentsMangerEntities;
using DocumentsManager.Dtos;
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
        public IHttpActionResult Get(Guid Id, string dateOne, string dateTwo, Guid token)
        {
            DateTime dateFrom = new DateTime();
            DateTime dateTo = new DateTime();
            try
            {
                dateFrom = DateTime.Parse(dateOne);
                dateTo = DateTime.Parse(dateTwo);
            }
            catch (Exception)
            {
                BadRequest("Los formatos para las fechas no son validos");
            }
            User user = new AdminUser();
            try
            {
                user = proxyAccess.GetAdminByID(Id, token);
            }
            catch (WrongUserType ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ObjectDoesNotExists ex) {
                return BadRequest(ex.Message);
            }
            var chart = proxyAccess.GetChartModificationsByUser(user, dateFrom, dateTo, token);
            return Ok(new ChartDto(chart));
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
