using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

}
