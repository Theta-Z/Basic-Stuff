package templerewards;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.HashMap;
import java.util.logging.Logger;
import javax.swing.Timer;
import org.bukkit.Material;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;

/**
 *
 * @author Seobi-TAZS_C
 */
public class Mover
{
  private HashMap flyingTime = new HashMap();
  
  public boolean Main(CommandSender cs)
  {
    if(cs.getName().toLowerCase().equals("console"))
      return true;
    
    Logger.getLogger("Minecraft").info("FlyAll");
    return flyAll((Player)cs);
  }
  
  public boolean Main(CommandSender cs, String[] args)
  {
    if(cs.getName().toLowerCase().equals("console"))
      return true;
    
    return fly((Player)cs);
  }
  
  private boolean alreadyFlying(Player p)
  {
    return p.getAllowFlight();
  }
  
  private boolean flyAll(final Player p)
  {
    if(!p.getInventory().contains(Material.GOLD_NUGGET))
    {
      Messenger.send(p, "You have no gold nuggets. Please get one to use the speed boost.");      
      return true;
    }
   
    //:nothing in life is free!
    int slot;
    ItemStack is;
    int amt = 0;
      
    while(amt++ > -42 && p.getInventory().contains(Material.GOLD_NUGGET))
    {
      slot = p.getInventory().first(Material.GOLD_NUGGET);
      is = p.getInventory().all(Material.GOLD_NUGGET).get(slot);
      is.setAmount(is.getAmount() - 1);   
      p.getInventory().setItem(slot, is);
    }
    p.updateInventory();
    
    if(alreadyFlying(p))
    {
      int timeleft = (Integer)flyingTime.get(p) + (60 * amt);
      
      flyingTime.remove(p);
      flyingTime.put(p, timeleft);
      
      Messenger.send(p, "We have given you an extra " + 60 * amt + " seconds. Your fly time is now " + timeleft + " seconds.");
      return true;
    }
    
    flyingTime.put(p, amt * 60);
    
    //:Gotta go fast (30 seconds)
    Thread t = new Thread(new Runnable()
    { 
      @Override
      public void run()
      {
        //======================================================================
        //: actual timer
        Timer timer = new Timer(10000, new ActionListener()
        {
          @Override
          public void actionPerformed(ActionEvent e)
          {
            int timeleft = (Integer)flyingTime.get(p) - 10;
            
            if(timeleft == 30 || timeleft == 10)
              Messenger.send(p, "You have " + timeleft + " seconds of fly left.");
            
            if(timeleft == 0)
              p.setAllowFlight(false);
            
            if(flyingTime.containsKey(p))
            {
              flyingTime.remove(p);
            }
            
            flyingTime.put(p, timeleft);
          }
        });
        
        timer.start();
        
        //======================================================================
        //: waiting zzz....
        while(timer.isRunning())
        {
          try
          {
            Thread.sleep(2000);
          }
          catch (Exception e){}
          
          if(!alreadyFlying(p))
            break;
        }
        
        p.setAllowFlight(false);
        p.setFlying(false);
        timer.stop();
        return;
      }//: void:run
    }); 
    
    p.setAllowFlight(true);
    t.setName(p.getName() + "FLIGHT");
    t.start();
    Messenger.send(p, "We have taken your gold nuggets, and given you temporary fly. Have a nice day.");
    
    return false;
  }
  
  private boolean fly(final Player p)
  {
    if(!p.getInventory().contains(Material.GOLD_NUGGET))
    {
      Messenger.send(p, "You have no gold nuggets. Please get one to use the speed boost.");      
      return true;
    }
    
    
    
    //:nothing in life is free!
    int slot = p.getInventory().first(Material.GOLD_NUGGET);
    ItemStack is = p.getInventory().all(Material.GOLD_NUGGET).get(slot);
    is.setAmount(is.getAmount() - 1);
    
    p.getInventory().setItem(slot, is);
    p.updateInventory();
    
    if(alreadyFlying(p))
    {
      int timeleft = (Integer)flyingTime.get(p) + 60;
      
      flyingTime.remove(p);
      flyingTime.put(p, timeleft);
      
      Messenger.send(p, "We have given you an extra 60 seconds. Your fly time is now " + timeleft + " seconds.");
      return true;
    }
    
    //:Gotta go fast (30 seconds)
    Thread t = new Thread(new Runnable()
    { 
      @Override
      public void run()
      {
        flyingTime.put(p, 60);
        
        //======================================================================
        //: actual timer
        Timer timer = new Timer(10000, new ActionListener()
        {
          @Override
          public void actionPerformed(ActionEvent e)
          {
            int timeleft = (Integer)flyingTime.get(p) - 10;
            
            if(timeleft == 30 || timeleft == 10)
              Messenger.send(p, "You have " + timeleft + " seconds of fly left.");
            
            if(timeleft == 0)
              p.setAllowFlight(false);
            
            if(flyingTime.containsKey(p))
            {
              flyingTime.remove(p);
            }
            
            flyingTime.put(p, timeleft);
          }
        });
        
        timer.start();
        
        //======================================================================
        //: waiting zzz....
        while(timer.isRunning())
        {
          try
          {
            Thread.sleep(2000);
          }
          catch (Exception e){}
          
          if(!alreadyFlying(p))
            break;
        }
        
        p.setAllowFlight(false);
        p.setFlying(false);
        timer.stop();
        return;
      }//: void:run
    }); 
    
    p.setAllowFlight(true);
    t.setName(p.getName() + "FLIGHT");
    t.start();
    Messenger.send(p, "We have taken 1 gold nugget, and given you 1 minute of fly. Have a nice day.");
    
    return false;
  }
}
