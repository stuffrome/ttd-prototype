using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : IItem
{
    public Kick(){
        item = Item.Kick;
    }
    public void UseItem(Player target){
        target.Hit();
    }
}
