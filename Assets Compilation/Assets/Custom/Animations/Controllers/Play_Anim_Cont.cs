using UnityEngine;

public class Play_Anim_Cont : MonoBehaviour
{
    public Animator animator;
    public GameObject righthand;
    public GameObject weapon;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        righthand = transform.Find("Shoulder_R/Upper Arm_R/Elbow_R/Lower Arm_R/Hand_R").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if(righthand.transform.childCount > 0)
            {
                weapon = righthand.transform.GetChild(0).gameObject;
                string weapontype = weapon.name;

                if (weapontype == "Axe")
                {
                    animator.Play("1H_Axe_UR2BL");
                }
            } else
            {
                // Play Unarmed attack
            }
        }
    }

    void EnableWeapon()
    {
        if(righthand.transform.childCount > 0)
        {
            weapon = righthand.transform.GetChild(0).gameObject;
            weapon.GetComponent<MeshCollider>().enabled = true;
        }
    }

    void DisableWeapon()
    {
        if (righthand.transform.childCount > 0)
        {
            weapon = righthand.transform.GetChild(0).gameObject;
            weapon.GetComponent<MeshCollider>().enabled = false;
        }
    }
}