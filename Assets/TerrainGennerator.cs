using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGennerator : MonoBehaviour
{
public int depht = 2;

  public int with = 257;
    public int height = 257;
    public float scale = 20f;
    public float offsetX = 100f;
public float offsetY = 100f;
void Start()
{
    offsetX = Random.Range (0f, 9999f);
    offsetY = Random.Range (0f, 9999f);
}

    void Update() {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
 
    }

    TerrainData GenerateTerrain (TerrainData terrainData)
    {

        terrainData.heightmapResolution = with + 1;
        terrainData.size = new Vector3(with, depht, height);

        terrainData.SetHeights(0,0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights () 
    {
        float[,] heights = new float[with, height];
        for(int x = 0; x < with; x++) 
        {
            for(int y = 0; y < height; y++)
            {
                heights[x,y] = CalculateHeight(x,y);
            }
        }
        return heights;
    }

float CalculateHeight (int x , int y)
{
    float xCoord = (float)x / with * scale + offsetX;
    float yCoord = (float)y / height * scale + offsetY;

    return Mathf.PerlinNoise(xCoord, yCoord);
}

}
