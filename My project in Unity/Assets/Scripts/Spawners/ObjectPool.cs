using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] private GameObject objetoPrefab;
	[SerializeField] private int tamanioPool = 0;

	private List<GameObject> objetosPooled;

	private void Start()
	{
		objetosPooled = new List<GameObject>();

		for (int i = 0; i < tamanioPool; i++)
		{
			GameObject obj = Instantiate(objetoPrefab);
			obj.SetActive(false);
			objetosPooled.Add(obj);
		}
	}

	public GameObject GetObjetoPooled()
	{
		foreach (GameObject obj in objetosPooled)
		{
			if (!obj.activeInHierarchy)
			{
				return obj;
			}
		}
		return null;
	}
}
