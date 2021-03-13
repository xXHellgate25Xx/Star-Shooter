using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = -1f;
    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0 , 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            ShootLaser();
        }
    }

    private void ShootLaser()
    {
        //If hit the shoot key (space)
        //Spawns a laser from prefab

            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
    }

    private void CalculateMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(HorizontalInput, VerticalInput);

        transform.Translate(direction * _speed * Time.deltaTime);

        //Restrain the player bounds
        // y bound: -1 <= y <= 2

        if (transform.position.y >= 2)
        {
            transform.position = new Vector3(transform.position.x, 2, 0);
        }
        else if (transform.position.y <= -1)
        {
            transform.position = new Vector3(transform.position.x, -1, 0);
        }

        //X bound: -7 <= x <= 7
        if (transform.position.x >= 7)
        {
            transform.position = new Vector3(-7, transform.position.y, 0);
        }
        else if (transform.position.x <= -7)
        {
            transform.position = new Vector3(7, transform.position.y, 0);
        }
    }
}
