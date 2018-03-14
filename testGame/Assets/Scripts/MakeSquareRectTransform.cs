using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeSquareRectTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
        RectTransform rt = GetComponent<RectTransform>();

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rt.rect.height);
	}
	
}
