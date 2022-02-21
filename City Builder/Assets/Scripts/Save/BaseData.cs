using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseData
{
	[System.NonSerialized] private GameObject _inst;
	public GameObject Inst { set { _inst = value; } }
	public string Name { get; set; }
	public SurrogateVector3 Position { get; set; }
	public SurrogateQuaternion Rotation { get; set; }

	public BaseData() { }

	public BaseData(string name, Vector3 position, Quaternion rotation)
	{
		this.Name = name;
		this.Position = position;
		this.Rotation = rotation;
	}

	public BaseData(GameObject current, string name, Vector3 position, Quaternion rotation)
	{
		this.Inst = current;
		this.Name = name;
		this.Position = position;
		this.Rotation = rotation;
	}

	public virtual void Update()
	{
		if (_inst == null)
		{
			this.Name = null;
			return;
		}

		Position = _inst.transform.position;
		Rotation = _inst.transform.rotation;
	}
}
