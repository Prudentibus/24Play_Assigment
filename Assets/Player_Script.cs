using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class Player_Script : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool gamePaused = true;

    [SerializeField] float cubePlacementOffset = 0.2f;
    [SerializeField] float bodyJumpStrength = 0.2f;
    [SerializeField] float playerStep = 0.01f;
    [SerializeField] float movingForwardSpeed = 0.5f;

    [Header("Camera Shaker")]
    [SerializeField] ShakePreset shakePreset;

    [Header("Misc")]
    [SerializeField] GameObject warpVFX;
    [SerializeField] Transform cubeIncreaseText;
    [SerializeField] Transform playerBody;
    [SerializeField] Transform playerCubesHolder;
    [SerializeField] UserInterface_Script uiScp;
    [SerializeField] Spawner_Script spawnScp;
    [SerializeField] VariableJoystick varJoystick;
    [SerializeField] Transform mainCam;

    private void Awake()
    {
        mainCam = Camera.main.transform.parent;
    }

    public void ChangeGamePauseState()
    {
        gamePaused = !gamePaused;
        warpVFX.SetActive(!gamePaused);

    }

    private void Update()
    {
        if (gamePaused)
            return;

        MoveForward();
        PlayerMovement();
    }

    #region Movement
    private void MoveForward()
    {
        Vector3 movePos = Vector3.left * movingForwardSpeed;

        this.transform.position += movePos;

        mainCam.transform.position += movePos;
    }


    private void PlayerMovement()
    {
        float movVal = varJoystick.Direction.x;

        if (movVal == 0)
            return;

        // Current treshold for Player movement on plane is 0.5f;
        // Might to make it flexible, for expending route?

        Vector3 newPos = this.transform.localPosition + (Vector3.forward * movVal * playerStep);
        
        //Debug.Log(string.Format("Cur newPos = {0}", newPos));

        if (Mathf.Abs(newPos.z) > 0.5f)
            return;

        this.transform.localPosition = newPos;


        //Debug.Log(string.Format("Cur Mov Val = {0}", movVal));
    }
    #endregion
    public void IncreaseCubeAmount(Transform newCube)
    {
        int childAm = playerCubesHolder.childCount;

        Transform lastChild = playerCubesHolder.GetChild(childAm-1);

        newCube.transform.parent = playerCubesHolder;

        newCube.tag = "PlayerYellowCube";

        float scaleY = lastChild.transform.localScale.y;

        Vector3 newPos = lastChild.localPosition + Vector3.up * (scaleY + cubePlacementOffset);

        newCube.transform.localPosition = newPos;

        GameObject newText = Instantiate(cubeIncreaseText.gameObject);

        newText.transform.position = newCube.transform.position;

        newText.SetActive(true);

        playerBody.transform.localPosition += Vector3.up * bodyJumpStrength; 

        //curBodyPos.y += 

    }

    //public void CallSpawningEvent()
    //{
    //    spawnScp.CallSpawningPlatformEvent();
    //}

    public void DecreaseCubeAmount()
    {
        Handheld.Vibrate();
        Debug.Log("I vibrated");

        Shaker.ShakeAll(shakePreset);
        

        spawnScp.CallSpawningPlatformEvent();

        if (playerCubesHolder.childCount != 0)
            return;

        DeathEvent();

    }

    public void DeathEvent()
    {
        // Death event
        playerBody.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        playerBody.GetComponent<Rigidbody>().AddForce(Vector3.left * 5f);

        ChangeGamePauseState();

        movingForwardSpeed = 0;

        Debug.Log("Player dead");

        uiScp.ShowEndGameScreen();

        warpVFX.SetActive(false);
    }



}
