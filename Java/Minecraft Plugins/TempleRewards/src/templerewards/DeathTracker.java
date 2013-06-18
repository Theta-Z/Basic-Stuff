package templerewards;

import org.bukkit.ChatColor;
import org.bukkit.Location;
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
  Location diedAt;
  
  @EventHandler(priority = EventPriority.HIGHEST)
  public void onEntityDeath(PlayerDeathEvent e)
  {
    e.getEntity().sendMessage("You died at: [ X: " + ((int)e.getEntity().getLocation().getX())   +
                                            ",  Y: " + ((int)e.getEntity().getLocation().getY()) +
                                            ",  Z: " + ((int)e.getEntity().getLocation().getZ()) + " ].");
    
    e.getEntity().sendMessage("Type /goback to get back to where you were!");
    
    diedAt = e.getEntity().getLocation();
  }
  
  @EventHandler(priority  = EventPriority.HIGH)
  public void onPlayerJoin(PlayerJoinEvent e)
  {
    diedAt = e.getPlayer().getLocation();
    e.getPlayer().sendMessage(ChatColor.LIGHT_PURPLE + "Welcome back to the server, " + e.getPlayer().getDisplayName() + "!");
  }
}
