﻿using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum DemonType {
    Imp,
    Infernal,
    VoidGuardian,
    None
}

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
	[SerializeField] string id;
	public string ID { get { return id; } }
	public string ItemName;
	public Sprite Icon;
	public int dropChance;
	public DemonType demonType = DemonType.None;

	protected static readonly StringBuilder sb = new StringBuilder();

	#if UNITY_EDITOR
	protected virtual void OnValidate()
	{
		string path = AssetDatabase.GetAssetPath(this);
		id = AssetDatabase.AssetPathToGUID(path);
	}
	#endif

	public virtual Item GetCopy()
	{
		return this;
	}

	public virtual void Destroy()
	{

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
