package protectivemama;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.event.EventHandler;
import org.bukkit.event.EventPriority;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerItemHeldEvent;
import org.bukkit.inventory.ItemStack;
import templerewards.Messenger;

/**
 *
 * @author Seobi-TAZS_C
 */
public class WatchDog implements Listener
{
  Material[] bannedItems;
  private int slot;
  private ItemStack item;
  
  public void reload()
  {
    List<Material> ban = new ArrayList<Material>();
    
    File bannedItems = new File("plugins" + File.separator + "WatchDog" + 
                                 File.separator + "bannedItems.info");
    
    if(!bannedItems.exists())
    {
      try
      {
        bannedItems.createNewFile();
      }
      catch (IOException ex)
      {
        Logger.getLogger("Minecraft").info("[PM] IO EXCEPTION 0x3");
      }
    }
    
    try
    {
      Scanner scan = new Scanner(bannedItems);
      while(scan.hasNextLine())
        ban.add(Material.getMaterial(scan.nextLine()));
      
      scan.close();
    }
    catch(Exception e)
    {
      Logger.getLogger("Minecraft").info("[PM] IO EXCEPTION 0x4");
    }
    
    this.bannedItems = new Material[ban.size()];
    
    for(int i = 0; i < ban.size(); i++)
      this.bannedItems[i] = ban.get(i);
    
    ban.clear();
    Runtime.getRuntime().gc();
  }
  
  public void WatchDog()
  {
    reload();
  }
  
  @EventHandler(priority  = EventPriority.HIGHEST)
  public void onPlayerItemSwitch(PlayerItemHeldEvent e)
  {
    slot = e.getNewSlot();
    item = e.getPlayer().getInventory().getItem(slot);
    
    if(item == null)
      return;
    
    if(bannedItems == null)
      reload();
    
    for(int i = 0; i < bannedItems.length; i++)
    {
      if(item.getType().name().equals(bannedItems[i].name()))
      {
        e.getPlayer().getInventory().clear(slot);
        e.getPlayer().updateInventory();
        //Messenger.send(e.getPlayer(), "We don't allow " + bannedItems[i].name() + " on the server.");
        e.getPlayer().sendMessage(ChatColor.AQUA + "[Protective Mama]" + ChatColor.RED + 
                " We don't allow " + bannedItems[i].name() + " on the server.");
      }
    }//:for[i]
  }
}
