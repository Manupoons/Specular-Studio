using System.Collections;
using System.Collections.Generic;
using Subtegral.DialogueSystem.DataContainers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer background;
    public Sprite[] sprites;
    private Sprite upSprite;
    private Sprite downSprite;
    private Sprite leftSprite;
    private Sprite rightSprite;
    
    void Start()
    {
        background.sprite = sprites[0];
        upSprite = sprites[0];
        downSprite = sprites[1];
        leftSprite = sprites[2];
        rightSprite = sprites[3];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            background.sprite = upSprite;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            background.sprite = downSprite;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            background.sprite = leftSprite;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            background.sprite = rightSprite;
        }
    }
}
