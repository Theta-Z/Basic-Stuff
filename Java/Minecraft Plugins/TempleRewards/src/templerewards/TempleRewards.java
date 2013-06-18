package templerewards;

//:TODO:
//-Gifter Main

import java.io.File;
import java.util.Random;
import java.util.logging.Logger;
import org.bukkit.Bukkit;
import org.bukkit.Material;
import org.bukkit.command.Command;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.EntityType;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;
import org.bukkit.plugin.java.JavaPlugin;

/**
 *
 * @author Seobi-TAZS_C
 */
public class TempleRewards extends JavaPlugin
{
  Random r;
  DeathTracker dt;
  
  @Override
  public void onEnable()
  {
    Logger.getLogger("Minecraft").info("[TEMPLE REWARDS] Temple Rewards Activated.");
    r = new Random();
    
    dt = new DeathTracker();
    
    Bukkit.getServer().getPluginManager().registerEvents(dt, this);
    
    File directory = new File("plugins" + File.separator + "TR_EXPSYSTEM" + File.separator);
    if(!directory.exists())
      directory.mkdir();
  }
  
  @Override
  public void onDisable()
  {
    Logger.getLogger("Minecraft").info("[TEMPLE REWARDS] Disabled.");
  }
  
  public boolean onCommand(CommandSender cs, Command cmd, String cmdlabel, String[] args)
  {   
    if(cmdlabel.toLowerCase().contains("orly"))
    {
      Player p = (Player)cs;
      p.sendMessage("yarly");
      return false;
    }
    
    if(cmdlabel.toLowerCase().contains("goback"))
    {
      ((Player)cs).teleport(dt.diedAt);
      return false;
    }
    
    //==========================================================================
    //: less
    if(cmdlabel.toLowerCase().contains("less"))
      return Less.Main(cs);
    
    //==========================================================================
    //: No commands past here have no arguments.
    if(args.length == 0)
    {
      Messenger.send((Player)cs, "You lack arguments in your command.");
      return true;
    }
    
    //==========================================================================
    //: teleporter
    if(cmdlabel.toLowerCase().contains("teleme2"))
      return Teleporter.Main(cs, args[0]);
    //==========================================================================
    //: smelt
    if(cmdlabel.toLowerCase().contains("smelt"))
      return Smelter.Main(cs, args[0]);
    //==========================================================================
    //: trade
    if(cmdlabel.toLowerCase().contains("trade"))
      return Trader.Main(cs, args[0]);
    //==========================================================================
    //: friendremove
    if(cmdlabel.toLowerCase().contains("removefriend"))
      return Friends.removeFriend(cs, args[0]);
    //==========================================================================
    //: friend
    if(cmdlabel.toLowerCase().contains("friend"))
      return Friends.Main(cs, args[0]);    
    //==========================================================================
    //: gifter
    if(cmdlabel.toLowerCase().contains("gift"))
      return Gifter.Main(cs, args);
    
    
    //==========================================================================
    //==========================================================================
    //==========================================================================
    //==========================================================================
    //:Console only commands ~> Usable via console and [Command] signs
    //==========================================================================
    if(!cs.getName().toLowerCase().contains("console"))
    {
      ((Player)Bukkit.getPlayer(args[0])).sendMessage("You lack permission to do that.");
      
      return false;
    }
    
    Player p = Bukkit.getPlayer(args[0]);
    
    //==========================================================================
    //: Actual console only commands begin here
    //==========================================================================
    if(cmdlabel.toLowerCase().contains("fml"))
    {
      p.performCommand("FML!!!!!!!!!!!!!");
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "say " + args[0] + " an heroed.");
      p.setHealth(0);
      
      return false;
    }
    
    if(cmdlabel.toLowerCase().contains("stylishride"))
    {
      p.sendMessage("Congratulations, " + p.getName() + ".");
      p.sendMessage("Please take this experience and reward package!");  
    
      p.getInventory().addItem(new ItemStack(Material.SADDLE, 1));
      p.getInventory().addItem(new ItemStack(Material.CARROT_STICK, 1));
      p.giveExp(150);
    
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "warp Josh " + args[0]);
      p.getLocation().getWorld().spawnEntity(p.getLocation(), EntityType.PIG);
      p.updateInventory();
      p.sendMessage("Enjoy your Stylish Ride!");
      
      return false;
    }
    
    if(cmdlabel.toLowerCase().contains("genericprize"))
    {
      p.sendMessage("Congratulations, " + p.getName() + ".");
      p.sendMessage("Please take this experience and reward package!");  
    
      p.getInventory().addItem(new ItemStack(Material.MAGMA_CREAM, r.nextInt(1)));
      p.getInventory().addItem(new ItemStack(Material.OBSIDIAN, r.nextInt(1)));
      p.getInventory().addItem(new ItemStack(Material.WATER_LILY, r.nextInt(1)));
      p.getInventory().addItem(new ItemStack(Material.COOKED_BEEF, r.nextInt(2)));
      p.getInventory().addItem(new ItemStack(Material.RED_ROSE, r.nextInt(8)));
      
      if((r.nextFloat() * 100) < 4)
        p.getInventory().addItem(new ItemStack(Material.CHAINMAIL_HELMET, 1));
      else
        p.sendMessage("The legendary chainmail helmet avoids you, yet again...");
      
      p.getInventory().addItem(new ItemStack(Material.GOLD_NUGGET, r.nextInt(2)));
      p.giveExp(40);
    
      Bukkit.getServer().dispatchCommand(Bukkit.getServer().getConsoleSender(), "warp Josh " + args[0]);
      p.getLocation().getWorld().spawnEntity(p.getLocation(), EntityType.PIG);
      p.updateInventory();
      p.sendMessage("Enjoy your Prize!");
      
      return false;
    }
    
    
    return false;
  }
}