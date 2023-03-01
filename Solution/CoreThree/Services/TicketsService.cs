using CoreThree.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CoreThree.Services
{
   public class TicketsService
   {
      private readonly IMongoCollection<Ticket> _ticketCollection;

      public TicketsService(
          IOptions<TicketDatabaseSettings> ticketDatabaseSettings)
      {
         var mongoClient = new MongoClient(
             ticketDatabaseSettings.Value.ConnectionString);

         var mongoDatabase = mongoClient.GetDatabase(
             ticketDatabaseSettings.Value.DatabaseName);

         _ticketCollection = mongoDatabase.GetCollection<Ticket>(
             ticketDatabaseSettings.Value.TicketCollectionName);
      }

      public async Task<List<Ticket>> GetAsync() =>
          await _ticketCollection.Find(_ => true).ToListAsync();

      public async Task<Ticket?> GetAsync(string id) =>
          await _ticketCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

      public async Task CreateAsync(Ticket newBook) =>
          await _ticketCollection.InsertOneAsync(newBook);

      public async Task UpdateAsync(string id, Ticket updatedBook) =>
          await _ticketCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

      public async Task RemoveAsync(string id) =>
          await _ticketCollection.DeleteOneAsync(x => x.Id == id);
   }
}
