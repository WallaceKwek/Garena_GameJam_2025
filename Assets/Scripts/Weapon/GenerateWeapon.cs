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
    public SubmitButton SubmitButtonScript;
    public TMP_Text godCommand;
    public TMP_Text weaponStats;
    private int curGod;
    private bool start;
    private List<string> godNames = new List<string>
    { 
        "medusa",
        "chronos",
        "azatoth",
        "bodhisattva",
        "hephaestus",
        "ghost of painter",
        "euterpe",
        "loki"
    };
    private List<string> godInstructions = new List<string>
    {
        "medusa: Ssslither sssentences succinctly... wordss ssshould slither sstarts & endss",
        "chronos: 3 words, no more. Don't waste my time",
        "azatoth: pyte ni angraams lyon",
        "bodhisattva: Peace begins with intent. Wish not for harm, but for harmony, young seeker.",
        "hephaestus: I am the forge. Ask only for creations of the old world — medieval, timeless, worthy of myth.",
        "ghost of painter: You vill ask only for modern veapons. Do not disgrace mein vision with primitive junk.",
        "euterpe: Let your words sing — growing longer, one after another~ Build a melody in length~",
        "loki: ???"
    };

    string url = "https://pantheon-98al.onrender.com/get-god-grace";

    void Start() {
        curGod = 4;
        start = true;
        addPanel();
    }
    void Update(){
        WeaponScript weaponScript = weaponOwner.GetComponent<WeaponScript>();
        if (weaponScript.weapon != null) {
            Weapon weapon = weaponScript.weapon;
            weaponStats.text = "atk: " + weapon.damage + "\nrange: " + weapon.distance + "\nrate: " + weapon.rate;
        }
        if(GameManager.inst.gpManager.enemiesKilled >= 20)
        {
            addPanel();
            GameManager.inst.gpManager.enemiesKilled -= 20;
        }
    }
    public void removePanel() {
        tablet.text = "";
        panel.SetActive(false);
        panel2.SetActive(true);
        Time.timeScale = 0.1f;
        StartCoroutine(timeGo());
    }

    IEnumerator timeGo() {
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 1.0f;
        panel2.SetActive(false);
    }

    public void addPanel() {
        if (!start)
        {
            curGod = Random.Range(0, godNames.Count - 1);
        }
        start = false;
        godCommand.text = godInstructions[curGod];
        panel.SetActive(true);
        SubmitButtonScript.TurnOnButton();
        Time.timeScale = 0.0f;
    }

    public void generateWeapon() {
        StartCoroutine(getRequest(url, tablet.text));
    }

    private void createWeapon(int damage, int distance, int weight, float rate, string weaponType, int projectileSpd) {
        GameObject projectileSpawned = sprites[getSprite(weaponType)];
        for (int i = 0; i < icons.Count; i++) {
            icons[i].SetActive(false);
        }
        icons[getIcon(weaponType)].SetActive(true);
        Weapon weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.Initialize(damage, distance, weight, rate, projectileSpawned, projectileSpd);

        WeaponScript weaponScript = weaponOwner.GetComponent<WeaponScript>();
        weaponScript.weapon = weapon;
    } 

    private void createEffect(string buffType, float percentage_change) {
        WeaponScript weaponScript = weaponOwner.GetComponent<WeaponScript>();
        switch (buffType) 
        {
            case "max_HP":
                GameManager.inst.gpManager.player.GetComponent<HealthComponent>().maxHealth += (int)((percentage_change / 100.0f) * GameManager.inst.gpManager.player.GetComponent<HealthComponent>().maxHealth);
                break;
            case "cur_HP":
                GameManager.inst.gpManager.player.GetComponent<HealthComponent>().currentHealth += (int)((percentage_change / 100.0f) * GameManager.inst.gpManager.player.GetComponent<HealthComponent>().maxHealth);
                if (GameManager.inst.gpManager.player.GetComponent<HealthComponent>().currentHealth > GameManager.inst.gpManager.player.GetComponent<HealthComponent>().maxHealth) {
                    GameManager.inst.gpManager.player.GetComponent<HealthComponent>().currentHealth = GameManager.inst.gpManager.player.GetComponent<HealthComponent>().maxHealth;
                }
                break;
            case "dmg":
                weaponScript.weapon.damage *= (int)((100 + percentage_change) / 100);
                break;
            case "rate":
                weaponScript.weapon.rate *= (int)((100 - percentage_change) / 100);
                break;
            case "atkrange":
                weaponScript.weapon.distance *= (int)((100 + percentage_change) / 100);
                break;
        }
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
        using (UnityWebRequest request = UnityWebRequest.Post(url, "{ \"message\": \"" + wish + "\", \"god_name\": \"" + godNames[curGod] + "\" }", "application/json"))
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
                weaponName2.text = temp.name;
                description.text = temp.item_description;
                if (temp.gracetype == "effect") {
                    createEffect(temp.changed_stat, temp.percentage_change);
                }
                else {
                    weaponName.text = temp.name;
                    createWeapon(temp.dmg,temp.atkrange,temp.weight,temp.rate,temp.gracetype, temp.projspeed);
                }
                removePanel();
            }
        }
    }

}
