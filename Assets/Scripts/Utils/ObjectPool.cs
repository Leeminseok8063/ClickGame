using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool
{
    private IObjectPool<GameObject> pool;
    private string poolName;
    private Transform poolParent;
    private GameObject poolObeject;

    public ObjectPool(string name, Transform parent, GameObject targetObject,  int defalutCap = 10, int maxCap = 30)
    {
        poolName = name;
        poolParent = parent;
        poolObeject = targetObject;
        pool = new ObjectPool<GameObject>(
                createFunc: CreateObject,
                actionOnGet: GetObject,
                actionOnRelease: ReleaseObject,
                actionOnDestroy: DestoryObject,
                defaultCapacity: defalutCap,
                maxSize: maxCap);
    }

    public GameObject Spawn()
    {
        return pool.Get();
    }

    public void Despawn(GameObject go)
    {
        pool.Release(go);
    }

    private GameObject CreateObject()
    {
        GameObject temp = GameObject.Instantiate(poolObeject, poolParent);
        temp.name = poolName;
        return temp;
    }

    private void GetObject(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void ReleaseObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void DestoryObject(GameObject obj)
    {
        GameObject.Destroy(obj);
    }

}

