using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using TMPro;

public class GenerateWeapon : MonoBehaviour
{
    public TMP_InputField tablet;
    public GameObject weaponOwner;
    public List<GameObject> sprites;
    public List<GameObject> icons;
    public GameObject panel;
    public TMP_Text weaponName;
    public GameObject panel2;
    public TMP_Text weaponName2;
    public TMP_Text description;

    string url = "https://pantheon-98al.onrender.com/get-grace";

    void Start() {
        addPanel();
    }
    public void removePanel() {
        panel.SetActive(false);
        panel2.SetActive(true);
        Time.timeScale = 1.0f;
        StartCoroutine(timeGo());
    }

    IEnumerator timeGo() {
        yield return new WaitForSeconds(4);
        panel2.SetActive(false);
    }

    public void addPanel() {
        panel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void generateWeapon() {
        StartCoroutine(getRequest(url, tablet.text));
    }

    private void createWeapon(int damage, int distance, int weight, float rate, string weaponType, int projectileSpd) {
        GameObject projectileSpawned = sprites[getSprite(weaponType)];
        icons[getIcon(weaponType)].SetActive(true);
        Weapon weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.Initialize(damage, distance, weight, rate, projectileSpawned, projectileSpd);

        WeaponScript weaponScript = weaponOwner.GetComponent<WeaponScript>();
        weaponScript.weapon = weapon;
    } 

    private int getSprite(string weaponType) 
    {
        switch (weaponType)
        {
            case "dagger":
                return 2;
            case "sword":
                return 2;
            case "polearm":
                return 2;
            case "axe":
                return 2;
            case "mace":
                return 2;
            case "bow":
                return 0;
            case "crossbow":
                return 0;
            case "pistol":
                return 1;
            case "rifle":
                return 1;
            default:
                return 2;
        }
    }

    private int getIcon(string weaponType) 
    {
        switch (weaponType)
        {
            case "dagger":
                return 3;
            case "sword":
                return 4;
            case "polearm":
                return 4;
            case "axe":
                return 7;
            case "mace":
                return 6;
            case "bow":
                return 2;
            case "crossbow":
                return 5;
            case "pistol":
                return 0;
            case "rifle":
                return 1;
            default:
                return 4;
        }
    }

    private IEnumerator getRequest(string url, string wish) 
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, "{ \"message\": \"" + wish + "\" }", "application/json"))
        {
            request.SetRequestHeader("api-key", "default");
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
                weaponName.text = temp.name;
                weaponName2.text = temp.name;
                description.text = temp.reply;
                createWeapon(temp.dmg,temp.atkrange,temp.weight,temp.rate,temp.gracetype, temp.projspeed);
                removePanel();
            }
        }
    }

}
