using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject adventurer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = adventurer.transform.position.x;
        position.y = adventurer.transform.position.y;
        transform.position = position;
    }
}
