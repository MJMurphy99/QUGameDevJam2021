using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLineScript : MonoBehaviour
{
    public LineRenderer fishingLine;
    public GameObject Lure, tipOfPole;

    // Update is called once per frame
    void Update()
    {
        fishingLine.startColor = Color.white;
        fishingLine.endColor = Color.white;
        List<Vector3> positions = new List<Vector3>();
        positions.Add(tipOfPole.transform.position);
        positions.Add(Lure.transform.position);
        fishingLine.startWidth = 0.1f;
        fishingLine.endWidth = 0.1f;
        fishingLine.SetPositions(positions.ToArray());
        fishingLine.useWorldSpace = true;
    }
}
