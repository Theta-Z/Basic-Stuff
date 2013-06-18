package templerewards;

import org.bukkit.Bukkit;
import org.bukkit.entity.Player;

/**
 *
 * @author Seobi-TAZS_C
 */
public class Messenger
{
  public static void send(Player p, String msg)
  {
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " " + msg);
  }
}
