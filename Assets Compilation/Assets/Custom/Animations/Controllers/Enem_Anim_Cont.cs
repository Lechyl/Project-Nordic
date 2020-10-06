using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Custom;

[SerializeField]
public class Enem_Anim_Cont : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void AttackPlayer()
    {
        animator.Play("Enemy_1H_Axe_Up2Do");
    }

    public void EnableWeapon()
    {
        gameObject.GetComponentInChildren<MeshCollider>().enabled = true;
    }

    public void DisableWeapon()
    {
        gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
    }
}