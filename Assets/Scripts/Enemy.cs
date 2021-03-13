using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float top = 7f;
    [SerializeField] private float bottom = -5f;
    [SerializeField] private float left = -10.0f;
    [SerializeField] private float right = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters per second
        transform.Translate(new Vector3(0, -_speed, 0) * Time.deltaTime);

        //If bottom of screen respawn at top at a new random x position
        if (transform.position.y < bottom)
        {
            float randomX = Random.Range(left, right);
            transform.position = new Vector3(randomX, top, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if other is Player
        //damge the player
        //Destroy US


        //if other is laser
        //destroy laser
        //destroy us
    }

}
