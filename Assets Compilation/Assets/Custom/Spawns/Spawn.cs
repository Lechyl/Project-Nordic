using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{

    public Transform playerPosition;
    public int spawnLimit = 6;
    public int spawnPointDistance = 0;
    public List<SpawnUnits> spawnUnits;
    public float spawnRadius;
    public bool spawnState = false;
    public float despawnTimer;
    public int spawnHeight;
    public int unitsCounter = 0;

    public float stateTimeElapsed;
    public List<GameObject> spawnedUnits;


    private float checkSpawnCollisionRadius;

    private void Awake()
    {
        spawnedUnits = new List<GameObject>();
        checkSpawnCollisionRadius = spawnHeight - 1;
    }
    private void Update()
    {

        //Check if player is withhin distance of spawnpoint
        if ((Vector3.Distance(playerPosition.position, transform.position) <= spawnPointDistance))
        {
            //check if spawnpoint haven't spawned yet
            if (!spawnState)
            {
                //spawn
                spawnState = true;
                Spawning();
            }


        }
        else
        {
            //check if units are alive
            if (unitsCounter > 0)
            {
                //Timer
                if (CheckIfCountDownElapsed(despawnTimer))
                {

                    spawnState = false;

                    //Destroy each Enemy if they can despawn. They can only despawn if they're not chasing Player or doing other things which require it dosn't despawn.
                    foreach (var item in spawnedUnits.ToList())
                    {


                        if (item.gameObject == null || item.gameObject.GetComponent<EnemyController>().canDespawn || item.gameObject.GetComponent<EnemyController>().CurrentHp < 0)
                        {
                            Destroy(item.gameObject);
                            spawnedUnits.Remove(item);
                            unitsCounter--;

                        }

                    }

                }

            }


        }

    }
    public bool CheckIfCountDownElapsed(float duration)
    {
        if (stateTimeElapsed >= duration)
        {
            stateTimeElapsed = 0;
            return true;
        }
        else
        {
            stateTimeElapsed += Time.deltaTime;
            return false;
        }
    }

    private void Spawning()
    {

        if (spawnUnits.Count > 0)
        {

            while (unitsCounter < spawnLimit)
            {

                for (int i = 0; i < spawnUnits.Count; i++)
                {

                    if (unitsCounter >= spawnLimit)
                        break;
                    int chance = Random.Range(1, 99);

                    if (chance <= spawnUnits[i].spawnRate)
                    {
                        //Spawn units here


                        var spawnLocation = (Vector3)Random.insideUnitSphere * spawnRadius;

                        spawnLocation += transform.position;
                        spawnLocation.y = spawnHeight;

                        LayerMask mask = LayerMask.GetMask("Default");

                        if (!Physics.CheckSphere(spawnLocation, checkSpawnCollisionRadius, mask))
                        {
                            spawnedUnits.Add(Instantiate(spawnUnits[i].unit, spawnLocation, transform.rotation, transform));
                            unitsCounter++;

                        }
                    }
                }
            }

        }

    }

       private void OnDrawGizmos()
      {
          Gizmos.color = Color.red;
          Gizmos.DrawWireSphere(transform.position, spawnRadius);
      }
}
