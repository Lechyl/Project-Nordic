using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ForestMaker : MonoBehaviour
{
    public GameObject forest;
    [SerializeField] public GameObject[] trees;
    private int treeTypes;
    [Range(0, 25000)]
    public int treeAmount;

    // Start is called before the first frame update
    void Start()
    {
        forest = this.gameObject;

        for (int i = 0; i < treeAmount; i++)
        {
            treeTypes = trees.Length;
            int treeType = Random.Range(0, treeTypes);
            float rangeX = Random.Range(150, 850);
            float rangeZ = Random.Range(150, 850);
            float rotation = Random.Range(0f, 360f);

            float height = Terrain.activeTerrain.SampleHeight(transform.position) + Terrain.activeTerrain.transform.position.y;

            GameObject tree = Instantiate(trees[treeType], forest.transform);
            tree.transform.position = new Vector3(rangeX, height, rangeZ);
            tree.transform.eulerAngles = new Vector3(0, rotation, 0);
        }
    }
}
