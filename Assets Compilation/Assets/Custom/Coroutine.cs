using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{

    public static Coroutine instance;
    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;
    }

    
}
