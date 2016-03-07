using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using FNF.BouyomiChanApp;
using Quobject.SocketIoClientDotNet.Client;
using FNF.XmlSerializerSetting;
using FNF.Utility;



namespace Plugin_bouyomi_chat
{
    public class Plugin_bouyomi_chat : IPlugin
    {

        private string _path = Base.CallAsmPath + Base.CallAsmName + ".setting";
        private PluginSettings _setting = null;
        private SettingFormData _settingFormDate = null;
        private Socket socket;

        public void Begin()
        {
            this._setting = new PluginSettings();
            this._setting.Load(this._path);
            this._settingFormDate = new SettingFormData(_setting);
            string room = this._setting.Room; // room処理用
            //  Socket. IO  //
            socket = IO.Socket("http://133.130.126.92:3000");
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Pub.AddTalkTask("チャットに接続されました");
            });
            socket.On("msg_to_bouyomi", (data) =>
            {
                string msg = string.Format("{0}", data);
                Pub.AddTalkTask(msg);
            });
            socket.On(Socket.EVENT_DISCONNECT, () =>
            {
                Pub.AddTalkTask("チャットから切断されました");
            });
            return;
        }

        public string Caption
        {
            get { return "チャットを読み上げます"; }
        }

        public void End()
        {
            _setting.Save(this._path);
            socket.Close();
            return;
        }

        public string Name
        {
            get { return "チャット読み上げプラグイン"; }
        }

        public FNF.XmlSerializerSetting.ISettingFormData SettingFormData
        {
            get { return this._settingFormDate; }
        }

        public string Version
        {
            get { return "2016/03/07版"; }
        }

    }
}

