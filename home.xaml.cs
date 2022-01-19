using HandyControl.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MossFrp
{
    /// <summary>
    /// home.xaml 的交互逻辑
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();
            try
            {
                string b = CrabEngine.HttpGet("https://v6.crabapi.cn/api/mossfrp/clientbasicinfo?clientappid=9f5566a1-358c-435a-aef0-9f2a802c9000");
                RootObject rb = JsonConvert.DeserializeObject<RootObject>(b);
                bd.Content = rb.clientBroadcast;
                Growl.InfoGlobal("欢迎使用MossFrp\n当前版本：0.1.1-alpha-01\n服务器最新版本：" + rb.clientVersion);
            }
            catch (Exception ex)
            {
                Growl.ErrorGlobal("发生错误，请检查网络连接：\n" + ex);
            }
        }
        private void moss_Click(object sender, RoutedEventArgs e)
        {
            login l = new();
            l.Show();
        }

        private void Oauth_Click(object sender, RoutedEventArgs e)
        {
            oauth o = new();
            o.Show();
        }
    }
}
