using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
  //  public DummyInventory inventory;

    [SerializeField]
    protected List<Items> mustDropItems;
    [SerializeField]
    protected List<ChanceToDropItems> chanceToDropItems;


    public List<Items> droppedItems;


    protected  List<Items> GenerateDrops()
    {

        droppedItems = new List<Items>(mustDropItems);
        foreach(var item in chanceToDropItems)
        {
           int randomChance = Random.Range(1, 100);

            if(randomChance <= item.percentage)
            {
                droppedItems.Add(item.item);
            }
        }


        return droppedItems;
    }
}
