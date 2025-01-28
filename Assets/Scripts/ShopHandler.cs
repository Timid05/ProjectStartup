using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopHandler : MonoBehaviour
{
    AppManager manager;
    [SerializeField]
    Sprite sunglassesImage;

    void Start()
    {
        manager = AppManager.GetManager();
    }

    public void BuyItem (Button shopItem)
    {
        ShopItemInfo itemInfo = shopItem.GetComponent<ShopItemInfo>();
        if (HasEnoughTokens(shopItem, itemInfo))
        {
            manager.AddTokens(-itemInfo.tokenPrice);
            manager.ChangeMascot(CosmeticSprite(itemInfo.cosmeticName));
            Debug.Log("Bought " + itemInfo.cosmeticName);
            shopItem.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("move along broke ass");
        }
    }

    bool HasEnoughTokens(Button shopItem, ShopItemInfo itemInfo)
    {
        
        if (itemInfo.tokenPrice > manager.tokenCount)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    Sprite CosmeticSprite(string cosmeticName)
    {
        switch (cosmeticName)
        {
            case "Sunglasses":
                return sunglassesImage;
                
            default:
                return null;
        }
    }
}
