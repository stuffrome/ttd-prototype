using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Power
{
    None,
    Thunder,
    Reverse,
    Kick,
    Phantm
}

public class Blessing {    
    protected Power power = Power.None;

    public virtual void UseBlessing(Player owner, Player target){}

    public Power GetPower(){
        return power;
    }
}

public class Kick : Blessing
{
    public Kick(){
        power = Power.Kick;
    }
    public override void UseBlessing(Player owner, Player target){
        target.Hit();
    }
}

public class Reverse : Blessing
{
    public Reverse(){
        power = Power.Reverse;
    }
    public override void UseBlessing(Player owner, Player target){
        target.Reverse();
    }
}

public class Thunder : Blessing
{
    public Thunder(){
        power = Power.Thunder;
    }
    public override void UseBlessing(Player owner, Player target){
        target.Thunder(target.GetLane());
    }
}

public class Phantm : Blessing
{
    public Phantm(){
        power = Power.Phantm;
    }

    public override void UseBlessing(Player owner, Player target){
        target.Phantm();
    }
}