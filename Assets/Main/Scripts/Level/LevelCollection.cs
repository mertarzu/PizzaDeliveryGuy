using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Level", menuName = "LevelCollection")]
public class LevelCollection : ScriptableObject
{
    [SerializeField] Level levelPrefab;

    public Level GetlevelModel()
    {
        return levelPrefab;
    }
}
