using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsApp.Logging;
using SportsApp.Repository;
using SportsApp.Service;

namespace SportsApp
{
    public class SportsFunction
    {
        private readonly MyLogger _logger;
        private readonly ContextService _contextService;
        private readonly TeamsRepository _repository;
        private readonly IServiceProvider _serviceProvider;

        public SportsFunction(MyLogger logger,
                                ContextService contextService,
                                TeamsRepository repository,
                                IServiceProvider serviceProvider)
        {
            _logger = logger;
            _contextService = contextService;
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        [Function("teams")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "teams/{city:alpha?}")] HttpRequest req, string city)
        {
            _logger.LogInfo($"city={city}, CorrelationId={_contextService.CorrelationId}");

            using (var scope = _serviceProvider.CreateScope()) {
                TeamsRepository repo = scope.ServiceProvider.GetRequiredService<TeamsRepository>();
                return new OkObjectResult(repo.Read(city));
            }
        }
    }
}
