using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    [SerializeField] GameObject terrain;
    int scale = 60;

    void Start() {

        for (int x = 0; x < scale; x++) {
            for (int y = 0; y < scale; y++) {
                for (int z = 0; z < scale; z++) {
                    
                    float randomMultiplier = .1f;

                    float averageNoise = Noise(x*randomMultiplier,y*randomMultiplier,z*randomMultiplier);

                    float random = Random.Range(5,6);
                    if (averageNoise >= random/10) {
                        Instantiate(terrain,new Vector3(x,y,z),Quaternion.identity);
                    }
                }
            }
        }
    }

    float Noise(float x, float y, float z) {

        float xy = Mathf.PerlinNoise(x,y);
        float yz = Mathf.PerlinNoise(y,z);
        float xz = Mathf.PerlinNoise(x,z);

        float yx = Mathf.PerlinNoise(y,x);
        float zy = Mathf.PerlinNoise(z,y);
        float zx = Mathf.PerlinNoise(z,x);

        float xyz = xy+yz+xz+yx+zy+zx;
        return xyz/6f;
    }
}
