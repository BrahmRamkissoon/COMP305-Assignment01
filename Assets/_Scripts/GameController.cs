// Source file name: GameController.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 04/10/2015
// Date last Modified: 
// File description: Spawn waves of hazards on game start
// Revision history:    -   spawn hazards outside visible gamespace
//                      -   added loop for spawning waves
//                      -   added coroutine to wait between hazard spawns
//                      -   added while loop to get wait time between spawnWaves

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject hazard;       // hazard objects
    public int hazardCount;         // set number of hazards
    public Vector3 spawnValues;     // set location of hazard spawn
    public float spawnWait;         // wait time between waves
    public float startWait;         // wait time before game starts
    public float waveWait;          // wait time between waves

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y,
                    spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                // spawn with no rotation, this is already defined in RandomRotator.cs
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }
}
