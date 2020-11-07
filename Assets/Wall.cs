using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

[RequireComponent(typeof(PoolObject))]
public class Wall : MonoBehaviour
{
    [SerializeField] private float finalPosition = -15;
    [SerializeField] private Ease ease = Ease.Flash;

    private PoolObject pool;

    private void Start()
    {
        pool = GetComponent<PoolObject>();
    }
    private void OnEnable()
    {
        transform
            .DOMoveY(finalPosition, MapGenerator.instance.DurationWall)
            .SetEase(ease)
            .OnComplete(() => pool.Return());
            
    }

   
}
