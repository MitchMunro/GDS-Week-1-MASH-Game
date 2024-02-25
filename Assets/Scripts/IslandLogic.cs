using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandLogic : MonoBehaviour
{
    private GameManager GM;

    private void Start()
    {
        GM = GameManager.Inst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerBoat")
        {
            GM.DeliverPeople();
        }
    }
}
