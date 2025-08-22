using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;
    public static PainelTopo PainelTopo;
    //Singleton
    void Awake()
    {
        if (Instance == null)
        {
            PainelTopo = GetComponent<PainelTopo>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
