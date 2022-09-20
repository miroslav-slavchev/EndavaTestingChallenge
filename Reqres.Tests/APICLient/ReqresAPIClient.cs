using Newtonsoft.Json;
using Reqres.Library.Entities.Dtos;
using Reqres.Library.Entities.Dtos.User;
using Reqres.Tests.APICLient.Controllers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Tests.APICLient
{
    public class ReqresAPIClient : RestClient
    {
        protected AppUrl AppUrl { get; private set; }

        public ReqresAPIClient(AppUrl appUrl) : base(appUrl.FullUrl)
        {
            AppUrl = appUrl;
        }

        public EntityCrudFacade<UserDataDto, CreateUserDto, CreatedUserDto, UpdateUserDto, UpdatedUserDto> Users => new(GetEntityControllerClient(nameof(Users)));

        private EntityControllerClient GetEntityControllerClient(string name) => new(AppUrl, name.ToLower());

    }

    public class EntityCrudFacade
        <GetDto,
        CreateDto,
        CreatedDto,
        UpdateDto,
        UpdatedDto> : ReqresAPIClient
        where GetDto : class
        where CreateDto : class
        where CreatedDto : class
        where UpdateDto : class
        where UpdatedDto : class
    {
        private EntityControllerClient EntityControllerClient { get; }

        public EntityCrudFacade(EntityControllerClient entityControllerClient) : base(entityControllerClient.BaseUrl)
        {
            EntityControllerClient = entityControllerClient;
        }

        public ReqresRestResponse<CreatedDto> Add(CreateDto createUserDto)
        {
            RestRequest restRequest = new RestRequest(EntityControllerClient.FullUrl);
            restRequest.AddObject(createUserDto);
            RestResponse response = this.Post(restRequest);
            return new(response);
        }

        public ReqresRestResponse<ReqresMultipleDto<GetDto>> GetAllOnPage(int page)
        {
            RestRequest restRequest = new(EntityControllerClient.ItemsOnPageUrl(page));
            RestResponse restResponse = this.Get(restRequest);
            return new(restResponse);
        }
        public ReqresRestResponse<ReqresMultipleDto<GetDto>> GetAll(int? page = null)
        {
            RestRequest restRequest;
            if (page == null)
            {
                restRequest = new(EntityControllerClient.FullUrl);
            }
            else
            {
                restRequest = new(EntityControllerClient.ItemsOnPageUrl((int)page));
            }

            RestResponse restResponse = this.Get(restRequest);
            return new(restResponse);
        }

        public ReqresRestResponse<ReqresSingleDto<GetDto>> GetSingle(int id)
        {
            RestRequest restRequest = new(EntityControllerClient.ItemByIdUrl(id));
            RestResponse restResponse = this.Get(restRequest);
            return new(restResponse);
        }

        public ReqresRestResponse<UpdatedDto> FullyUpdate(int id, UpdateDto putUserDto)
        {
            RestRequest restRequest = new(EntityControllerClient.ItemByIdUrl(id));
            restRequest.AddObject(putUserDto);
            RestResponse restResponse = this.Put(restRequest);
            return new(restResponse);
        }

        public ReqresRestResponse<UpdatedDto> PartiallyUpdate(int id, UpdateDto patchUserDto)
        {
            RestRequest restRequest = new(EntityControllerClient.ItemByIdUrl(id));
            string obj = JsonConvert.SerializeObject(patchUserDto, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            restRequest.AddObject(obj);
            RestResponse restResponse = this.Patch(restRequest);
            return new(restResponse);
        }

        public RestResponse Remove(int id)
        {
            RestRequest restRequest = new(EntityControllerClient.ItemByIdUrl(id));
            RestResponse restResponse = this.Delete(restRequest);
            return restResponse;
        }
    }
}
