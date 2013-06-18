package templerewards;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.util.Scanner;
import java.util.logging.Logger;
import org.bukkit.Bukkit;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;

/**
 *
 * @author Seobi-TAZS_C
 */
public class Friends
{
  public static boolean Main(CommandSender cs, String playerName)
  {
    if(cs.getName().toLowerCase().equals("console"))
    {
      //dont do console things;
      return true;
    }
    
    Player p = Bukkit.getPlayerExact(playerName);
    if(p == null)
    {
      Messenger.send((Player)cs, playerName + " isn't a player thats currently online.");
      return true;
    }
    
    if(areFriends(p, (Player)cs))
    {
      Messenger.send((Player) cs, "You are already friends with " + playerName + ".");
      return true;
    }
    
    return addFriend((Player)cs, p);
  }
  
  /**
   * @param p1 Player to check.
   * @param p2 Player to check if p1 is added.
   * @return If P2 has P1 on his friends list.
   */
  public static boolean areFriends(Player p1, Player p2)
  {
    File player = new File("plugins" + File.separator + "TR_EXPSYSTEM" + 
                                  File.separator + p2.getName() + "_friends.info");

    if(!player.exists())
    {
      try
      {
        player.createNewFile();
      }
      catch(Exception e)
      {
        Logger.getLogger("Minecraft").info("[TR] -> IO EXCEPTION\n\t" + e.getMessage());
      }
    }//:end file creation if necessary
    
    try
    {
      Scanner scan = new Scanner(player);
      while(scan.hasNextLine())
      {
        if(scan.nextLine().toLowerCase().equals(p1.getName().toLowerCase()))
          return true;
      }
      
      scan.close();
    }
    catch(Exception e)
    {
      Logger.getLogger("Minecraft").info("[TR] -> IO EXCEPTION\n\t" + e.getMessage());
    }
    
    return false;
  }
  
  /**
   * Add P2 to P1's friend list.
   */
  public static boolean addFriend(Player p1, Player p2)
  {
    File player = new File("plugins" + File.separator + "TR_EXPSYSTEM" + 
                                  File.separator + p1.getName() + "_friends.info");
    
    try
    {
      BufferedWriter bw = new BufferedWriter(new FileWriter(player));
      bw.append(p2.getName() + "\n");
      bw.close();
    }
    catch(Exception e)
    {
      Logger.getLogger("Minecraft").info("[TR] -> IO EXCEPTION\n\t" + e.getMessage());
    }
    
    Messenger.send(p1, "You have successfully added " + p2.getName() + " to your friend list.");
    Messenger.send(p2, p1.getName() + " has added you to their friend list.");
    return false;
  }
  
  public static boolean removeFriend(CommandSender cs, String p2)
  {
    if(cs.getName().toLowerCase().equals("console"))
    {
      //dont do console things;
      return true;
    }
    Player p1 = (Player)cs;
    
    File player = new File("plugins" + File.separator + "TR_EXPSYSTEM" + 
                                  File.separator + p1.getName() + "_friends.info");
    
    String newList = "";
    
    try
    {
      Scanner scan = new Scanner(player);
      String temp = "";
      
      while(scan.hasNextLine())
        if(!(temp = scan.nextLine()).toLowerCase().contains(p2.toLowerCase()))
          newList += temp + "\n";
    }
    catch(Exception e)
    {
      Logger.getLogger("Minecraft").info("[TR] -> IO EXCEPTION\n\t" + e.getMessage());
    }
    
    try
    {
      BufferedWriter bw = new BufferedWriter(new FileWriter(player));
      bw.write(newList);
      bw.close();
    }
    catch(Exception e)
    {
      Logger.getLogger("Minecraft").info("[TR] -> IO EXCEPTION\n\t" + e.getMessage());
    }
    
    Messenger.send(p1, "You have successfully removed " + p2 + " from your friend list.");
    return false;
  }
}
