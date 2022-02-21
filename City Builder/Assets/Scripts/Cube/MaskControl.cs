using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskControl : MonoBehaviour
{
    private string _canSpawnTag = "CanSpawn";
    public Color on = Color.green;
    public Color off = Color.red;
    private MeshRenderer[] _ren;

    void Start()
    {
        _ren = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in _ren)
        {
            r.material.color = on;
        }
        DragAndDrop.isOn = true;
    }
        
    private void OnTriggerStay(Collider other)
    {
        if(other.tag != _canSpawnTag)
        {
            foreach (MeshRenderer r in _ren)
            {
                r.material.color = off;
            }
            DragAndDrop.isOn = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != _canSpawnTag)
        {
            foreach (MeshRenderer r in _ren)
            {
                r.material.color = on;
            }
            DragAndDrop.isOn = true;
        }
    }
}
