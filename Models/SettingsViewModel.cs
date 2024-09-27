using System.ComponentModel.DataAnnotations;

namespace khedmatrack.Models;
public class SettingsViewModel
{
  public AccountUpdate? CurrentAccount { get; set; }
  public TransferViewModel? TransferModel { get; set; }
}
