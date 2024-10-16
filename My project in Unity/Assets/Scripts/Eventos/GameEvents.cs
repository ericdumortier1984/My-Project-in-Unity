using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action OnPausa;
    public static event Action OnResumen;
    public static event Action OnVictoria;
    public static event Action OnDerrota;

	public static void TriggerPausa() => OnPausa?.Invoke();
    public static void TriggerResumen() => OnResumen?.Invoke();
    public static void TriggerVictoria() => OnVictoria?.Invoke();
	public static void TriggerDerrota() => OnDerrota?.Invoke();
}
