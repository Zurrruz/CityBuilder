using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{
	[SerializeField]
	GameBoard _gameBoard;

	public static List<GeneratorComponent> item = new List<GeneratorComponent>();

	private SceneState state;
	private string dataPath;
	private static Generator _inst;

	void Awake()
	{
		_inst = this;
		dataPath = Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + ".dat";		
	}

	public static void InstantiateItem(string prefabName, Vector3 position, Quaternion rotation)
	{
		_inst.InstantiateItem_inst( prefabName, position, rotation);
	}

	void InstantiateItem_inst( string prefabName, Vector3 position, Quaternion rotation)
	{
		GameObject obj = Resources.Load<GameObject>(prefabName);

		if (obj != null)
		{
			//state.AddItem(new BaseData(Instantiate(obj, position, rotation), prefabName, position, rotation));
			state.AddItem(new BaseData(obj, prefabName, position, rotation));
		}
	}

	void Clear() // очистка сцены
	{
		for (int i = 0; i < item.Count; i++)
		{
			item[i].gameObject.SetActive(false);
			Destroy(item[i].gameObject);
		}
	}

	void SetDefault()
	{
		state = new SceneState();

		for (int i = 0; i < item.Count; i++)
		{
			if (!string.IsNullOrEmpty(item[i].prefabName))
			{				
				state.AddItem(new BaseData(item[i].gameObject, item[i].prefabName, item[i].transform.position, item[i].transform.rotation));
			}
		}		
	}

	void Generate()
	{
		Clear();

		foreach (BaseData t in state.itemList)
		{
			if (!string.IsNullOrEmpty(t.Name))
			{
				t.Inst = Instantiate(Resources.Load<GameObject>(t.Name), t.Position, t.Rotation) as GameObject;
			}
		}
	}

	public void LoadScene()
    {
		dataPath = Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + ".dat";
		if (File.Exists(dataPath))
		{
			state = Serializator.LoadBinary(dataPath);
			Generate();
			_gameBoard.LoadTile();
		}		
	}

	public void SaveScene()
	{
		_gameBoard.SaveType();
		SetDefault();
		state.Update();
		Serializator.SaveBinary(state, dataPath);
	}
}
