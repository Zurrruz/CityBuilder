using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    Transform _tile;
    public GameTiles.typeGameTiles type = GameTiles.typeGameTiles.none;
    

    [SerializeField]
    bool _baseTile;

    private void Awake()
    {
        if(_baseTile)
            GameBoard.createdBaseTiles.Add(this);
    }

    private void Start()
    {
        
        if (!_baseTile)
        {
            transform.parent.GetComponent<Tile>().type = type;
            GameBoard.CreateTile.Add(gameObject);
        }              
    }    


    private void OnDestroy()
    {
        GameBoard.CreateTile.Remove(gameObject);
    }

}
