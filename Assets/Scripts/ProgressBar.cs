using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player player;
    public Transform FinishPlatform;
    public Slider Slider;
    public float AcceptableFinishPlayerDistance = 1f;

    private float _startY;
    private float _minimumReachedY;

    private void Start()
    {
        _startY = player.transform.position.y;
    }

    private void Update()
    {
        _minimumReachedY = Mathf.Min(_minimumReachedY, player.transform.position.y);
        float finishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_startY - 2*AcceptableFinishPlayerDistance, finishY + AcceptableFinishPlayerDistance, _minimumReachedY);
        Slider.value = t;
    }
}
