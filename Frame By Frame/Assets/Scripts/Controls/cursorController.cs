using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cursorController : MonoBehaviour
{


    public Camera mainCamera;
   

    public Transform selectedObject;
    void Start()
    {

        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        this.transform.position = new Vector2(mouse.x + .1f, mouse.y - 0.75f);
        if (SceneManager.GetActiveScene().buildIndex == 0)
            Cursor.visible = true;

    }


}