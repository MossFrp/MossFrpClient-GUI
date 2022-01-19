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
using System.Windows.Shapes;
using HandyControl.Controls;
using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MossFrp
{
    /// <summary>
    /// login.xaml 的交互逻辑
    /// </summary>
    public partial class login : System.Windows.Window
    {
        public class W
        {
            public string msg { get; set; }
            public string gold { get; set; }
            public string uid { get; set; }
            public string level { get; set; }
            public string name { get; set; }
            public string silver { get; set; }
            public string status { get; set; }
        }
        public class RootObject
        {
            public string msg { get; set; }
            public string? token { get; set; }
            public string status { get; set; }
        }
        public login()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            var result = CrabEngine.HttpGet("http://zz2.mossfrp.cn:59666/login?type=qq&info=" + qq.Text + "&password=" + pwd.Password);
            try
            {
                RootObject rb = JsonConvert.DeserializeObject<RootObject>(result);
                var r = CrabEngine.HttpGet("http://zz2.mossfrp.cn:59666/userdata?token=" + rb.token);
                W data = JsonConvert.DeserializeObject<W>(r);
                MainWindow MainWindow7 = new();
                home MainWindow = new();
                user MainWindow2 = new();
                MainWindow.nologin.Visibility = Visibility.Hidden;
                MainWindow2.nologin2.Visibility = Visibility.Hidden;
                MainWindow2.login.Visibility = Visibility.Visible;
                MainWindow2.gold.Status = data.gold;
                MainWindow2.silver.Status = data.silver;
                MainWindow2.group.Status = data.level;
                MainWindow7.tunnel.IsEnabled = true;
                Growl.SuccessGlobal("欢迎使用MossFrp，" + data.name + "\n用户金币：" + data.gold + "\n用户银币：" + data.silver);
                Close();
            }
            catch
            {
                if (result == "403")
                {
                    Growl.ErrorGlobal("请求频率过快，等会再试:(");
                }
                else if (result == "401")
                {
                    Growl.ErrorGlobal("用户名或密码错误");
                }
                else if (result == "400")
                {
                    Growl.ErrorGlobal("内部错误，您输入的东西合法吗？");
                }
            }
        }
    }
}
