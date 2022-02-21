using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField]
    Tile _baseTilePrefab;
    [SerializeField]
    Tile _struktureTilePrefab;
    [SerializeField]
    Tile _swampTilePrefabs;
    [SerializeField]
    Tile _waterTilePrefabs;
    [SerializeField]
    Tile _grassTilePrefabs;
    [SerializeField]
    Tile _sendTilePrefabs;

    List<GameTiles.typeGameTiles> _type = new List<GameTiles.typeGameTiles>();
    public static List<Tile> createdBaseTiles;
    public static List<GameObject> CreateTile = new List<GameObject>();

    public void InitializeField(Vector2Int size)
    {        
        Vector2 offset = new Vector2((size.x - 1) * 0.5f, (size.y - 1) * 0.5f);

        createdBaseTiles = new List<Tile>(size.x * size.y);
        for (int i = 0, y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++, i++)
            {
                Tile tile = Instantiate(_baseTilePrefab);
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = new Vector3(x - offset.x, 0f, y - offset.y);
            }
        }
    }

    public void LocationGeneration(float strukture, float water, float swamp)
    {
        List<Tile> _generationTile = new List<Tile>();

        foreach (var bP in createdBaseTiles)
        {
            _generationTile.Add(bP);
        }

        for (int s = 0; s < createdBaseTiles.Count * strukture / 100; s++)
        {
            int r = Random.Range(0, _generationTile.Count);
            Instantiate(_struktureTilePrefab, _generationTile[r].transform);
            _generationTile.RemoveAt(r);
        }

        for (int w = 0; w < createdBaseTiles.Count * water / 100; w++)
        {
            int r = Random.Range(0, _generationTile.Count);
            Instantiate(_waterTilePrefabs, _generationTile[r].transform);            
            _generationTile.RemoveAt(r);
        }

        for (int sw = 0; sw < createdBaseTiles.Count * swamp / 100; sw++)
        {
            int r = Random.Range(0, _generationTile.Count);
            Instantiate(_swampTilePrefabs, _generationTile[r].transform);
            _generationTile.RemoveAt(r);
        }

        for (int i = 0; i < _generationTile.Count; i++)
        {
            int d = Random.Range(0, 2);
            if (d == 0)
            {
                Instantiate(_grassTilePrefabs, _generationTile[i].transform);
            }
            else
            {
                Instantiate(_sendTilePrefabs, _generationTile[i].transform);
            }
        }
    }

    public List<Tile> CreatedBaseTiles()
    {
        return createdBaseTiles;
    }   

    public void SaveType()
    {
        _type.Clear();

        for (int i = 0; i < createdBaseTiles.Count; i++)
        {
            _type.Add(createdBaseTiles[i].GetComponent<Tile>().type);
        }
    }

    public void LoadTile()
    {
        foreach (var item in CreateTile)
        {
            Destroy(item);
        }
        for (int i = 0; i < createdBaseTiles.Count; i++)
        {
            createdBaseTiles[i].GetComponent<Tile>().type = _type[i];
        }

        foreach (var item in createdBaseTiles)
        {
            if(item.GetComponent<Tile>().type == GameTiles.typeGameTiles.grass)
                Instantiate(_grassTilePrefabs, item.transform);
            else if (item.GetComponent<Tile>().type == GameTiles.typeGameTiles.sand)
                Instantiate(_sendTilePrefabs, item.transform);
            else if (item.GetComponent<Tile>().type == GameTiles.typeGameTiles.structure)
                Instantiate(_struktureTilePrefab, item.transform);
            else if (item.GetComponent<Tile>().type == GameTiles.typeGameTiles.swamp)
                Instantiate(_swampTilePrefabs, item.transform);
            else if (item.GetComponent<Tile>().type == GameTiles.typeGameTiles.water)
                Instantiate(_waterTilePrefabs, item.transform);
        }
    }
}
