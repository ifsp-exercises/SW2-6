namespace Command.Data
{
  public interface ICommandDatabaseSettings
  {
    string BooksCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}