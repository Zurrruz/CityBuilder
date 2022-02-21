using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGeneration : MonoBehaviour
{
	[SerializeField]
	Vector2Int _boardSize = new Vector2Int(10, 10);

	[SerializeField]
	GameBoard _board;

	[Header("Генерация ландшафта в %")]
	[SerializeField]
	float _structure;
	[SerializeField]
	float _water;
	[SerializeField]
	float _swamp;

	[SerializeField]
	List<Tile> _tiles = new List<Tile>();
	

	void Awake()
	{
		_board.InitializeField(_boardSize);
	}
	void OnValidate()
	{
		if (_boardSize.x < 2)
		{
			_boardSize.x = 2;
		}
		if (_boardSize.y < 2)
		{
			_boardSize.y = 2;
		}
	}

    private void Start()
    {
		_board.LocationGeneration(_structure, _water, _swamp);
    }
}
