using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Library.Entities.Dtos.User
{
    public class UpdatedUserDto : UpdateUserDto
    {
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
