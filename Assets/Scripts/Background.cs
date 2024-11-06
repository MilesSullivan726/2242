using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //obtain starting coordinates and distance to repeat background
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //move background down and repeat when background is halfway past its original position
        transform.Translate(Vector3.down * Time.deltaTime * 15);

        if(transform.localPosition.y < startPos.y - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
