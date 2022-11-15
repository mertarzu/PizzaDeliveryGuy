using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PoolParticle : PooledObject
{
    bool isTaken;
    public override bool IsPooledObjectTaken => isTaken;

    public override void Dismiss()
    {
        ParticleSystem particle = GetComponent<ParticleSystem>();
        ReturnAsync(this, particle.main.duration);

    }
    private async void ReturnAsync(PooledObject pooledObject, float delay)
    {
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        try
        {
            await Task.Delay(Mathf.RoundToInt(delay * 1000), tokenSource.Token);
            if (!pooledObject)
            {
                tokenSource?.Cancel();
            }
            else
            {
                pooledObject.gameObject.SetActive(false);
                isTaken = false;
            }
                

        }
        finally
        {
            tokenSource?.Cancel();
            tokenSource?.Dispose();
        }
    }
    public override void SetActive()
    {
        gameObject.SetActive(true);
        isTaken = true;
    }

    public override void SetPosition(Vector3 pos)
    {
        transform.position = pos;
       
    }

    public void Play(Vector3 pos)
    {
        SetPosition(pos);
        SetActive();
        Dismiss();

    }
}
