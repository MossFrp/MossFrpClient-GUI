using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using HandyControl.Controls;
using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MossFrp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class RootObject
    {
        public string authID { get; set; }
        public string clientBroadcast { get; set; }
        public string clientID { get; set; }
        public string clientKey { get; set; }
        public string clientVersion { get; set; }
        public string retCode { get; set; }
    }
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            //clientappid = 9f5566a1-358c-435a-aef0-9f2a802c9000
            InitializeComponent();
            
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

        private void money_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.mcrmb.com/fk/24184 ");
            Growl.SuccessGlobal("已在浏览器中打开充值页面");
        }
    }
}
