using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GenerateWeapon : MonoBehaviour
{
    public GameObject weaponOwner;
    public List<GameObject> sprites;

    string url = "http://127.0.0.1:8000/ping";

    void Start() {
        generateWeapon();
    }

    public void generateWeapon() {
        UnityWebRequest request = UnityWebRequest.Get(url);
        StartCoroutine(getRequest(url));
    }

    private void createWeapon(int damage, int distance, int weight, float rate, string weaponType) {
        GameObject projectileSpawned = sprites[0];
        Weapon weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.Initialize(damage, distance, weight, rate, projectileSpawned);

        WeaponScript weaponScript = weaponOwner.GetComponent<WeaponScript>();
        weaponScript.weapon = weapon;
    } 

    private IEnumerator getRequest(string url) 
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if ((request.result == UnityWebRequest.Result.ProtocolError) || (request.result == UnityWebRequest.Result.ConnectionError)) 
            {
                Debug.LogError(request.error);
            }
            else 
            {
                var text = request.downloadHandler.text;
                Debug.Log(text);
                Json temp = JsonUtility.FromJson<Json>(text);
                createWeapon(10,10000,10,0.1f,"aaa");
            }
        }
    }

}
