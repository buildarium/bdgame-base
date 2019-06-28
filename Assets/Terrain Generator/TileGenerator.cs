using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] NoiseGenerator noiseMapGeneration;

    [SerializeField] private MeshRenderer tileRenderer;

    [SerializeField] private MeshFilter meshFilter;

    [SerializeField] private MeshCollider meshColider;

    [SerializeField] private float mapScale;

    void Start() {

    }

    void GenerateTile() {
        Vector3[] meshVertices = this.meshFilter.mesh.vertices;
        int tileDepth = (int)Mathf.Sqrt(meshVertices.Length); 
        int tileWidth = tileDepth;

        float[,] heightMap = this.noiseMapGeneration.GenerateNoiseMap(tileDepth, tileWidth, this.mapScale);

        Texture2D tileTexture = BuildTexture(heightMap);
        this.tileRenderer.material.mainTexture = tileTexture;        
    }

    private Texture2D BuildTexture(float[,] heightMap) {
        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        Color[] colorMap = new Color[tileDepth * tileWidth];

        for (int z = 0; z < tileDepth; z++) {
            for (int x = 0; x < tileWidth; x++) {
                int colorIndex = z * tileWidth + x;
                float height = heightMap[z, x];
                colorMap[colorIndex] = Color.Lerp(Color.black, Color.white, height);
            }
        }

        Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
        tileTexture.wrapMode = TextureWrapMode.Clamp;
        tileTexture.SetPixels(colorMap);
        tileTexture.Apply();

        return  tileTexture;
    }

}
