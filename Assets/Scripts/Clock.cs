using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject _hour;
    [SerializeField] private GameObject _minute;
    [SerializeField] private GameObject _second;

    private void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;

        //h -30 m -6 s -6
        _hour.transform.localRotation = Quaternion.Euler(0f, 0f, -30f * (float)time.TotalHours);
        _minute.transform.localRotation = Quaternion.Euler(0f, 0f, -6f * (float)time.TotalMinutes);
        _second.transform.localRotation = Quaternion.Euler(0f, 0f, -6f * (float)time.TotalSeconds);
    }
}
