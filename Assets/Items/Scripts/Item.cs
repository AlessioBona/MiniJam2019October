using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //the type of the item
    public enum Type { dna, speedUp, jumpBuff, invertMvt, trap }
    [SerializeField]
    private Type type = Type.dna;
    public Type GetItemType () { return type; }

    //the buff value, depending on the type of the item
    [SerializeField]
    private float value = 2;
    public float GetValue () { return value; }

    //is the item destroyed after it's activated??
    [SerializeField]
    private bool destroy = true;
    public bool CanDestroy () { return destroy; }
}
