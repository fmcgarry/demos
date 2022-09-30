using System.ComponentModel.DataAnnotations;

namespace azure_cosmosdb_demo.Models
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "";
        public DateTime DueDate { get; set; } = DateTime.Now;
        public bool IsDone { get; set; } = false;
    }
}
