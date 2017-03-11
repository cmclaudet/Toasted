using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class move {
	private static int tileLength = 96;

	public static Vector3 moveOneTile (Vector2 direction) {
		Vector3 deltaPosition = direction * tileLength;
		return deltaPosition;
	}
}
