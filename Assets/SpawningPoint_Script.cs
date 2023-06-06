using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPoint_Script : MonoBehaviour
{
    public Transform redCubeSpawningHolder;

    [Header("Settings")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Yellow Cube Settings")]
            public GameObject yellowCube;
    [SerializeField] int yellowCubeAmountSpawn = 3;
    [SerializeField] float yellowCubeLocalOffset = 0.25f;

    [SerializeField]List<int> yellowCubeSpawnLocalPos = new List<int>()
    { -1,0,1 };

    private void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;

        int randID = Random.Range(0, redCubeSpawningHolder.childCount);

        GameObject newObj = Instantiate(redCubeSpawningHolder.GetChild(randID).gameObject);

        newObj.transform.parent = this.transform;

        newObj.transform.localPosition = Vector3.zero;

        newObj.SetActive(true);

        SpawnYellowCubes();
    }

    private void Update()
    {
        MoveTowardOrigin();
    }

    private void MoveTowardOrigin()
    {
        Vector3 curPos = this.transform.parent.localPosition;
        Vector3 newPos = new Vector3(curPos.x,0,curPos.z);

        if (Mathf.Abs(curPos.y) == 0)
            return;

        this.transform.parent.localPosition = Vector3.MoveTowards(curPos, newPos, moveSpeed*0.001f);
    }

    private void SpawnYellowCubes()
    {
        int len = yellowCubeAmountSpawn;

        float xOffset = yellowCubeLocalOffset*2;

        for (int i = 0; i < len; i++)
        {
            GameObject newObj = Instantiate(yellowCube);

            newObj.transform.parent = this.transform.parent;

            xOffset -= yellowCubeLocalOffset;

            float z = yellowCubeLocalOffset * yellowCubeSpawnLocalPos[Random.Range(0, yellowCubeSpawnLocalPos.Count)];

            newObj.transform.localPosition = new Vector3(xOffset, 0.62f, z);

            newObj.SetActive(true);
        }
    }



}
