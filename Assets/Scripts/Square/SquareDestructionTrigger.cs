using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SquareDestructionTrigger : MonoBehaviour
{
    [SerializeField] private float scaleChangeDuration;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.enabled = false;
        collider.transform.
            DOScale(Vector3.zero, scaleChangeDuration).
            OnComplete(() => Destroy(collider.gameObject));

    }
}
