using DocumentsManager.BusinessLogic;
using DocumentsManager.Exceptions;
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
        private AdminBusinessLogic adminsBuisnessLogic { get; set; }
        private EditorBusinessLogic editorBuisnessLogic { get; set; }
        private UserBusinessLogic usersBuisnessLogic { get; set; }
        public ModifiedChartController()
        {
            this.adminsBuisnessLogic = new AdminBusinessLogic();
            this.usersBuisnessLogic = new UserBusinessLogic();
            this.editorBuisnessLogic = new EditorBusinessLogic();
        }
        // GET: api/ModifiedChart
        public IHttpActionResult Get()
        {
            return NotFound();
        }
        [HttpGet]
        [Route("ModifiersChart")]
        // GET: api/ModifiedChart/5
        public string Get(Guid Id, string dateOne, string dateTwo)
        {
            DateTime dateFrom =DateTime.Parse(dateOne);
            DateTime dateTo = DateTime.Parse(dateTwo);
            User user = new AdminUser();
            try
            {
                user = adminsBuisnessLogic.GetByID(Id);
            }
            catch (WrongUserType)
            {

                user = editorBuisnessLogic.GetByID(Id);
            }
            catch (ObjectDoesNotExists ex) {
                return ex.Message;
            }

            return adminsBuisnessLogic.GetChartModificationsByUser(user, dateFrom, dateTo).ToString();
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
