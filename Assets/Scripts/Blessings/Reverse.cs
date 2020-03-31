using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : IItem
{
    public Reverse(){
        item = Item.Reverse;
    }
    public void UseItem(Player target){
        target.Hit();
    }
}
