using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    public List<GameObject> metas = new List<GameObject>();

	private void Start()
	{
		metas.AddRange(GameObject.FindGameObjectsWithTag("Meta"));
	}

	public void RecogerMeta(GameObject meta)
	{
		if (metas.Contains(meta))
		{
			metas.Remove(meta);
			Destroy(meta);
		}
	}

	public bool TodasLasMetasRecogidas()
	{
		return metas.Count == 0;
	}
}
