using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBlock : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject repeat;

    private int extent;
    public int Extent { get => extent; }

    public void Build(int extent)
    {
        this.extent = extent;

        //blok batas
        for (int i = -1; i <= 1; i++)
        {
            if (i == 0)
            {
                continue;
            }

            var m = Instantiate(main);
            m.transform.SetParent(this.transform);
            m.transform.localPosition = new Vector3((extent + 1) * i, 0, 0);
            m.transform.GetComponentInChildren<Renderer>().material.color *= Color.grey;    
        }
        
        //blok utama
        main.transform.localScale = new Vector3(extent * 2 + 1, main.transform.localScale.y, main.transform.localScale.z);

        //repeat jika ada
        if (repeat == null)
        {
            return;
        }

        for (int x = -(extent + 1); x <= extent + 1; x++)
        {
            if (x == 0)
            {
                continue;
            }

            var r = Instantiate(repeat);
            r.transform.SetParent(this.transform);
            r.transform.localPosition = new Vector3(x, 0, 0);
        }
    }
}