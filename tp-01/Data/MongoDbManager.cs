using System;
using Command.Entities;
using MongoDB.Driver;

namespace Command.Data
{
  public class MongoDbManager : IDisposable
  {
    private bool disposed;
    private static MongoClient _mongoClient;
    private IMongoDatabase GetDatabase() => GetClient().GetDatabase("command_database");

    private MongoClient GetClient()
    {
      if (MongoDbManager._mongoClient is null)
        CreateClient();

      return MongoDbManager._mongoClient;
    }

    private void CreateClient()
    {
      MongoDbManager._mongoClient = new MongoClient(
        "mongodb://docker:DockerMongo127!@localhost:27017/?authSource=admin"
      );
    }

    public IMongoCollection<Book> Books { get => GetDatabase().GetCollection<Book>("books"); }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        if (disposing)
        {
          //dispose managed resources
        }
      }
      
      //dispose unmanaged resources
      disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}