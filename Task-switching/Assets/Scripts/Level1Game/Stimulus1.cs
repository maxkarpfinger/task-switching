using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stimulus1 : MonoBehaviour
{
    private bool dragging;
    bool canMove;

    Collider2D collider;

    void Update()
    {
        void Update()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
            {
                if (collider == Physics2D.OverlapPoint(mousePos))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
                if (canMove)
                {
                    dragging = true;
                }


            }
            if (dragging)
            {
                this.transform.position = mousePos;
            }
            if (Input.GetMouseButtonUp(0) || Input.touchCount <= 0)
            {
                canMove = false;
                dragging = false;
            }
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        collider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;
    }
}
