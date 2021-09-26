namespace Command.Data
{
  public class CommandDatabaseSettings : ICommandDatabaseSettings
  {
    public string BooksCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }
}