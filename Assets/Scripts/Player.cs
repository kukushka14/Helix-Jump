using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static NewBehaviourScript;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;
    public Platform CurrentPlatform;
    public Platform PreviousPlatform;
    [SerializeField] TextMeshProUGUI LevelNumber;
    [SerializeField] TextMeshProUGUI NextLevelNumber;
    public int level;
    public int score;
    private int record;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI RecordText;
    public AudioSource bounceAudio;
    public AudioSource breakAudio;

    public void Start()
    {
        level = PlayerPrefs.GetInt("My1", _level);
        score = PlayerPrefs.GetInt("My2", _score = -1);
        record = PlayerPrefs.GetInt("My");
        LevelNumber.text = level.ToString();
        NextLevelNumber.text = (level + 1).ToString();

    }

    private void OnTriggerEnter(Collider CurrentPlatform)
    {
        score++;
    }

    public void Update()
    {
        if (score > record) record = score;
        RecordText.text = "Best: " + record.ToString();
        ScoreText.text = score.ToString();
        PlayerPrefs.SetInt("My", record);
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        bounceAudio.Play();
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
        PlayerPrefs.SetInt("My1", level);
        PlayerPrefs.SetInt("My2", score);
        PlayerPrefs.DeleteAll();
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;
        PlayerPrefs.SetInt("My1", level + 1);
        PlayerPrefs.SetInt("My2", score);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        _int = record;
    }
}

