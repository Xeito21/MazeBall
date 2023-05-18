using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] GameObject wallSliding;

    private bool isSpawn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isSpawn)
        {
            FindObjectOfType<AudioManager>().PlaySound("WallSliding");
            isSpawn = true;
            wallSliding.transform.DOMoveY(wallSliding.transform.position.y + 1.5f, 1f)
                .SetEase(Ease.OutBounce)
                .OnComplete(() =>
                {
                    wallSliding.transform.DOMoveY(wallSliding.transform.position.y - 1.5f, 1f)
                        .SetEase(Ease.OutBounce)
                        .SetDelay(5f);
                });


    }
}

}

