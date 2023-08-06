using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ingridient lastDraged => lastDrag; 
    bool isDragActive;
    Vector2 Screenpos;
    Vector3 Worldpos;
    Ingridient lastDrag;
    public bool Won;
    public Potion pot;

    void Awake()
    {
        GameManager[] controller = FindObjectsOfType<GameManager>();
        if(controller.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(isDragActive && (Input.GetMouseButtonUp(0)))
        {
            Drop();
            return;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousepos = Input.mousePosition;
            Screenpos = new Vector2(mousepos.x, mousepos.y);
        } else 
        {
            return;
        }

        Worldpos = Camera.main.ScreenToWorldPoint(Screenpos);

        if(isDragActive)
        {
            Drag();
        }
        else 
        {
            RaycastHit2D hit = Physics2D.Raycast(Worldpos, Vector2.zero);
            if(hit.collider != null)
            {
                Ingridient drag = hit.transform.gameObject.GetComponent<Ingridient>();
                if(drag != null)
                {
                    lastDrag = drag;
                    InitDrag();
                }
            }
        }
    }
    void InitDrag()
    {
        lastDraged.LastPos = lastDraged.transform.position;
        UpdateDragStatus(true);
    }

    void Drag()
    {
        lastDrag.transform.position = new Vector2(Worldpos.x, Worldpos.y);
    }

    void Drop()
    {
        UpdateDragStatus(false);
        lastDrag.movePos = lastDrag.LastPos;
    }

    void UpdateDragStatus(bool isdragging)
    {
        isDragActive = lastDraged.isdragging = isdragging;
        lastDraged.gameObject.layer = isdragging ? 6 : 0;
    }
}
