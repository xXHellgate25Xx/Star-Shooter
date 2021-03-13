using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _laserspeed = 8f;
    [SerializeField] private float _delete = 6f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, _laserspeed, 0) * Time.deltaTime);

        if (transform.position.y > _delete)
        {
            Destroy(this.gameObject, .5f);
        }
    }
}
