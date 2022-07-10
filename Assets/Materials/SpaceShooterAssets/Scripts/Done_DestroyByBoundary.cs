using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit(Collider Other)
	{
		Destroy(Other.gameObject);
	}
}
