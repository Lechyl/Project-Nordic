using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    // Start is called before the first frame update

    public PickUp pickUp;
    public Button pressFScreen;
    public DummyInventory inventory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        /*Debug.Log("I Trigger");
        Items item = other.GetComponent<Items>();
        if (item != null)
        {
            pressFScreen.gameObject.SetActive (true);
        }
        else
        {
            //Debug.Log(other.gameObject.GetType());

        }*/
        if (pickUp.PickUpItem(other))
        {

            pressFScreen.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {


            pressFScreen.gameObject.SetActive(false);
        

    }
}
