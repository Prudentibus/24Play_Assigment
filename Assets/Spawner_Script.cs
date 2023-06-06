using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Script : MonoBehaviour
{
    [SerializeField] Transform spawnerHolder;
    [SerializeField] GameObject template;

    [SerializeField] float nextSpawningCoordinate = 0;

    [Header("Spawn Settings")]
    [SerializeField] float spawnOffset = 10;

    [Header("Misc")]
    [SerializeField] Transform redCubeSpawnHolder;
    [SerializeField] GameObject yellowCube;

    private bool canSpawn = true;

    private void Start()
    {
        nextSpawningCoordinate = template.transform.localScale.x * -spawnerHolder.childCount;
    }

    public void CallSpawningPlatformEvent()
    {
        if (!canSpawn)
            return;

        GameObject newObj = Instantiate(template);

        newObj.transform.parent = this.transform;

        Vector3 newPos = new Vector3(nextSpawningCoordinate, -spawnOffset, 0);

        newObj.transform.localPosition = newPos;

        SpawningPoint_Script objScp = newObj.transform.GetChild(0)
            .GetComponent<SpawningPoint_Script>();

        objScp.redCubeSpawningHolder = this.redCubeSpawnHolder;
        objScp.yellowCube = this.yellowCube;

        nextSpawningCoordinate -= template.transform.localScale.x;

        newObj.SetActive(true);

        canSpawn = false;

        //Handicap :D?
        Invoke("AllowSpawningAgain", 0.5f);

    }

    private void AllowSpawningAgain()
    {
        canSpawn = true;
    }
}
