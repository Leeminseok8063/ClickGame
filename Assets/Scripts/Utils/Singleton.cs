using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance 
    {   
        get 
        { 
            DeclareSingle(); 
            return instance; 
        } 
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void DeclareSingle()
    {
        if(instance == null)
        {
            instance = new GameObject(typeof(T).Name).AddComponent<T>();
        }
    }
}

