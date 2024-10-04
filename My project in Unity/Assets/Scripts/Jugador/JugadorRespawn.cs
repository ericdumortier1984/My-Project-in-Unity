using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorRespawn : MonoBehaviour
{
    private float posicionCheckpointX, posicionCheckpointY;

    void Start()
    {
        if (PlayerPrefs.GetFloat("posicionCheckpointX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("posicionCheckpointX"), PlayerPrefs.GetFloat("posicionCheckpointY"));
        }
    }

    public void CheckpointEncontardo(float x, float y)
    {
        PlayerPrefs.SetFloat("posicionCheckpointX", x);
		PlayerPrefs.SetFloat("posicionCheckpointY", y);
	}
}
