using System;
using UnityEngine;
using UnityEngine.UI;

public class HexagonTypeIndicator : MonoBehaviour
{
    [SerializeField] private Image image;
    
    [SerializeField] private Sprite emitSprite;
    [SerializeField] private Sprite ricochetSprite;
    [SerializeField] private Sprite splitSprite;
    [SerializeField] private Sprite stopSprite;

    public void SetType(HexagonType type)
    {
        image.color = Color.white;
        
        switch (type)
        {
            case HexagonType.Empty:
                image.sprite = null;
                image.color = Color.clear;
                break;
            case HexagonType.Emit:
                image.sprite = emitSprite;
                break;
            case HexagonType.Ricochet:
                image.sprite = ricochetSprite;
                break;
            case HexagonType.Split:
                image.sprite = splitSprite;
                break;
            case HexagonType.Stop:
                image.sprite = stopSprite;
                break;
        }
    }
}