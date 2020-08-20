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
    public int unitsCounter = 0;

    public float stateTimeElapsed;
    public List<GameObject> spawnedUnits;

    private void Awake()
    {
        spawnedUnits = new List<GameObject>();
    }
    private void Update()
    {


        if ((Vector3.Distance(playerPosition.position, transform.position) <= spawnPointDistance))
        {
            if (!spawnState)
            {

                Debug.Log("Spawning");
                spawnState = true;
                Spawning();
            }


        }
        else
        {
            if (unitsCounter > 0)
            {
                if (CheckIfCountDownElapsed(despawnTimer))
                {

                    spawnState = false;


                    foreach (var item in spawnedUnits.ToList())
                    {
                        if (item.gameObject.GetComponent<EnemyController>().canDespawn)
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
        if(stateTimeElapsed >= duration)
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
                        Debug.Log("unit is spawning");

                        var spawning = (Vector3)Random.insideUnitSphere * spawnRadius;
                        Debug.Log(spawning);
                        spawning += transform.position;
                        unitsCounter++;

                        spawnedUnits.Add(Instantiate(spawnUnits[i].unit, spawning, transform.rotation));
                    }
                }
            }

            Debug.Log("spawned units " + unitsCounter);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
