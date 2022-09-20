using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Library.Entities.Dtos.User
{
    public class CreatedUserDto : CreateUserDto
    {
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
