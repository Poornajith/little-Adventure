using UnityEngine;

public class SpikePool : ObjectPool<Spike>
{
    public static SpikePool instance;
    private void Start()
    {
        instance = this;
    }

}
