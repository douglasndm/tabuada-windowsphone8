using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;

namespace Tabuada
{
    class AppSettings
    {
        IsolatedStorageSettings settings;

        public enum SettingsKeyNames
        {
            UpdateTiles,
            UpdateContLiveTiles,
            ContLiveTiles,
            VezesQueFoiAberta
        }

        public AppSettings()
        {
            settings = IsolatedStorageSettings.ApplicationSettings;
        }
        
        public void Save()
        {
            settings.Save();
        }

        public void AddOrUpdateSettings(SettingsKeyNames keyName, object value)
        {
            string key = keyName.ToString();

            if (settings.Contains(key))
            {
                settings[key] = value;
            }
            else
            {
                settings.Add(key, value);
            }
            this.Save();
        }

        public T GetValueOrDefault<T>(SettingsKeyNames keyName, T defaultValue)
        {
            string key = keyName.ToString();
            if (settings.Contains(key))
            {
                return (T)settings[key];
            }
            else
            {
                return defaultValue;
            }
        }

        public bool UpdateTile
        {
            get
            {
                return this.GetValueOrDefault<bool>(SettingsKeyNames.UpdateTiles, true);
            }
            set
            {
                this.AddOrUpdateSettings(SettingsKeyNames.UpdateTiles, value);
            }
        }
        public bool updateContLiveTiles
        {
            get
            {
                return this.GetValueOrDefault<bool>(SettingsKeyNames.UpdateContLiveTiles, true);
            }
            set
            {
                this.AddOrUpdateSettings(SettingsKeyNames.UpdateContLiveTiles, value);
            }
        }
        public int ContLiveTile
        {
            get
            {
                return this.GetValueOrDefault<Int32>(SettingsKeyNames.ContLiveTiles, 0);
            }
            set
            {
                this.AddOrUpdateSettings(SettingsKeyNames.ContLiveTiles, value);
            }
        }
    }
}
