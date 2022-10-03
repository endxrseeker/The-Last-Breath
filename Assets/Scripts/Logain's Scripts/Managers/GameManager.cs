using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Scene Play_Scene;

    public Button m_NewGameButton;
    public Button m_QuitGameButton;
    public Button m_RestartButton;

    public Text m_TitleText;
    public Text m_DeadText;

    public Image m_background;

    private GameState Player_GameState;
    private GameObject Player;

    public GameState State { get { return Player_GameState; } }

    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

    private void Awake()
    {
        Player_GameState = GameState.Start;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        m_NewGameButton.gameObject.SetActive(false);
        m_QuitGameButton.gameObject.SetActive(false);
        m_background.gameObject.SetActive(false);
        m_RestartButton.gameObject.SetActive(false);
        m_TitleText.gameObject.SetActive(false);
        m_DeadText.gameObject.SetActive(false);
        Cursor.visible = false;
        
        
    }

    void Update()
    {
        switch (Player_GameState)
        {
            case GameState.Start:
               
                m_NewGameButton.gameObject.SetActive(true);
                m_QuitGameButton.gameObject.SetActive(true);
                m_background.gameObject.SetActive(true);
                m_TitleText.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Player.SetActive(false);


            break;

            case GameState.Playing:
                bool isGameOver = false;

                m_NewGameButton.gameObject.SetActive(false);
                m_QuitGameButton.gameObject.SetActive(false);
                m_background.gameObject.SetActive(false);
                m_TitleText.gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Player.SetActive(true);

                if (Input.GetKeyUp(KeyCode.T) == true)
                {
                    isGameOver = true;
                }

                if (isGameOver == true)
                {
                    Player_GameState = GameState.GameOver;
                                       
                }
                break;

            case GameState.GameOver:
                
                m_RestartButton.gameObject.SetActive(true);
                m_QuitGameButton.gameObject.SetActive(true);
                m_background.gameObject.SetActive(true);
                m_DeadText.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Player.SetActive(false);

            break;

        }

    }

    public void OnNewGame()
    {
        Player_GameState = GameState.Playing;
    }
        
    public void OnRestart()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
