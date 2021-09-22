using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speed;

    private float theta;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(-20f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        theta = (theta + Time.deltaTime * speed) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, theta);
    }
}
