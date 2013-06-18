package protectivemama;

import java.io.File;
import java.util.logging.Logger;
import org.bukkit.Bukkit;
import org.bukkit.command.Command;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.plugin.java.JavaPlugin;
import templerewards.Messenger;

/**
 *
 * @author Seobi-TAZS_C
 */
public class ProtectiveMama extends JavaPlugin
{
  private WatchDog wd;
  
  @Override
  public void onEnable()
  {
    File directory = new File("plugins" + File.separator + "WatchDog" + File.separator);
    if(!directory.exists())
      directory.mkdir();
    
    Logger.getLogger("Minecraft").info("[PM] Protective Mama Activated.");
    wd = new WatchDog();
    
    Bukkit.getServer().getPluginManager().registerEvents(wd, this);
  }
  
  @Override
  public void onDisable()
  {
    Logger.getLogger("Minecraft").info("[TEMPLE REWARDS] Disabled.");
  }
  
  public boolean onCommand(CommandSender cs, Command cmd, String cmdlabel, String[] args)
  {
    if(!cs.getName().toLowerCase().equals("console"))
      if(!((Player)cs).isOp())
      {
        Messenger.send((Player)cs, "You can't use Protective Mama, you lack the permissions.");
        return true;
      }
    
    if(cmdlabel.toLowerCase().equals("banitem"))
    {
      boolean ret = NonoList.banItem(cs, args);
      wd.reload();
      return ret;
    }
    if(cmdlabel.toLowerCase().equals("unbanitem"))
    {
      boolean ret = NonoList.unbanItem(cs, args);
      wd.reload();
      return ret;
    }
    
    return false;
  }
}
