using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _playerDied;
    [SerializeField]
    private UnityEvent _squareCollected;
    [SerializeField]
    private float _scaleChangeDuration;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GlobalConstants.ALLY_TAG))
        {
            col.enabled = false;
            col.transform.DOScale(Vector3.zero, _scaleChangeDuration).OnComplete(() =>
            {
                _squareCollected.Invoke();
                Destroy(col.gameObject);
            });
        }
        if (col.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            Destroy(col.gameObject);
            _playerDied.Invoke();
        }
    }
}
