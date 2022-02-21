using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Cooking _cooking;

    [SerializeField]
    GameObject _drain;
    [SerializeField]
    GameObject _buildCube;

    private void Start()
    {
        _drain.SetActive(false);
        _buildCube.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!CursorOverUI())
            {
                _buildCube.SetActive(false);
                _drain.SetActive(false);
            }
        }
    }

    private bool CursorOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void Drain()
    {
        _drain.SetActive(true);
    }
    public void DrainTheWater()
    {
        _cooking.DrainTheWater();
        _drain.SetActive(false);
    }
    public void DrainTheSwamp()
    {
        _cooking.DrainTheSwamp();
        _drain.SetActive(false);
    }

    public void Build()
    {
        _buildCube.SetActive(true);
    }
    public void BuildIsNotActive()
    {
        _buildCube.SetActive(false);
    }
}
