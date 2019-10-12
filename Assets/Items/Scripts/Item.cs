﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //the type of the item
    public enum Type { clone, speedUp }
    [SerializeField]
    private Type type = Type.clone;
    public Type GetItemType () { return type; }
}
