using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// cria menus no unity
[CreateAssetMenu(menuName = "Iventory item")]

public class pickUpItem : ScriptableObject {

    [Tooltip("Sprite used in iventory list")]
    public Sprite icon;

    [Tooltip("3D Game Object used in scene")]
    public GameObject model;

    [Tooltip("Max number of objects player can carry")]
    public int maxCount;

}
