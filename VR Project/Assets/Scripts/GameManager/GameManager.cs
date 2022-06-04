using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameStatus { Start, Play, Die }

    public GameObject Player;
    // Assgin XR Origin OR Player Object
    // What Doing Player and GameManager Object go other Scene?

    public Canvas GameOverUI;
    private bool GameOverOnceChecked;
    public int BeforeSceneNumber;

    private void Awake()
    {
        // Object doesn't destroy even if scene change 
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameOverUI.gameObject);

        BeforeSceneNumber = -1;
        // SceneChange(Loaded) Event
        SceneManager.sceneLoaded += LoadedSceneEvent;
    }

    // If SceneLoading -> Re-Assign Player
    private void LoadedSceneEvent (Scene scene, LoadSceneMode mode)
    {
        // Re Assign Player.
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        GameOverOnceChecked = false;
    }

    // Update is called once per frame
    void Update()
    {
        // + If SceneLoaded -> Player X when before we re assign so check player exist!
        // if (Player.GetComponenet<have HP script name>().HP == 0)
        // GameOver and Go to GameOver Scene. 
        // Wrap this. "if (Player~~)"
        if (!GameOverOnceChecked)
        {
            GameOverOnceChecked = true;
            GameOverUI.gameObject.SetActive(true);

            BeforeSceneNumber = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine("ToGameOver");
        }
    }

    IEnumerator ToGameOver ()
    {
        Debug.Log("Execution");

        Image GameOverImage = GameOverUI.transform.GetChild(0).GetComponent<Image>();
        Color ImageColor = GameOverImage.color;

        for (float i = 0; i < 1; i += 0.01f)
        {
            ImageColor.a += 0.01f;
            GameOverImage.color = ImageColor;
            yield return new WaitForSeconds(0.01f);
        }

        GameOverOnceChecked = false;
        ImageColor.a = 0;
        GameOverImage.color = ImageColor;
        GameOverUI.gameObject.SetActive(false);

        // Check GameOver Scene name is "GameOver"
        SceneManager.LoadScene("GameOver");
    }
}
