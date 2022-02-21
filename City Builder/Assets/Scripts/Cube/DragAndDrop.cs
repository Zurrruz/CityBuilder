using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    Transform[] _original;
    [SerializeField]
    Transform[] _mask;
    [SerializeField]
    float[] _shiftCube;
    float _shift = 0.5f;

    public static bool isOn;
    private Transform _originalTmp;
    private Transform _maskTmp;
    private Vector3 _curPos;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            _curPos = hit.point + hit.normal * _shift;
        }

        if (_maskTmp)
        {
            _maskTmp.position = _curPos;
                
            if (Input.GetMouseButtonDown(0) && isOn)
            {
                _originalTmp.gameObject.SetActive(true);
                _originalTmp.position = _maskTmp.position;
                _originalTmp.localEulerAngles = _maskTmp.localEulerAngles;
                _originalTmp = null;
                isOn = false;
                Destroy(_maskTmp.gameObject);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(_originalTmp.gameObject);
                Destroy(_maskTmp.gameObject);
            }
        }
    }

    public void SetMask(int id)
    {
        foreach (var obj in _original)
        {
            string name = obj.name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];
            if(id.ToString() == name)
            {
                _originalTmp = Instantiate(obj);
                _originalTmp.gameObject.SetActive(false);
            }
        }

        foreach (Transform obj in _mask)
        {
            string name = obj.name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (id.ToString() == name)
            {
                _maskTmp = Instantiate(obj);
            }
        }

        _shift = _shiftCube[id - 1];
    }
}
