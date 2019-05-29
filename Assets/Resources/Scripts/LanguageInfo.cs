using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Language", menuName = "Language")]
public class LanguageInfo : ScriptableObject
{
    public string[] Commands;
    public string[] CommandManager;
}
