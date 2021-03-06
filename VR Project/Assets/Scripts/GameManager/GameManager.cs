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
    public Canvas RGameOverUI;
    private bool GameOverOnceChecked;
    public int BeforeSceneNumber;

    public GameObject BloodScreen;

    public bool sceneChangerClicked = false;
    private bool firstEnter = true;
    

    private void Awake()
    {
        // Object doesn't destroy even if scene change 
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameOverUI.gameObject);
        DontDestroyOnLoad(GameObject.Find("XR Interaction Manager"));

        Player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("XROrigin"));

        BeforeSceneNumber = -1;
        // SceneChange(Loaded) Event
        SceneManager.sceneLoaded += LoadedSceneEvent;
    }

    // If SceneLoading -> Re-Assign Player
    private void LoadedSceneEvent (Scene scene, LoadSceneMode mode)
    {
        /* // Re Assign Player.
        Player = GameObject.FindGameObjectWithTag("Player"); */

        Player.transform.parent.parent.transform.position = GameObject.Find("SpawnPosition").transform.position; 
        Player.GetComponent<PlayerManager>().playerHP = 3;

        if(GameObject.Find("M1911 Handgun_Model").GetComponent<SimpleShoot>().getWeapon)
        {
            GameObject.Find("M1911 Handgun_Black (Shooting)").transform.position = GameObject.Find("Player").transform.position + new Vector3(0, 1,0);
            GameObject.Find("M1911 Magazine_Black").transform.position = GameObject.Find("Socket(WeaponOnly)").transform.position + new Vector3(0, 1, 0);
            GameObject.Find("M1911 Magazine_Black (1)").transform.position = GameObject.Find("Socket(ManagizeOnly)").transform.position + new Vector3(0, 1, 0);
        }

        StartMenu();

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
        if (Player.GetComponent<PlayerManager>().playerHP <= 0)
        {
            // GameOver and Go to GameOver Scene. 
            // Wrap this. "if (Player~~)"
            if (!GameOverOnceChecked)
            {
                Player.GetComponent<PlayerManager>().playerHP = 3;
                GameOverOnceChecked = true;
                GameOverUI.gameObject.SetActive(true);

                BeforeSceneNumber = SceneManager.GetActiveScene().buildIndex;
                StartCoroutine("ToGameOver");
            }
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
        BloodScreen.SetActive(false);
        RGameOverUI.gameObject.SetActive(true);
        SceneManager.LoadScene("GameOver");
    }

    public void SceneChanger(int sceneNum)
    {
        if(sceneNum == 2)
        {
            GameObject.Find("M1911 Handgun_Black (Shooting)").transform.GetComponent<GetWeaponParent>().GetParent();
            GameObject.Find("M1911 Handgun_Model").GetComponent<SimpleShoot>().GetWeaponFirst();
            SceneManager.LoadScene("Floor 2");
        }
        else if(sceneNum == 3)
        {
            GameObject.Find("M1911 Handgun_Black (Shooting)").transform.GetComponent<GetWeaponParent>().GetParent();
            GameObject.Find("M1911 Handgun_Model").GetComponent<SimpleShoot>().GetWeaponFirst();
            SceneManager.LoadScene("Floor 3");
        }

    }

    public void StartMenu()
    {
        if(firstEnter == true )
        {
            firstEnter = false;
            Time.timeScale = 0.0f;
        }
    }

    public void StartGame()
    {
        GameObject.Find("dropDownSceneSelect").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void CheckBtnClick()
    {
        switch (GameObject.Find("dropDownSceneSelect").GetComponentInChildren<Dropdown>().value)
        {
            case 0:
                GameObject.Find("dropDownSceneSelect").gameObject.SetActive(false);
                Time.timeScale = 1.0f;
                break;
            case 1:
                Time.timeScale = 1.0f;
                SceneChanger(2);
                break;
            case 2:
                Time.timeScale = 1.0f;
                SceneChanger(3);
                break;
        }
    }
}
