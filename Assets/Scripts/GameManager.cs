using UnityEngine;


public class GameManager : MonoBehaviour
{
    // this component is to be attached to an empty gameobject that is the manger, this empty GO will hold all the components which we want to persist between scenes
    // e.g. would be audio manager
    public static GameManager inst;
    public GameplayManager gpManager;

    private void Awake()
    {
        if (inst != null && inst != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            inst = this;
        }

        DontDestroyOnLoad(gameObject);
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
