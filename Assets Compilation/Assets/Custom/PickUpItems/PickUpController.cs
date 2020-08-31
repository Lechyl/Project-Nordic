
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    // Start is called before the first frame update

    public PickUp pickUp;
    public Button pickUpUI;
    public DummyInventory inventory;
    public Transform rightHand;

    public GameObject targetItem;
    public int counter = 0;
    public bool pickUpUIState = false;

    void Start()
    {
       // itemInstantiate.items = new System.Collections.Generic.List<GameObject>();
       // itemInstantiate = new ItemInstantiate();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && pickUpUIState)
        {
            pickUp.PickUpItem(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pickUp.ActivatePickUpUI(other, this);

    }
    private void OnTriggerExit(Collider other)
    {

        //Debug.Log("no " +other.gameObject);
        pickUp.DeactivatePickUpUI(this);
    }
}
