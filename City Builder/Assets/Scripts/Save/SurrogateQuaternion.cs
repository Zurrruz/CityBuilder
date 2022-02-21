using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SurrogateQuaternion
{

	public float x, y, z, w;

	public SurrogateQuaternion(float rX, float rY, float rZ, float rW)
	{
		x = rX;
		y = rY;
		z = rZ;
		w = rW;
	}

	public static implicit operator Quaternion(SurrogateQuaternion rValue)
	{
		return new Quaternion(rValue.x, rValue.y, rValue.z, rValue.w);
	}

	public static implicit operator SurrogateQuaternion(Quaternion rValue)
	{
		return new SurrogateQuaternion(rValue.x, rValue.y, rValue.z, rValue.w);
	}
}
