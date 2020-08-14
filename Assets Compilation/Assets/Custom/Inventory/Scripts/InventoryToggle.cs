using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject ip;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject ip = Inventory.instance.InventoryPanel;
        }
        if (!ip.activeSelf)
        {
            ip.SetActive(true);
        }
        else
        {
            ip.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
