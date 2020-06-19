using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum EquipmentType {
    head,
    chest,
    legs,
    ring,
    trinket,
    mainhand,
    offhand
}

[CreateAssetMenu(fileName = "New Equipment Loot", menuName = "Equipment Loot")]
public class LootEquipment : Loot
{
    public EquipmentType equipmentType;
    public IEnumerable<string> _keys = new List<string>{
        "strength",
        "dexterity",
        "intellect",
        "vitality"
    };
    public List<int> _values = new List<int>();
    public override Loot GenerateItem(){
        LootEquipment equip = Instantiate(this);
        for(int i = 0; i < _keys.ToList().Count; i++){
            _values.Add(Random.Range(0, 5));
        }
        equip.stats = _keys.Zip(_values, (key, value) => new { key, value}).ToDictionary(x => x.key, x => x.value);
        return equip;
    }
    private void InitEquip(Loot item){
        this.id = item.id;
        this.lootName = item.lootName;
        this.lootWeight = item.lootWeight;
        this.description = item.description;
        this.sprite = item.sprite;
        this.weight = item.weight;
        this.lootType = item.lootType;
    }
    public static LootEquipment CreateLootEquipment(LootEquipment item){
        LootEquipment loot = ScriptableObject.CreateInstance<LootEquipment>();

        loot.InitEquip(item);

        return loot;
    }

}
