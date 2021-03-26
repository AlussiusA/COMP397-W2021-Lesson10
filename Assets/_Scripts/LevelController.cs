using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    [Header("World Size")]
    public float tileLength;
    public float tileWidth;
    public List<GameObject> tilePrefabs;
    public List<GameObject> activeTiles;
    public GameObject startTile;

    [Header("Navigation")]
    private NavMeshSurface surface;

    private void Awake()
    {
        BuildTerrain();
        surface = GetComponent<NavMeshSurface>();
    }

    // Start is called before the first frame update
    void Start()
    {
        surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildTerrain()
    { 
        for (int width = 0; width < tileWidth; width++)
        {
            for (int length = 0; length < tileLength; length++)
            {
                if (width != 0 || length != 0)
                {
                    var randomTileIndex = Random.Range(0, tilePrefabs.Count);
                    var randomTilePosition = new Vector3(width * 16f, 0.0f, length * 16f);
                    var randomTileRotation = Random.Range(0, 4) * 90.0f;

                    var randomTile = Instantiate(tilePrefabs[randomTileIndex], randomTilePosition, Quaternion.Euler(0.0f, randomTileRotation, 0.0f));
                    randomTile.transform.parent = this.transform;
                    activeTiles.Add(randomTile);
                }
                else
                {
                    activeTiles.Add(startTile);
                }
            }
        }
    }
}
