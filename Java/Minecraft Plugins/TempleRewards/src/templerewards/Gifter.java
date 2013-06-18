package templerewards;

import org.bukkit.Bukkit;
import org.bukkit.Material;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;

/**
 *
 * @author Seobi-TAZS_C
 */
public class Gifter
{
  public static boolean help(Player p)
  {
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Thanks for your interest in Gifter, " + p.getName() + "!");
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Usage:/gift friendName itemName\nCurrent gifts are:");
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " goldnugget");
    return true;
  }
  
  public static boolean Main(CommandSender cs, String[] args)
  {
    Player p = (Player)cs;
    if(args[0].toLowerCase().contains("help"))
      return Gifter.help(p);
    
    if(args.length < 2)
    {
      Messenger.send(p, "Incorrect usage, see /gift help");
      return true;
    }

    Player p2 = Bukkit.getPlayerExact(args[0]);
    if(p2 == null)
    {
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " That name doesnt exist");
      return true;
    }

    if(p2.isOnline())
    {
      if(args[1].toLowerCase().contains("goldnugget"))
        return Gifter.gift(p, p2, Material.GOLD_NUGGET);

      Messenger.send(p, "We don't gift that... yet.");
      return true;
    }

    Messenger.send(p, "Player doesn't exist or is offline.");
    return true;
  }
  
  public static boolean gift(Player p1, Player p2, Material m)
  {
    if(!p1.getInventory().contains(m))
    {
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p1.getName() + " You have no " + m.name());
      return true;
    }
    
    if(p2.getInventory().firstEmpty() == -1)
    {
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p1.getName() + " Your friend has no inventory space.");
      return true;
    }
    
    int slot = p1.getInventory().first(m);
    ItemStack is = p1.getInventory().all(m).get(slot);
    is.setAmount(is.getAmount() - 1);
    
    p1.getInventory().setItem(slot, is);
    p2.getInventory().addItem(new ItemStack(m, 1));
    
    p1.updateInventory();
    p2.updateInventory();
    
    Messenger.send(p1, p2.getName() + " recieved your gift!");
    Messenger.send(p2, p1.getName() + " has sent you a " + m.name() + ".");
    
    return false;
  }
}
