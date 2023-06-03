using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Detonator detonatorScript;
    public Button StartTimerButton;
    public Button DetonateNowButton;

    public void Detonate()
    {
        disableButtons();
        detonatorScript.explode = true;
    }

    public void StartTimer()
    {
        disableButtons();
        detonatorScript.timerIsRunning = true;
    }

    void disableButtons()
    {
        StartTimerButton.GetComponent<Button>().interactable = false;
        DetonateNowButton.GetComponent<Button>().interactable = false;
    }
}
