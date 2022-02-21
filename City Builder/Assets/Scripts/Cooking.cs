using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField]
    GameBoard _gameBoard;

    [SerializeField]
    Tile _swampTilePrefabs;
    [SerializeField]
    Tile _sendTilePrefabs;

    public void DrainTheWater()
    {
        foreach (var tile in GameBoard.CreateTile)
        {
            if (tile.GetComponent<Tile>().type == GameTiles.typeGameTiles.water)
                Destroy(tile);
        }

        foreach (var tile in _gameBoard.CreatedBaseTiles())
        {
            if (tile.type == GameTiles.typeGameTiles.water)
            {
                Instantiate(_swampTilePrefabs, tile.transform);
            }
        }
    }

    public void DrainTheSwamp()
    {
        foreach (var tile in GameBoard.CreateTile)
        {
            if (tile.GetComponent<Tile>().type == GameTiles.typeGameTiles.swamp)
                Destroy(tile);
        }

        foreach (var tile in _gameBoard.CreatedBaseTiles())
        {
            if (tile.type == GameTiles.typeGameTiles.swamp)
            {
                Instantiate(_sendTilePrefabs, tile.transform);
            }
        }
    }
}