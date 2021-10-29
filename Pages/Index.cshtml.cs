using CarFleetManager;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public double Data => RabbitReceiver.lastValue;
    
}