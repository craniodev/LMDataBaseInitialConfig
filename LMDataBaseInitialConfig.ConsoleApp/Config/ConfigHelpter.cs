using System.Collections.Generic;
using LMDataBaseInitialConfig.ConsoleApp.Config;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Linq;
using LMDataBaseInitialConfig.ConsoleApp.File;

namespace LMDataBaseInitialConfig.ConsoleApp.Config
{
    public class ConfigHelpter : IConfigHelpter
    {
        private Config _config;
        private IFileHelper _fileHelper;


        public string Version
        {
            get
            {
                return this._config.Version;
            }
        }

        public ConfigHelpter(IFileHelper fileHelper)
        {

            this._fileHelper = fileHelper;
            Load();
        }

        public string GetInitialScriptPath()
        {

            return _config.InitialScriptPath;

        }

        public string GetConn(string key)
        {
            return this._config.ConnectionStrings.ContainsKey(key) ? this._config.ConnectionStrings[key] : string.Empty;
        }

        public List<string> GetConnKeys()
        {
            return this._config.ConnectionStrings.Keys.ToList();
        }

        public ConfigTable GetTable(string key)
        {
            return _config.Tables.FirstOrDefault(t => t.Name.ToLower().Equals(key.ToLower()));
        }

        public List<ConfigTable> GetTables()
        {
            return _config.Tables;
        }

        public void RemoveConn(string key)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTable(string key)
        {
            throw new System.NotImplementedException();
        }

        public void SetConn(string key, string value)
        {
            if (this._config.ConnectionStrings.ContainsKey(key))
                this._config.ConnectionStrings[key] = value;
            else
                this._config.ConnectionStrings.Add(key, value);

            Save();

        }

        public void SetTable(ConfigTable table)
        {
            if (!table.IsValid()) throw new ArgumentException("Table is invalid.");

            var tableToAdd = this.GetTable(table.Name);
            if (tableToAdd != null)
            {
                tableToAdd.Top = table.Top;
                tableToAdd.Insert = table.Insert;
                tableToAdd.Update = table.Update;
                tableToAdd.Delete = table.Delete;


            }
            else
            {
                _config.Tables.Add(table);
            }

            this.Save();
        }

        public string GetConfigPath()
        {
            return string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "\\config.json");
        }

        public void Load()
        {

            if (!_fileHelper.Exists(GetConfigPath()))
            {
                _config = new Config();
                _config.Tables = new List<ConfigTable>();
                _config.ConnectionStrings = new Dictionary<string, string>();
            }
            else
            {
                string json = _fileHelper.Reader(GetConfigPath());
                _config = JsonConvert.DeserializeObject<Config>(json);

            }

            if (this._config.ConnectionStrings == null)
                this._config.ConnectionStrings = new Dictionary<string, string>();

            if (this._config.Tables == null)
                this._config.Tables = new List<ConfigTable>();

        }

        public void Save()
        {

            var json = JsonConvert.SerializeObject(_config);
            _fileHelper.Save(GetConfigPath(), json);

        }

    }


}