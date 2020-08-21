using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


[CreateAssetMenu]
public class Health : ScriptableObject
{

    public float CurrentHp;
    public float MaxHp;

    public void death()
    {
        CurrentHp = MaxHp;
        SceneManager.LoadScene("DemoGame"); 
    }


}
