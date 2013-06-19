package templerewards;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import org.bukkit.Bukkit;
import org.bukkit.Material;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;

/**
 *
 * @author Seobi-TAZS_C
 */
public class Trader
{
  private static boolean help(Player p)
  {
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Thanks for your interest in Trader, " + p.getName() + "!");
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Usage:/trade itemName\nCurrent trades are:");
    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " oakstairs, junglestairs, sprucestairs, birchstairs, cobblestairs");
    return true;
  }
  
  public static boolean Main(CommandSender cs, String mat)
  {
    if(cs.getName().toLowerCase().equals("console"))
     return true;
    
    Player p = (Player)cs;
    
    if(mat.toLowerCase().equals("help"))
      return help(p);

    if(mat.toLowerCase().contains("cobblestairs"))
      return devolve(Material.COBBLESTONE_STAIRS, p);

    if(mat.toLowerCase().contains("oakstairs"))
      return devolve(Material.WOOD_STAIRS, p);

    if(mat.toLowerCase().contains("sprucestairs"))
      return devolve(Material.SPRUCE_WOOD_STAIRS, p);

    if(mat.toLowerCase().contains("junglestairs"))
      return devolve(Material.JUNGLE_WOOD_STAIRS, p);

    if(mat.toLowerCase().contains("birchstairs"))
      return devolve(Material.BIRCH_WOOD_STAIRS, p);

    Messenger.send(p, "We don't trade that... yet!");

    return true;
  }
  
  private static boolean devolve(Material m, Player p)
  {
    if(!p.getInventory().contains(m))
    {
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " You have no " + m.name());
      return true;
    }

    if(p.getInventory().firstEmpty() == -1)
    {
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Make space in your inventory please.");
      return true;
    }
      
    Material output = Material.ARROW;
    float outputNum = 1;
    
    List<Integer> mAmt = new ArrayList<Integer>();
    HashMap hm = p.getInventory().all(m);
    Iterator itr = hm.entrySet().iterator();
    Entry ent;

    while(itr.hasNext())
    {
      ent = (Map.Entry)itr.next();
      mAmt.add(Integer.parseInt(ent.getKey() + ""));
    }


    int totalMat = 0;
    int modded = 0;

    for(int i = 0; i < mAmt.size(); i++)
      totalMat += p.getInventory().getItem(mAmt.get(i)).getAmount();
     
    
    //:=========================================================================
    //:trade types
    if(m.equals(Material.COBBLESTONE_STAIRS))
    {
      outputNum = 1.5f;
      output = Material.COBBLESTONE;
      totalMat = Math.min(42, totalMat);
    }
    
    if(m.equals(Material.SPRUCE_WOOD_STAIRS))
    {
      outputNum = 1.5f;
      output = Material.getMaterial("WOOD");
      modded = 1;
      totalMat = Math.min(42, totalMat);
    }
    
    if(m.equals(Material.BIRCH_WOOD_STAIRS))
    {
      outputNum = 1.5f;
      output = Material.getMaterial("WOOD");
      modded = 2;
      totalMat = Math.min(42, totalMat);
    }
    
    if(m.equals(Material.JUNGLE_WOOD_STAIRS))
    {
      outputNum = 1.5f;
      output = Material.getMaterial("WOOD");
      modded = 3;
      totalMat = Math.min(42, totalMat);
    }
    
    if(m.equals(Material.WOOD_STAIRS))
    {
      outputNum = 1.5f;
      output = Material.getMaterial("WOOD");
      totalMat = Math.min(42, totalMat);
    }

    
    //==========================================================================
    //:output
    p.getInventory().removeItem(new ItemStack(m, totalMat));
    p.getInventory().addItem(new ItemStack(output, (int)Math.floor(outputNum * totalMat), (short)modded));
    p.updateInventory();     


    Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "msg " + p.getName() + " Enjoy your " + output.name());

    
    return false;
  }
}