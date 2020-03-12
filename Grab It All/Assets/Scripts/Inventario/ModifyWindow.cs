//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//public class ModifyWindow : EditorWindow
//{
//    private static DB database;
//    private static EditorWindow window;
//    private static Objeto databaseItem;
//    private static Objeto newItem;

//    private GUILayoutOption[] options = { GUILayout.MaxWidth(150.0f), GUILayout.MinWidth(20.0f) };
//    public static void ShowItemWindow(DB db, Objeto item)
//    {
//        database = db;
//        window = GetWindow<ModifyWindow>();
//        window.maxSize = new Vector2(300, 270);
//        window.minSize = new Vector2(300, 270);
//        databaseItem = item;
//        newItem = new Objeto();

//        newItem.id = item.id;
//        newItem.name = item.name;
//        newItem.cost = item.cost;
//        newItem.itemImage = item.itemImage;
//        newItem.description = item.description;
//    }


//    public void OnGUI()
//    {
     
//        DisplayItem(newItem);

//        if (GUILayout.Button("Confirm"))
//        {
//            ModifyItem();
//        }
       


//    }
//    private bool shouldDisable;
//        private void DisplayItem(Objeto item)
//        {
//            GUIStyle textAreaStyle = new GUIStyle(GUI.skin.textArea);
//            textAreaStyle.wordWrap = true;

//            GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
//            valueStyle.wordWrap = true;
//            valueStyle.alignment = TextAnchor.MiddleLeft;
//            valueStyle.fixedWidth = 50;
//            valueStyle.margin = new RectOffset(0, 50, 0, 0);

//            EditorGUILayout.BeginVertical("Box");
            
//            EditorGUILayout.BeginHorizontal();
//            GUILayout.Label("Name: ");
//            item.name = EditorGUILayout.TextField(item.name, options);
//            EditorGUILayout.EndHorizontal();

//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Item Image: ");
//        item.itemImage = (Sprite)EditorGUILayout.ObjectField(item.itemImage, typeof(Sprite), false);
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Dropeable: ");
//        item.dropeable = EditorGUILayout.Toggle(item.dropeable, options);
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Receta: ");
//        GUILayout.Label("Item1: ");
//        item.ingrediente1 = EditorGUILayout.IntField(item.ingrediente1, options);
//        GUILayout.Label("Item2: ");
//        item.ingrediente2 = EditorGUILayout.IntField(item.ingrediente2, options);
//        EditorGUILayout.EndHorizontal();
//        //EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Description: ");


//            item.description = EditorGUILayout.TextArea(item.description,textAreaStyle, GUILayout.MinHeight(100));

//        //EditorGUILayout.EndHorizontal();

       
//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Cost:  ");
//        item.cost = EditorGUILayout.IntField(item.cost, options);
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Stackable:  ");
//        item.isStackable = EditorGUILayout.Toggle(item.isStackable, options);
//        EditorGUILayout.EndHorizontal();

//        EditorGUILayout.EndVertical();


//    }

//        private void ModifyItem()
//        {
//        Undo.RecordObject(database, "Item Modified");
//        databaseItem.name = newItem.name;
//        databaseItem.cost = newItem.cost;
//        databaseItem.description = newItem.description;
//        databaseItem.itemImage = newItem.itemImage;
//        EditorUtility.SetDirty(database);
//        window.Close();

//        }
//}
