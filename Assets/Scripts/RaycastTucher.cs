using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTucher : MonoBehaviour
{
    private TileControl Target;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray MyRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit Hit;
            if (Physics.Raycast(MyRay, out Hit, Mathf.Infinity))
            {
                if (Hit.transform.tag == "Player")
                {
                    Target = Hit.transform.GetComponent<TileControl>();
                    Target.RotateTile();
                }
            }
        }
    }
}