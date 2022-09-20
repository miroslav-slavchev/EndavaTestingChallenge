using Reqres.Library.Entities.Dtos.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Tests.APICLient.Controllers
{
    public class EntityControllerClient
    {
        public AppUrl BaseUrl { get; private set; }

        public string EntityPluralName { get; private set; }

        public EntityControllerClient(AppUrl baseUrl, string entityPluralName)
        {
            BaseUrl = baseUrl;
            EntityPluralName = entityPluralName;
        }

        public string GetItemsUrl(int? page = null)
        {
            if (page == null)
            {
                return FullUrl;
            }
            else
            {
                return ItemsOnPageUrl((int)page);
            }
        }

        public string FullUrl => $"{BaseUrl.FullUrl}{EntityPluralName}";

        public string ItemByIdUrl(int id)
        {
            return $"{FullUrl}/{id}";
        }

        public string ItemsOnPageUrl(int page)
        {
            return $"{FullUrl}?page={page}";
        }
    }
}
