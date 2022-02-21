using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorComponent : MonoBehaviour
{

	[SerializeField] private string _prefabName;
	public string prefabName { get { return _prefabName; } }

    private void Start()
    {
        Generator.item.Add(this);
    }
    private void OnDestroy()
    {
        Generator.item.Remove(this);
    }

}

