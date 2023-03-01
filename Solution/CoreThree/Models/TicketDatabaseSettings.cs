namespace CoreThree.Models
{
   public class TicketDatabaseSettings
   {
      public string ConnectionString { get; set; } = null!;

      public string DatabaseName { get; set; } = null!;

      public string TicketCollectionName { get; set; } = null!;
   }
}
