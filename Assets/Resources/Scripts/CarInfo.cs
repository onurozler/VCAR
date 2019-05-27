using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Car")]
public class CarInfo : ScriptableObject
{
    public string Manufacturer;
    public new string Name;
    public string Production;
    public string Engine;
    public Sprite CarImage;
}
