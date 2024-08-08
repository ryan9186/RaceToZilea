using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedTileUI : MonoBehaviour
{
    public GameHandler gameHandler;
    public Image selectedTileImage;
    // Start is called before the first frame update
    void Awake()
    {
        selectedTileImage = gameObject.GetComponent<Image>();
    }
}
