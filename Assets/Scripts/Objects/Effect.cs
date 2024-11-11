using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

internal class Effect : MonoBehaviour, ISpawnable
{
    public void IsSpawned(Vector3 start, Vector3 dest)
    {
        this.gameObject.transform.position = start;
        StartCoroutine(OnParticle());
    }

    private IEnumerator OnParticle()
    {
        yield return new WaitForSeconds(1f);
        SpawnManager.Instance.Despawn(this.gameObject);
    }
}

