using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem_Attack_Coll : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<Enem_Anim_Cont>().AttackPlayer();
        }
    }
}