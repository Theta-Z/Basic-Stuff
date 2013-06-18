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
public class Teleporter
{
  public static boolean Main(CommandSender cs, String playerName)
  {     
    if(cs.getName().toLowerCase().equals("console"))
      return true;
    
    Player p1 = (Player)cs;
    Player p2 = Bukkit.getPlayerExact(playerName);
    
    if(p2 == null)
    {
      Messenger.send(p1, playerName + " isn't a player on our server.");
      return true;
    }


    if(p2.isOnline())
      return Teleporter.teleportCost(p1, p2);
    else
      Messenger.send(p1, playerName + " isn't online... Sorry. :(");
    
    return true;
  }
  
  
  public static boolean teleportCost(Player p1, Player p2)
  {
    if(!Friends.areFriends(p1, p2))
    {
      Messenger.send(p1, "You aren't friends with " + p2.getName() + ".");
      
      Messenger.send(p2, p1.getName() + " tried to teleport to you. However, they aren't your friend." + 
                                        " So, I stopped them. You could... friend them by typing " + 
                                        "/friend " + p1.getName());
      
      return true;
    }
    
    
    if(!p1.getInventory().contains(Material.GOLD_NUGGET))
    {
      Messenger.send(p1, "You have no gold nuggets. Please get one to use the teleporter.");      
      Messenger.send(p2, "Your friend " + p1.getName() + " has no goldnuggets to teleport to you." + 
                                     " Perhaps gift them one? /gift " + p1.getName() + " goldnugget");

      return true;
    }
    
    //:nothing in life is free!
    int slot = p1.getInventory().first(Material.GOLD_NUGGET);
    ItemStack is = p1.getInventory().all(Material.GOLD_NUGGET).get(slot);
    is.setAmount(is.getAmount() - 1);
    
    p1.getInventory().setItem(slot, is);
    p1.updateInventory();
    
    p1.teleport(p2.getLocation());  
    
    Messenger.send(p1, "We have taken 1 gold nugget, and teleported you. Have a nice day.");
    
    return false;
  }
}
