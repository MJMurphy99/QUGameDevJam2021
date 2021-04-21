using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammunition", menuName = "AmmoType")]
public class Ammunition : ScriptableObject
{
    public float speed, recoil, damage;
    public int range;

}
