using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

    public GameObject player, playButton;
    
    void DeactiveGameObjects()
    {
        player.SetActive(false);
        playButton.SetActive(false);
    }

    void ActiveGameObjects()
    {
        player.SetActive(true);
        playButton.SetActive(true);
    }
}
