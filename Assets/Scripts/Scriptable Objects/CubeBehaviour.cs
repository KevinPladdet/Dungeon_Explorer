using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cube", menuName = "Cube")]

public class CubeBehaviour : ScriptableObject
{
    public new string name;
    public string description;

    public int rotationSpeed;

    public bool enableRandomColor;

    public Color cubeColor;
}
