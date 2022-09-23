using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Conversation")]
public class Conversation : ScriptableObject
{
    public string conversationName;
    public string participants;
    public TextAsset textFile;
}
