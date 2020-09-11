using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplayer_Setting : MonoBehaviour
{

    public static Multiplayer_Setting multiplayerSetting;
    
    public bool delayStart;
    public int maxPlayers;

    public int menuScene;
    public int multiplayerScene;

    private void Awake()
    {
        if(Multiplayer_Setting.multiplayerSetting == null)
        {
            Multiplayer_Setting.multiplayerSetting = this;
        }
        else
        {
            if(Multiplayer_Setting.multiplayerSetting != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }





}
