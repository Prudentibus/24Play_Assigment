using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTextUp_Script : MonoBehaviour
{
    
    [SerializeField] float upOffset = 5;
    [SerializeField] Vector3 newPos;
    [SerializeField] float moveSpeed = 5;

    private void Start()
    {
        newPos = this.transform.position + (Vector3.up * upOffset);
        Destroy(this.gameObject, 2.5f);
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, newPos, moveSpeed * 0.001f);
    }
}
