using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionCube_Script : MonoBehaviour
{
    [SerializeField] Player_Script plrScp;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I detect " + other.name);

        switch (other.tag)
        {
            case "YellowCube":
                plrScp.IncreaseCubeAmount(other.transform);
                break;

            //case "SpawnTrigger":
            //    plrScp.CallSpawningEvent();
            //    break;

            default:
                break;
        }
    }
}
