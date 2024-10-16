using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionables : MonoBehaviour
{
	public List<GameObject> metas = new List<GameObject>();

	private void Start()
	{
		metas.AddRange(GameObject.FindGameObjectsWithTag("Meta"));
		foreach (GameObject meta in metas)
		{
			meta.SetActive(false); // Desactivar al inicio

		}
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
	
	public void ActivarMetas()
	{
		foreach (GameObject meta in metas)
		{
			meta.SetActive(true); // Activar cuando la palanca se mueve
		}
	}
}
