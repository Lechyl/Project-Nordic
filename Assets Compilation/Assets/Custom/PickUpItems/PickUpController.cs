
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    // Start is called before the first frame update

    public PickUp pickUp;
    public Button pickUpUI;
    public DummyInventory inventory;



    public Items targetItem;

    public bool pickUpUIState = false;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.F) && pickUpUIState)
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
