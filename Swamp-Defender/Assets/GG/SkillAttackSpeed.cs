using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    private int type;
    private float boost;
       public Ability(float proc,int type)
    {
        this.boost = (1 * proc) / 100;
        this.type = type;
    }
    public float Getboost()
    {
        return (boost);
    }
    public int Gettype()
    {
        return (type);
    }
}
