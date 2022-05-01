using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]

public class ScriptableUnit : ScriptableObject{
    public Team Team;
    public BaseUnit UnitPrefab;
}

public enum Team{
    Players = 0,
    Enemies = 1
}
