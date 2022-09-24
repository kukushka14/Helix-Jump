using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static NewBehaviourScript;

public class Game : MonoBehaviour
{
    public Control Controls;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {

        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        SceneManager.LoadScene("Lose_Scene");
    }

    public void OnPlayerReachedFinish()
    {

        if (CurrentState != State.Playing) return;
        CurrentState= State.Won;
        Controls.enabled = false;
        SceneManager.LoadScene("Win_Scene");

    }

}
