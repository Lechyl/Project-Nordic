using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    public float nextRespawnTimerInSeconds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    /*  private void Update()
      {
          //itemGameObject.SetActive(false);
          Debug.Log(itemGameObject.activeSelf);
          //Check if this gameobject is disabled


          if (itemGameObject.activeSelf == false && !isRespawning)
          {
              Debug.Log("Respawning");
              Respawn();
          }
      }*/
    public void Respawn()
    {

        Debug.Log("Respawning");

        StartCoroutine(RespawnTimer());


    }



    private IEnumerator RespawnTimer()
    {
        yield return new WaitForSecondsRealtime(nextRespawnTimerInSeconds);
        Debug.Log("Item REspawned");

        transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
        transform.gameObject.GetComponent<Collider>().enabled = true;
    }
}
