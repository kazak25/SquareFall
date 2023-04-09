using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameScreen;
    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private float _gameOverScreenShowDelay;
    [SerializeField]
    private GameObject _gameStartScreen;
    [SerializeField] private SquareSpawner _spawner;

    private bool _wasGameOver;
    
    
    public void StartGame()
    {
        _gameStartScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }
    private void Awake()
    {
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
        _gameStartScreen.SetActive(true);
    }
    public void RestartGame()
    {
        var sceneName = SceneManager.GetActiveScene().name; 
        SceneManager.LoadSceneAsync(sceneName); 
    }
    
    public void OnPlayerDied()
    {
        _wasGameOver = true;
        _spawner.enabled = false;
    }
    private void Update()
    {
        if (_wasGameOver)
        {
            _gameOverScreenShowDelay -= Time.deltaTime;

            if (_gameOverScreenShowDelay <= 0)
            {
                ShowGameOverScreen();
            }
        }
    }
    private void ShowGameOverScreen()
    {
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(true);
    }
}
