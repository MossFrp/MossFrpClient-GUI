using HandyControl.Controls;
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

namespace MossFrp
{
    /// <summary>
    /// user.xaml 的交互逻辑
    /// </summary>
    public partial class user : Page
    {
        public user()
        {
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
