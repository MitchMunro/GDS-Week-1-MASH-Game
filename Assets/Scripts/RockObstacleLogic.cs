using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacleLogic : MonoBehaviour
{
    private void Start()
    {
        var rotation = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, 0, rotation));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Inst.GameOver();
    }
}
