using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChanceToDropItems
{
    public Items item;
    [Range(1, 99)] public int percentage;
}
