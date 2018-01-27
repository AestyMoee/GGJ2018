using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [System.Serializable]
    public struct LevelStruct
    {
        public AudioClip clip;
        public float[] pitchs;
    }

    public static GameController Instance { get; private set; }

    [SerializeField]
    List<LevelStruct> levels;

    [SerializeField]
    int levelToLoadAtStart = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Game Controller already exist");
            enabled = false;
        }
    }

    // Use this for initialization
    void Start () {
#if !UNITY_EDITOR
        levelToLoadAtStart = 0;
#endif
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
