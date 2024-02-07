using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace FE_LoadSaveSingleton
{
    // Interface: IPlayerSettings
    // Author: David Schuh (used by Ajay Ramnarine for FEQ4)
    // Purpose: To be inherited by the Settings Class
    // Restrictions: None
    public interface IPlayerSettings
    {
        void SavePlayerSettings(string fileName, PlayerSettings settings);
        PlayerSettings LoadPlayerSettings(string fileName);
    }

    // Class: PlayerSettings
    // Author: David Schuh (used by Ajay Ramnarine for FEQ4)
    // Purpose: Used as the structure for the file that will be saved and loaded 
    // Restrictions: None
    public class PlayerSettings
    {
        public string player_name;
        public int level;
        public int hp;
        public string[] inventory;
        public string license_key;
    }

    // Class: SettingsClass
    // Author: David Schuh (used by Ajay Ramnarine for FEQ4)
    // Purpose: A singleton that contains an instance of itself and methods to save and load settings from a file
    // Restrictions: None
    public class SettingsClass : IPlayerSettings
    {
        private static SettingsClass instance = new SettingsClass();

        private SettingsClass() { }

        // Method: GetInstance
        // Purpose: Returns the private instance within the class
        // Restrictions: None
        public static SettingsClass GetInstance()
        {
            return instance;
        }

        // Method: SavePlayerSettings
        // Purpose: Save the settings to the fileName file
        // Restrictions: if visual studio is not run as administrator, trying to write to the json file will return an error that the user has unauthorized access and cannot write to the file
        public void SavePlayerSettings(string fileName, PlayerSettings settings)
        {
            string sSettings;

            StreamWriter writer;

            // serialize the settings into a string
            sSettings = JsonConvert.SerializeObject(settings);

            try
            {
                // write sSettings to fileName
                writer = new StreamWriter(fileName);
                writer.Write(sSettings);
                writer.Close();
            }
            catch
            {
                Console.WriteLine("You need to run Visual Studio as an administrator to write to the file");
            }

        }

        // Method: LoadPlayerSettings
        // Purpose: Return the settings that are saved within a file
        // Restrictions: None
        public PlayerSettings LoadPlayerSettings(string fileName)
        {
            // string to hold the contents of the file
            string sSettings = null;

            // stream reader to read the json file
            StreamReader reader;

            // player settings object that will contain the loaded information from the file
            PlayerSettings settings;

            try
            {
                // read fileName to sSettings
                reader = new StreamReader(fileName);
                sSettings = reader.ReadToEnd();
                reader.Close();

                // deserialize the information from the file
                settings = JsonConvert.DeserializeObject<PlayerSettings>(sSettings);
            }
            catch
            {
                settings = new PlayerSettings();

                // if the file name does not exist then create the information to be loaded and then saved into the file
                settings.player_name = "dschuh";
                settings.level = 4;
                settings.hp = 99;
                settings.inventory = new string[] { "spear", "water bottle", "hammer", "sonic screwdriver", "cannonball", "wood", "Scooby snack", "Hydra", "poisonous potato", "dead bush", "repair powder" };
                settings.license_key = "DFGU99-1454";
            }

            return settings;
        }
    }

    // Class: Program
    // Author: David Schuch (used by Ajay Ramnarine for FEQ4)
    // Purpose: Use the above classes and methods to load and save player settings to a hard drive file using the JSON format
    // Restrictions: VISUAL STUDIO MUST BE RUN AS ADMINISTRATOR TO WRITE TO THE JSON FILE
    class Program
    {
        // Method: Main
        // Purpose: Create a player settings object to load information from the JSON file onto
        //          Save those settings 
        // Restrictions: MUST BE RUN AS ADMINISTRATOR TO WRITE TO THE JSON FILE
        static void Main(string[] args)
        {
            PlayerSettings settings = new PlayerSettings();

            SettingsClass settingsFunctions = SettingsClass.GetInstance();

            settings = settingsFunctions.LoadPlayerSettings("C:/settings.json");
            settingsFunctions.SavePlayerSettings("C:/settings.json", settings);
        }
    }
}