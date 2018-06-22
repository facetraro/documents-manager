using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Dtos
{
    public class LogInDto
    {
        public Guid Id { get; set; }
        public string Role { get; set; }

        public LogInDto()
        {
            Id = new Guid();
            Role = "";
        }
    }
}
