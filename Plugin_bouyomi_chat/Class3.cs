using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNF.XmlSerializerSetting;

namespace Plugin_bouyomi_chat
{
    class SettingFormData : ISettingFormData
    {
        private PluginSettings _settings = null;
        public ISettingPropertyGrid _settingPropertyGrid = null;

        public SettingFormData(PluginSettings settings)
        {
            this._settings = settings;
            this._settingPropertyGrid = new SettingPropertyGrid(this._settings);
        }



        public bool ExpandAll
        {
            get { return false; }
        }

        public SettingsBase Setting
        {
            get { return this._settings; }
        }

        public string Title
        {
            get { return "チャット読み上げプラグインの設定"; }
        }
    }
}
