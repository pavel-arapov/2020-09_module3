using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas = default;
    
    // [SerializeField] private Character character; 
    // Start is called before the first frame update
    void Start() {
        gameOverCanvas.enabled = false;
        Character.InDeadArea += InDeadArea;
        Time.timeScale = 1.0f;
    }

    private void OnDestroy() {
        Character.InDeadArea -= InDeadArea;
    }

    private void InDeadArea() {
        Character.InDeadArea -= InDeadArea;
        Time.timeScale = 0.0f;
        gameOverCanvas.enabled = true;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
