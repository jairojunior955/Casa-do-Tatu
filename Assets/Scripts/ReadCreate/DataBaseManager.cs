using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;

public class DataBaseManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField username;
    [SerializeField]
    public TMP_InputField email;
    [SerializeField]
    public TMP_InputField senha;
    private string userId;
    private DatabaseReference dbReference;
    private FirebaseDatabase FireDb;
    // Start is called before the first frame update
    void Start()
    {
        
        string url = "https://casa-do-tatu-default-rtdb.firebaseio.com/users";
        FireDb = FirebaseDatabase.GetInstance(url);
        Debug.Log("Algo q " + FireDb);
        dbReference = FireDb.GetReferenceFromUrl(url);
        //dbReference = FirebaseDatabase.DefaultInstance.GetReferenceFromUrl(url);
        userId = SystemInfo.deviceUniqueIdentifier;
        //dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    public void CreateUser()
    {
        User newUser = new User(username.text, email.text, senha.text);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(userId).SetRawJsonValueAsync(json);

    }
}
