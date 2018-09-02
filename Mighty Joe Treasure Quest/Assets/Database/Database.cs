using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Sistema de inventario/Database")]
public class Database : ScriptableObject {

    public List<Item> items = new List<Item>();

    public Item buscaritem(string nombre) {
        foreach(Item item in items)
        {
            if (item.nombre == nombre) {
                return item;
            }
        }
        return null;
    }

    public Item buscaritem(int indice) {
        for (int i = 0; i < items.Capacity; i++) {
            if (items[i] == items[indice]) {
                return items[i];
            }
        }
        return null;
    }

}

[System.Serializable]
public class Item {

    public string nombre;
    public int valor;
    public GameObject imagen;
    public GameObject mensaje;


}
