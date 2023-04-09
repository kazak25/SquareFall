using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SquareController : MonoBehaviour
{
    [SerializeField]
    private float _rotationPower;
    [SerializeField]
    private float _speed;
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    


    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rotationPower *= GetRandomSign();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.rotation += _rotationPower;
        _rigidbody2D.velocity = _direction*_speed;

    }
    
    private int GetRandomSign()
    {
        var randomNumber = UnityEngine.Random.Range(0, 2); //данный метод вернет от 0 до 1
        return randomNumber == 1 ? 1 : -1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
