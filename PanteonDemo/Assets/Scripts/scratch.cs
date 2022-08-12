using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratch : MonoBehaviour
{

    public GameObject maskPrefab;
    private bool isPressed = false;

    

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 50;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (isPressed== true)
        {
            // GameObject maskSprite = Instantiate(maskPrefab, mousePos, Quaternion.identity );
            GameObject maskSprite=  Instantiate(maskPrefab, mousePos, Quaternion.Euler(180, 0, 0));
            maskSprite.transform.parent = gameObject.transform;
        }
        else
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }



        
    }
}
