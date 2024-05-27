using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum ItemType {
        Fruit,
        Equipment,
        Used,
        Ingredient,
        ETC,
    }
    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;
}
