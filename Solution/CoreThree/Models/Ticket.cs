using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoreThree.Models
{
   public class Ticket
   {
      [BsonId]
      [BsonRepresentation(BsonType.ObjectId)]
      public string? Id { get; set; }

      [BsonElement("Name")]
      public string TicketName { get; set; } = null!;

      public string? type { get; set; }

      public DateTime? Depart { get; set; } = null!;

      public DateTime?  ETA               { get; set; } = null!;
      public string?    CarrierId         { get; set; } = null!;
      public string?    Start_node        { get; set; } = null!;
      public string?    End_node          { get; set; } = null!;
      public string?    route             { get; set; } = null!;
      public decimal?   price             { get; set; } = null!;
      public string?    Currency          { get; set; } = null!;
      public string?    Status            { get; set; } = null!;
      public string?    Agency            { get; set; } = null!;
      public string?    Agent             { get; set; } = null!;
      public string?    CustomerId        { get; set; } = null!;
      public string?    DocumentStatus    { get; set; } = null!;
      public string?    SpecialRequirements{get; set; } = null!;
      public string?    Notes             { get; set; } = null!;
      public string?    Luggage           { get; set; } = null!;
   }
}
