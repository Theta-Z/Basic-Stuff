package templerewards;

import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;

/**
 *
 * @author Seobi-TAZS_C
 */
public class Less
{
  public static boolean Main(CommandSender cs)
  {
    if(cs.getName().toLowerCase().equals("console"))
    {
      //dont do console things;
      return true;
    }
    
    return less(cs);
  }
  
  private static boolean less(CommandSender cs)
  {
    Player p = (Player)cs;
    int slot = p.getInventory().getHeldItemSlot();
    p.getInventory().setItem(slot, new ItemStack(p.getInventory().getItemInHand().getType(), 1));
    p.updateInventory();
    
    Messenger.send(p, "I have reduced your held item. Have fun!");
    
    return false;
  }
}
