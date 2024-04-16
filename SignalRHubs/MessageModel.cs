namespace Northwind.Chat.Models;

public class MessageModel
{
  public string From { get; set; } = null!;
  public string To { get; set; } = null!;
  public Object? Body { get; set; }
}
