using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Cosmos;

namespace azure_cosmosdb_demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CosmosClient _cosmosClient;
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public IndexModel(ILogger<IndexModel> logger, CosmosClient cosmosClient)
        {
            _logger = logger;
            _cosmosClient = cosmosClient;

            _container = _cosmosClient.GetContainer("ToDoList", "Items");
        }

        public void OnGet()
        {

        }
    }
}