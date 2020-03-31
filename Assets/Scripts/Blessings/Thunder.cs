using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : IItem
{
    public Thunder(){
        item = Item.Thunder;
    }
    public void UseItem(Player target){
        target.Hit();
    }
}
