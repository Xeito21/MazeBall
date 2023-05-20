using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Disruption : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float duration = 2f;
    public Ease easeType = Ease.Linear;

    private void Start()
    {
        MoveBlock();
    }

    private void MoveBlock()
    {
        transform.DOMove(endPoint.position, duration).SetEase(easeType).OnComplete(() =>
        {
            transform.DOMove(startPoint.position, duration).SetEase(easeType).OnComplete(() =>
            {
                MoveBlock(); 
            });
        });
    }
}
