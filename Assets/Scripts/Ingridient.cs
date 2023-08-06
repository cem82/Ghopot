using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingridient : MonoBehaviour 
{
    public bool isdragging;
    Collider2D col;
    public System.Nullable<Vector3> movePos;
    GameManager gm;
    [SerializeField] float moveTime;
    public Vector3 LastPos;
    [SerializeField] float time;
    void Start()
    {
        col = GetComponent<Collider2D>();
        gm = FindObjectOfType<GameManager>();
    }
    void FixedUpdate()
    {
        if(movePos.HasValue)
        {
            if(isdragging)
            {
                movePos = null;
                return;
            }
            if(transform.position == movePos)
            {
                gameObject.layer = 0;
                movePos = null;
            }
            else 
            {
                StartCoroutine(Back());
            }
        }
    }

    IEnumerator Back()
    {
        yield return new WaitForSeconds(time);
        transform.position = movePos.Value;
    }
}