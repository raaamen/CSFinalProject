using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Resolution")]
public class Resolution : ScriptableObject
{
    public string dimensions;
    public int width;
    public int height;
}
