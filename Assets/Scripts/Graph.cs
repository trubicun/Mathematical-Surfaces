using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform _pointPrefab = default;
    [SerializeField] private int _resolution = 100;
    [SerializeField]
    private FunctionLibrary.FunctionName function = default;
    private Transform[] _points;

    private void Awake()
    {
        float step = 2f / _resolution;
        Vector3 scale = new Vector3(0.1f, 0.1f, 0.1f);
        _points = new Transform[_resolution * _resolution];
        for (int i = 0; i < _points.Length; i++)
        {
            Transform point = Instantiate(_pointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            _points[i] = point;
        }
    }

    private void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float step = 2f / _resolution;
        float v = 0.5f * step - 1f;
        for (int i = 0, x = 0, z = 0; i < _points.Length; i++, x++)
        {
            if (x == _resolution) { 
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            _points[i].localPosition = f(u, v, Time.time);
        }
    }
}
