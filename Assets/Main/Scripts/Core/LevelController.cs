using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] List<LevelCollection> _levelCollection = new List<LevelCollection>();
    [SerializeField] Transform _levelModelParent;
    Level _activeLevel;
    public Transform StartTransform => _activeLevel.StartTransform;
    public Transform EndTransform => _activeLevel.EndTransform;

    public void LoadLevel(int activeLevelIndex)
    {
        _activeLevel = Instantiate(_levelCollection[activeLevelIndex - 1].GetlevelModel(), _levelModelParent);
        _activeLevel.Initialize();
    }
    public void UnloadLevel()
    {
        Destroy(_activeLevel.gameObject);
    }
    public void StartLevel()
    {
        _activeLevel.StartLevel();
    }

    public void EndLevel()
    {
        _activeLevel.EndLevel();
    }
}
