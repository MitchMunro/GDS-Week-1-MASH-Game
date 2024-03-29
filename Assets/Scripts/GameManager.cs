using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public int PeopleOnBoat = 0; //{ get; private set; } = 0;
    public int PeopleRescued = 0;
    public TextMeshProUGUI PeopleOnBoatNumberText;
    public TextMeshProUGUI PeopleRescuedNumberText;

    public GameObject TitleScreenPanel;
    public GameObject VictoryPopUp;
    public GameObject GameOverPopUp;

    public bool IsGameOver { get; private set; } = false;

    public AudioSource SFX_Correct;
    public AudioSource SFX_ShipBell;
    public AudioSource SFX_Crash;

    public GameObject GO_Person;
    public GameObject GO_Rock;

    private void Awake()
    {
        //Set up GameController as a Singleton
        if (Inst == null)
        {
            Inst = this;
        }
        else
        {
            Debug.Log("Multiple Game controllers in scene. Deleting this one.");
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PeopleOnBoat = 0;
        PeopleRescued = 0;
        UpdateUI();

        RandomisePersonRockPlacement();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }
    }

    public bool DeliverPeople()
    {
        if(PeopleOnBoat > 0)
        {
            PeopleRescued += PeopleOnBoat;
            PeopleOnBoat = 0;

            SFX_Correct.Play();

            UpdateUI();
            CheckForVictory();

            return true;
        }
        else
        {
            Debug.Log("People on boat is less than 1.");
            return false;
        }

        
    }

    private void CheckForVictory()
    {
        if (PeopleRescued >= 5)
        {
            VictoryPopUp.SetActive(true);
        }

    }

    private void UpdateUI()
    {
        PeopleOnBoatNumberText.text = PeopleOnBoat.ToString();
        PeopleRescuedNumberText.text = PeopleRescued.ToString();

    }

    /// <summary>
    /// Returns true if the person can be picked up. Returns false if otherwise.
    /// </summary>
    /// <returns></returns>
    public bool PickUpPerson()
    {
        if (PeopleOnBoat < 3)
        {
            PeopleOnBoat++;
            UpdateUI();

            SFX_ShipBell.Play();
            return true;
        }
        else
        {
            return false;
        }
        
    }

    void RandomisePersonRockPlacement()
    {
        RandomPersonPlacement(GO_Person);
        RandomPersonPlacement(GO_Person);
        RandomPersonPlacement(GO_Person);
        RandomPersonPlacement(GO_Person);
        RandomPersonPlacement(GO_Person);

        RandomRockPlacement(GO_Rock);
        RandomRockPlacement(GO_Rock);
        RandomRockPlacement(GO_Rock);
        RandomRockPlacement(GO_Rock);
        RandomRockPlacement(GO_Rock);

        RandomRockPlacement(GO_Rock);
        RandomRockPlacement(GO_Rock);
        RandomRockPlacement(GO_Rock);
        RandomRockPlacement(GO_Rock);
        RandomRockPlacement(GO_Rock);


    }

    void RandomPersonPlacement(GameObject obj)
    {
        float x = 0;
        float y = 0;

        bool workDone = false;

        while (!workDone)
        {
            x = Random.Range(-0.5f, 14);
            y = Random.Range(-10, 10);
            Vector2 point = new Vector2(x, y);

            //This check doesn't work.
            Collider2D collider = Physics2D.OverlapCircle(point, 3f, 0);

            if (collider != null)
            {
                Debug.Log("Collider found, retrying.");
            }
            else
            {
                Instantiate(obj, new Vector3(x, y, 0), obj.transform.rotation);
                workDone = true;
            }
        }
    }

    void RandomRockPlacement(GameObject obj)
    {
        float x = 0;
        float y = 0;

        bool workDone = false;

        while (!workDone)
        {
            x = Random.Range(-4.3f, 10);
            y = Random.Range(-10, 10);
            Vector2 point = new Vector2(x, y);

            //This check doesn't work.
            Collider2D collider = Physics2D.OverlapCircle(point, 3f, 0);

            if (collider != null)
            {
                Debug.Log("Collider found, retrying.");
            }
            else
            {
                Instantiate(obj, new Vector3(x, y, 0), obj.transform.rotation);
                workDone = true;
            }
        }
    }

    public void GameOver()
    {
        IsGameOver = true;

        SFX_Crash.Play();

        VictoryPopUp.SetActive(false);
        GameOverPopUp.SetActive(true);
    }

    public void ResetScene()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
        Debug.Log("Game quit.");
        Application.Quit();
    }

    public void ButtonPlay()
    {
        TitleScreenPanel.SetActive(false);
    }

    public void ButtonReplay()
    {
        ResetScene();
    }

    public void ButtonQuit()
    {
        QuitGame();
    }


}
