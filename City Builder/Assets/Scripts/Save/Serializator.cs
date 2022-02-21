using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Serializator
{

	public static void SaveBinary(SceneState state, string dataPath)
	{
		BinaryFormatter binary = new BinaryFormatter();
		FileStream stream = new FileStream(dataPath, FileMode.Create);
		binary.Serialize(stream, state);
		stream.Close();
		Debug.Log("[Serializator] --> Сохранение по адресу: " + dataPath);
	}

	public static SceneState LoadBinary(string dataPath)
	{
		BinaryFormatter binary = new BinaryFormatter();
		FileStream stream = new FileStream(dataPath, FileMode.Open);
		SceneState state = (SceneState)binary.Deserialize(stream);
		stream.Close();
		Debug.Log("[Serializator] --> Загрузка данных из файла: " + dataPath);
		return state;
	}
}