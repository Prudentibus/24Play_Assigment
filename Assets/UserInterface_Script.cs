using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface_Script : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject startGameText;
    [SerializeField] GameObject tryAgainScreen;

   public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HideStartGameText()
    {
        startGameText.SetActive(false);
    }

    public void ShowEndGameScreen()
    {
        tryAgainScreen.SetActive(true);
    }

    [SerializeField] MilkShake.ShakePreset shakePreset;
    public void ShakeIt()
    {
        MilkShake.Shaker.ShakeAll(shakePreset);
    }

}
