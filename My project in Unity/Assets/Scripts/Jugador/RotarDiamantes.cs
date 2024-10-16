using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarDiamantes : MonoBehaviour
{
    public float velocidadRotacion = 100f;

	private void Update()
	{
		transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
	}
}
