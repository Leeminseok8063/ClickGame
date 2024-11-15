using UnityEngine;

public class GameSceneLoader : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Init();
        ObjectManager.Instance.Init();
        SpawnManager.Instance.Init();
        PositionManager.Instance.Init(); 
        UIManager.Instance.Init();
        SoundManager.Instance.Init();
        IOManager.Instance.Init();
    }
}
