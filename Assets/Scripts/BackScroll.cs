using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScroll : MonoBehaviour
{
    [SerializeField]
    float near = 5;
    [SerializeField]
    Vector2 min;
    GameObject camera;
    Camera cam;
    private float movecam;
    SpriteRenderer me;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        cam = camera.GetComponent<Camera>();
        movecam = camera.transform.position.x;
        me = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camrect = cam.ScreenToWorldPoint(Vector3.zero);
        if (transform.position.x <= camrect.x)
        {
            transform.position += new Vector3(me.bounds.size.x * 2 - 0.1f, 0, 0);
        }
        if (movecam < camera.transform.position.x)
        {
            transform.position -= new Vector3(near / 10 * (camera.transform.position.x - movecam),0,0);
            movecam = camera.transform.position.x;
        }
    }
}
