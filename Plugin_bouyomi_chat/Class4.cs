using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FNF.XmlSerializerSetting;

namespace Plugin_bouyomi_chat
{
    public class SettingPropertyGrid : ISettingPropertyGrid
    {
        private PluginSettings _settings = null;

        public SettingPropertyGrid(PluginSettings setting)
        {
            _settings = setting;
        }

        public string GetName() { return "チャット設定"; }

        [Category("チャット")]
        [DisplayName("01)チャットルーム")]
        [Description("読み上げたいチャットルームを設定してください")]
        public string Room
        {
            get { return this._settings.Room; }
            set { this._settings.Room = value; }
        }

    }
}
