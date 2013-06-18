package protectivemama;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.util.Scanner;
import java.util.logging.Logger;
import org.bukkit.Material;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import templerewards.Messenger;

/**
 *
 * @author Seobi-TAZS_C
 */
public class NonoList
{
  public static boolean banItem(CommandSender cs, String[] args)
  {
    if(args.length != 1)
    {
      Messenger.send((Player)cs, "Incorrect usage. Try: /banItem itemname");
      return true;
    }
    
    Material temp = Material.getMaterial(args[0].toUpperCase());
    
    if(temp == null)
    {
      Messenger.send((Player)cs, "Incorrect material name.");
      return true;
    }
    
    File bannedItems = new File("plugins" + File.separator + "WatchDog" + 
                                 File.separator + "bannedItems.info");
    
    try
    {
      String list = "", scn = "";
      Scanner scan = new Scanner(bannedItems);
      while(scan.hasNextLine())
      {
        if((scn = scan.nextLine()).toUpperCase().equals(args[0].toUpperCase()))
        {
          Messenger.send((Player)cs, "Item already banned");
          scan.close();
          return true;
        }
        list += scn + "\n";
      }
      
      scan.close();
      
      BufferedWriter bw = new BufferedWriter(new FileWriter(bannedItems));
      bw.write(list + args[0].toUpperCase() + "\n");
      bw.close();
    }
    catch(Exception e)
    {
      Logger.getLogger("Minecraft").info("[PM] IO EXCEPTION 0x1");
    }
    
    if(!cs.getName().toLowerCase().equals("console"))
      Messenger.send((Player)cs, "You have banned " + args[0]);
    
    return false;
  }
  
  public static boolean unbanItem(CommandSender cs, String[] args)
  {
    if(args.length != 1)
    {
      Messenger.send((Player)cs, "Incorrect usage. Try: /unbanItem itemname");
      return true;
    }
    
    Material temp = Material.getMaterial(args[0].toUpperCase());
    
    if(temp == null)
    {
      Messenger.send((Player)cs, "Incorrect material name.");
      return true;
    }
    
    File bannedItems = new File("plugins" + File.separator + "WatchDog" + 
                                 File.separator + "bannedItems.info");
    
    try
    {
      String list = "";
      String info = "";
      
      Scanner scan = new Scanner(bannedItems);
      while(scan.hasNextLine())
        if(!(info = scan.nextLine()).toUpperCase().equals(args[0].toUpperCase()))
          list += info + "\n";       
      
      scan.close();
      
      BufferedWriter bw = new BufferedWriter(new FileWriter(bannedItems));
      bw.write(list);
      bw.close();
    }
    catch(Exception e)
    {
      Logger.getLogger("Minecraft").info("[PM] IO EXCEPTION 0x2");
    }
    
    if(!cs.getName().toLowerCase().equals("console"))
      Messenger.send((Player)cs, "You have unbanned " + args[0]);
    
    return false;
  }
}
