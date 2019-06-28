using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public float[,] GenerateNoiseMap(int mapWidth, int mapDepth, float scale) {
        // Generate a 2D array of coordinates based on the function parameters
        float[,] noiseMap = new float[mapDepth, mapWidth];

        for(int z = 0; z < mapDepth; z++) {
            for (int x = 0; x < mapWidth; x++) {
                // Normalize coordinates based on the provided scale
                float sampleX = x / scale;
                float sampleZ = z / scale;

                // Generate noise based off the psuedorandom function PerlinNoise
                noiseMap[z, x] = Mathf.PerlinNoise(sampleX, sampleZ);

            }
        }

        return noiseMap;
    }
}
