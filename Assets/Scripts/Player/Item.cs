using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item
{
    None,
    Thunder,
    Reverse,
    Kick
}

public class IItem {    
    protected Item item = Item.None;    

    public void UseItem(Player target){
        // target.Hit();
    }

    public Item GetItem(){
        return item;
    }
}
