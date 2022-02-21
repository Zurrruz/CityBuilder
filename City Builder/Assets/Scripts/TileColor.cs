using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour
{
    public Color on;
    public Color off = Color.black;
    private MeshRenderer[] _ren;
    Tile _tile;

    private void Start()
    {
        _tile = transform.parent.GetComponent<Tile>();
        _ren = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in _ren)
        {
            r.material.color = on;
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    foreach (MeshRenderer r in _ren)
    //    {
    //        r.material.color = off;
    //    }
    //    transform.tag = "Not";
    //}

    private void OnCollisionExit(Collision collision)
    {
        foreach (MeshRenderer r in _ren)
        {
            if(transform.tag != "not")
                r.material.color = on;
        }
        transform.tag = "CanSpawn";
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (MeshRenderer r in _ren)
        {
            r.material.color = off;
        }
        transform.tag = "Not";
    }

    
}

