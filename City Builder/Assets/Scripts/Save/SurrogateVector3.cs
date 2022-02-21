using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SurrogateVector3
{

	public float x, y, z;

	public SurrogateVector3(float rX, float rY, float rZ)
	{
		x = rX;
		y = rY;
		z = rZ;
	}

	public static implicit operator Vector3(SurrogateVector3 rValue)
	{
		return new Vector3(rValue.x, rValue.y, rValue.z);
	}

	public static implicit operator SurrogateVector3(Vector3 rValue)
	{
		return new SurrogateVector3(rValue.x, rValue.y, rValue.z);
	}
}
