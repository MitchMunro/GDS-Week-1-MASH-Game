using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int PeopleOnBoat { get; private set; } = 0;
    [SerializeField] private int PeopleRescued = 0;

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

    public void PickUpPerson()
    {
        if(PeopleOnBoat < 3) PeopleOnBoat++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
