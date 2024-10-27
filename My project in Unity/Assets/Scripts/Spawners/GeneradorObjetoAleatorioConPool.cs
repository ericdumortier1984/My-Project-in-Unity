using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneradorObjetoAleatorioConPool : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    private ObjectPool objetoPool;

	private void Awake()
	{
        objetoPool = GetComponent<ObjectPool>();
	}

	void Start()
	{
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
	}

	void GenerarObjetoAleatorio()
    {
        GameObject pooledObjeto = objetoPool.GetObjetoPooled();

		if (pooledObjeto != null)
		{
		  pooledObjeto.transform.position = transform.position;
		  pooledObjeto.transform.rotation = Quaternion.identity;
		  pooledObjeto.SetActive(true);
		}
	}

    private void OnBecameInvisible()
    {
        CancelInvoke(nameof(GenerarObjetoAleatorio));
    }

    private void OnBecameVisible()
    {
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }
}