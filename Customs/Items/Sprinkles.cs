using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenIceCreamParlor.Customs.Appliances;
using UnityEngine;

namespace KitchenIceCreamParlor.Customs.Items
{
    public class Sprinkles : CustomItem
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "Sprinkles";
        
        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Sprinkles").AssignMaterialsByNames();
        
        // DedicatedProvider - The Appliance used for this Item's provider.
        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<ToppingsProvider>().GameDataObject;
    }
}