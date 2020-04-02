using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Power
{
    None,
    Thunder,
    Reverse,
    Kick,
    Phantom
}

public class Blessing {    
    protected Power power = Power.None;

    public virtual void UseBlessing(Player owner, Player target){
        owner.Invincible();
    }

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
        target.Thunder(Resources.Load("Sphere"));
    }
}

public class Phantom : Blessing
{
    public Phantom(){
        power = Power.Phantom;
    }

    public override void UseBlessing(Player owner, Player target){
        owner.Invincible();
    }
}