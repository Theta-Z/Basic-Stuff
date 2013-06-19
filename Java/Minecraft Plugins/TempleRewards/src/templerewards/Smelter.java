package templerewards;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.logging.Logger;
import org.bukkit.Bukkit;
import org.bukkit.Material;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;

/**
 *
 * @author Seobi-TAZS_C
 */
public class Smelter
{
  private static boolean help(Player p)
  {
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Thanks for your interest in Smelter, " + p.getName() + "!");
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Usage:/smelt itemName\nCurrent trades are:");
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " iron, gold, cobble, nether, sand");
    return true;
  }
  
  public static boolean Main(CommandSender cs, String mat)
  {
    Player p = (Player)cs;
      
    if(mat.toLowerCase().contains("help"))
      return help(p);

    if(mat.toLowerCase().contains("iron"))
     return smelt(Material.IRON_ORE, p);

    if(mat.toLowerCase().contains("gold"))
      return smelt(Material.GOLD_ORE, p);

    if(mat.toLowerCase().contains("nether"))
      return smelt(Material.NETHERRACK, p);

    if(mat.toLowerCase().contains("sand"))
      return smelt(Material.SAND, p);

    if(mat.toLowerCase().contains("cobble"))
      return smelt(Material.COBBLESTONE, p);

    Messenger.send(p, "We don't smelt that... yet!");

    return true;
  }
   
  private static boolean smelt(Material m, Player p)
  {
     if(!p.getInventory().contains(m))
      {
        Messenger.send(p, "You have no " + m.name());
        return true;
      }

      if(!p.getInventory().contains(Material.COAL))
      {
        Messenger.send(p, "You have no Coal...");
        return true;
      }

      if(p.getInventory().firstEmpty() == -1)
      {
        Messenger.send(p, "Make space in your inventory please.");
        return true;
      }       

      //========================================================================
      //:GetPlayer EXP
      File player = new File("plugins" + File.separator + "TR_EXPSYSTEM" + 
                                  File.separator + p.getName() + "_smelt.info");

      if(!player.exists())
      {
        try
        {
          player.createNewFile();
          BufferedWriter bw = new BufferedWriter(new FileWriter(player));

          bw.write("1"); //:everybody gets 1 Peter...
          bw.close();
        }
        catch(Exception e)
        {
          Logger.getLogger("Minecraft").info("[TR] -> IO EXCEPTION\n\t" + e.getMessage());
        }
      }//:end file creation if necessary

      int PLAYER_EXP = 1;
      float EXP_MULTIPLIER = 1;

      try
      {
        Scanner scan =  new Scanner(player);
        PLAYER_EXP = scan.nextInt();
        scan.close();
      }
      catch(Exception e)
      {
        Logger.getLogger("Minecraft").info("[TR] -> IO EXCEPTION\n\t" + e.getMessage());
      }

      EXP_MULTIPLIER += (PLAYER_EXP * 1.0f) / 2500;
      EXP_MULTIPLIER = Math.min(1.5f, EXP_MULTIPLIER);

      //========================================================================
      //:ACTUAL SMELTING PROCESS
      HashMap hm = p.getInventory().all(Material.COAL);     
      Iterator itr = hm.entrySet().iterator();
      List<Integer> coalAmt = new ArrayList<Integer>();
      List<Integer> mAmt = new ArrayList<Integer>();
      Map.Entry ent;

      while(itr.hasNext())
      {
        ent = (Map.Entry)itr.next();
        coalAmt.add(Integer.parseInt(ent.getKey() + ""));
      }

      hm = p.getInventory().all(m);
      itr = hm.entrySet().iterator();

      while(itr.hasNext())
      {
        ent = (Map.Entry)itr.next();
        mAmt.add(Integer.parseInt(ent.getKey() + ""));
      }


      int totalIron = 0;
      int totalCoal = 0;

      for(int i = 0; i < mAmt.size(); i++)
        totalIron += p.getInventory().getItem(mAmt.get(i)).getAmount();

      for(int i = 0; i < coalAmt.size(); i++)
        totalCoal += p.getInventory().getItem(coalAmt.get(i)).getAmount();

      int coalNeeded = (int)Math.ceil((totalIron * 1.0f) / 8.0f);           
      while(coalNeeded > totalCoal) { coalNeeded--; }         
      int ingot = Math.min(coalNeeded * 8, totalIron);
      int recievedIngot = (int)Math.floor(ingot * EXP_MULTIPLIER);
      
      //========================================================================
      //:Get Material output
      Material recieved = Material.BOOK;
      String material = "";
      float modifier = 1f;
      
      if(m.equals(Material.IRON_ORE))
      {
        material = " iron!";
        recieved = Material.IRON_INGOT;
        modifier = 1f;
      }
      
      if(m.equals(Material.GOLD_ORE))
      {
        material = " gold!";
        recieved = Material.GOLD_INGOT;
        modifier = 1.2f;
      }
      
      if(m.equals(Material.NETHERRACK))
      {
        material = " nether bricks!";
        recieved = Material.NETHER_BRICK_ITEM;
        modifier = 0.4f;
      }
      
      if(m.equals(Material.SAND))
      {
        material = " glass!";
        recieved = Material.GLASS;
        modifier = 0.5f;
      }
      
      if(m.equals(Material.COBBLESTONE))
      {
        material = " stone!";
        recieved = Material.STONE;
        modifier = 0.2f;
      }

      p.getInventory().removeItem(new ItemStack(Material.COAL, coalNeeded));
      p.getInventory().removeItem(new ItemStack(m, ingot));
      p.getInventory().addItem(new ItemStack(recieved, recievedIngot));
      p.giveExp((int)(ingot * 1.2f));

      p.updateInventory();     
      
      
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Enjoy your" + material);
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), 
            "msg " + p.getName() + " Due to your experience in smelting (" + PLAYER_EXP + "), you got an extra " + 
                                                                              (recievedIngot - ingot) + material);

      //========================================================================
      //:EXP SYSTEM!
      
      
      
      
      PLAYER_EXP += Math.ceil(ingot * modifier);
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " You now have... " + PLAYER_EXP + " exp in smelting.");

      try
      {
        BufferedWriter bw = new BufferedWriter(new FileWriter(player));
        bw.write(PLAYER_EXP + ""); 
        bw.close();
      }
      catch(Exception e)
      {
        Logger.getLogger("Minecraft").info("[TR] -> IO EXCEPTION\n\t" + e.getMessage());
      }

      return false;
  }
}
