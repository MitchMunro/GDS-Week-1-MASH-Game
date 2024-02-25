using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public int PeopleOnBoat = 0; //{ get; private set; } = 0;
    public int PeopleRescued = 0;

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
    }

    public void DeliverPeople()
    {
        PeopleRescued += PeopleOnBoat;
        PeopleOnBoat = 0;
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
            return true;
        }
        else
        {
            return false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
