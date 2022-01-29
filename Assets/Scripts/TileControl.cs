using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour
{
    [SerializeField] private Transform targetRotation;
    private Quaternion NormalRot;
    private bool Rotated = false;
    public bool CanBeRotate = true;
    public int MyTipe = 0;
    public int MyNumber = 0;

    private void Start()
    {
        NormalRot = transform.rotation;
    }

    private void FixedUpdate()
    {
        if(!Rotated)
            transform.rotation = Quaternion.Lerp(transform.rotation, NormalRot, 0.1f);
        else
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation.rotation, 0.1f);
    }

    public void RotateTile()
    {
        if (CanBeRotate)
        {
            if (!Rotated)
            {
                Rotated = true;
                Camera.main.GetComponent<LevelMeneger>().SelectTile(this);
            }
            else
                Rotated = false;
        }
    }
}