package templerewards;

import java.util.HashMap;
import org.bukkit.Bukkit;
import org.bukkit.ChatColor;
import org.bukkit.Location;
import org.bukkit.World;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.EventPriority;
import org.bukkit.event.Listener;
import org.bukkit.event.entity.PlayerDeathEvent;
import org.bukkit.event.player.PlayerJoinEvent;

/**
 *
 * @author Seobi-TAZS_C
 */
public class DeathTracker implements Listener
{
  private HashMap died;
  //Location diedAt;
  
  public DeathTracker()
  {
    died = new HashMap();
  }
  
  public Location diedAt(CommandSender cs)
  {
    if(cs.getName().toLowerCase().contains(("console")))
      return new Location(Bukkit.getWorlds().get(0),1.0,1.0,1.0);
    
    return (Location)died.get((Player)cs);
  }
  
  @EventHandler(priority = EventPriority.HIGHEST)
  public void onPlayerDeath(PlayerDeathEvent e)
  {
    e.getEntity().sendMessage("You died at: [ X: " + ((int)e.getEntity().getLocation().getX())   +
                                            ",  Y: " + ((int)e.getEntity().getLocation().getY()) +
                                            ",  Z: " + ((int)e.getEntity().getLocation().getZ()) + " ].");
    
    e.getEntity().sendMessage("Type /goback to get back to where you were!");
    
    if(died.containsKey(e.getEntity()))
    {
      died.remove(e.getEntity());
      died.put(e.getEntity(), e.getEntity().getLocation());
    }
    
    //diedAt = e.getEntity().getLocation();
  }
  
  @EventHandler(priority  = EventPriority.HIGH)
  public void onPlayerJoin(PlayerJoinEvent e)
  {
    if(died.containsKey(e.getPlayer()))
    {
      died.remove(e.getPlayer());
      died.put(e.getPlayer(), e.getPlayer().getLocation());
    }
    
    //diedAt = e.getPlayer().getLocation();
    e.getPlayer().sendMessage(ChatColor.LIGHT_PURPLE + "Welcome back to the server, " + e.getPlayer().getDisplayName() + "!");
    
    if(e.getPlayer().isOp())
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "say A server Op/Admin is now online.");
  }
}
