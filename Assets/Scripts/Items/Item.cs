using UnityEngine;
using UnityEditor;
using System.Text;

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get {return id;}}
    public string itemName;
    public Sprite sprite;
    protected static readonly StringBuilder sb = new StringBuilder();
    private void OnValidate(){
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }
    public virtual Item GetCopy()
	{
		return this;
	}
    public virtual void Destroy(){

    }
    public virtual string GetItemType()
	{
		return "";
	}

	public virtual string GetDescription()
	{
		return "";
	}
}
