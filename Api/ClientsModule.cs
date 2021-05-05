using Api.Models;
using Api.Repository;
using log4net;
using Nancy;
using Nancy.Extensions;
using Newtonsoft.Json;

namespace Api
{
    public class ClientsModule : NancyModule
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ClientsModule));

        private readonly IClientRepository _clientRepository;

        public ClientsModule(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Get["/clients"] = _ =>
            {
                _logger.Info("GET /clients");

                return JsonConvert.SerializeObject(_clientRepository.GetAllClients());
            };

            Get["/clients/{id}"] = parameters =>
            {
                var id = parameters["id"];

                _logger.Info($"GET /clients/{id}");

                return _clientRepository.GetClient(id) ?? HttpStatusCode.NoContent;
            };

            Post["/clients"] = _ =>
            {
                var requestBody = Request.Body.AsString();

                _logger.Info($"POST /clients/{requestBody}");

                var client = JsonConvert.DeserializeObject<Client>(requestBody);
                _clientRepository.AddClient(client);

                return HttpStatusCode.OK;
            };

            Delete["/clients/{id}"] = parameters =>
            {
                var id = parameters["id"];

                _logger.Info($"DELETE /clients/{id}");

                _clientRepository.DeleteClient(id);

                return HttpStatusCode.OK;
            };

            Put["/clients/{id}"] = parameters =>
            {
                var id = parameters["id"];
                var requestBody = Request.Body.AsString();
                var client = JsonConvert.DeserializeObject<Client>(requestBody);

                _logger.Info($"PUT /clients/{id} | {requestBody}");

                _clientRepository.UpdateClient(id, client);

                return HttpStatusCode.OK;
            };
        }
    }
}