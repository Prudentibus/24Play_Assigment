using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube_Script : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "PlayerYellowCube":
                other.transform.parent = this.transform;

                GameObject.FindWithTag("Player").GetComponent<Player_Script>()
                    .DecreaseCubeAmount();
                break;

            case "PlayerPawn":
                other.transform.parent.parent.GetComponent<Player_Script>().DeathEvent();
                break;



            default:
                break;
        }

        //Debug.Log("I detect " + other.name);


    }
}
