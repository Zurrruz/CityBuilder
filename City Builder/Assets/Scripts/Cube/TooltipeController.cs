using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipeController : MonoBehaviour
{
    [SerializeField]
    GameObject _boxTooltipe;
    [SerializeField]
    GameObject _boxInfo;
    [SerializeField]
    Text _name;
    [SerializeField]
    Text _size;

    public static GameObject cube;

    private void Start()
    {
        TooltipCube.tooltipeBox += TooltipeIsActive;
        _boxTooltipe.SetActive(false);
        _boxInfo.SetActive(false);
    }
    private void OnDestroy()
    {
        TooltipCube.tooltipeBox -= TooltipeIsActive;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!CursorOverUI())
            {
                _boxInfo.SetActive(false);
                _boxTooltipe.SetActive(false);
            }
        }
    }
    private bool CursorOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }


    private void TooltipeIsActive(string name, string size)
    {
        _boxTooltipe.SetActive(true);
        _boxTooltipe.transform.position = Input.mousePosition;
        _name.text = name;
        _size.text = size;
    }

    public void InfoBoxIsActive()
    {
        _boxInfo.SetActive(true);
        _boxInfo.transform.position = _boxTooltipe.transform.position;
    }

    public void DeleteStrukture()
    {
        cube.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        Destroy(cube, 0.2f);
        _boxInfo.SetActive(false);
        _boxTooltipe.SetActive(false);
    }
}
