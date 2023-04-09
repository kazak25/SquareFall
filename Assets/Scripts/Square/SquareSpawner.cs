using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SquareSpawner : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField]
    private SquareController[] _squarePrefabs;//массив префабов класса SquareController

    [SerializeField]
    private float _minSpawnTime;//минимальное время между спавном
    [SerializeField]
    private float _maxSpawnTime;//максимальное время между спавном

    [SerializeField]
    private Transform _leftSpawnBorder;//левая граница спавна
    [SerializeField]
    private Transform _rightSpawnBorder;//правая граница спавна

    [SerializeField]
    private Transform _leftTargetBorder;//левая граница цели
    [SerializeField]
    private Transform _rightTargetBorder;//правая граница цели

    private float _delayBeforeNextSpawn;//задержка перед следующим спавном куба

    private void Update()
    {
        if (_delayBeforeNextSpawn > 0)
        {
            _delayBeforeNextSpawn -= Time.deltaTime;
            return;
        }
        var square =  SpawnRandomSquare();
       var targetDirection = GetTargetDirection(square);
       square.SetDirection(targetDirection);
       _delayBeforeNextSpawn = UnityEngine.Random.Range(_minSpawnTime, _maxSpawnTime);


    }
    private Vector3 GenerateRandomPointOnLine(Transform left, Transform right)
    {
        var progress = UnityEngine.Random.Range(0f, 1f);
        return Vector3.Lerp(left.position,right.position,progress);
    }

    private SquareController SpawnRandomSquare()
    {
        var randomPrefab = UnityEngine.Random.Range(0, _squarePrefabs.Length);
        var square = Instantiate(_squarePrefabs[randomPrefab],transform);
        square.transform.position = GenerateRandomPointOnLine(_leftSpawnBorder,_rightSpawnBorder);
        return square;
    }
    private Vector3 GetTargetDirection(SquareController square)
    {
        var targetPosition = GenerateRandomPointOnLine(_leftTargetBorder, _rightTargetBorder);
        var direction = targetPosition - square.transform.position;
        return direction;
    }
}
