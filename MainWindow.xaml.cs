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

namespace CS_wpf_预充电阻选型
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        float T1 = 0;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                T1 = (float)-System.Math.Log(1 - (float.Parse(textBox1.Text) / 100));//根据2.2

                float i = 0;
                int teR;//默认预选电阻值
                Rmin_lab.Content = 200 / T1 / (float.Parse(textBox2.Text) / 1000);
                i = (float.Parse(textBox.Text)) / T1 / (float.Parse(textBox2.Text) / 1000);
                R_lab.Content = i;
                //RP_lab.Content = T1;
                RW_lab.Content = ((float.Parse(textBoxv.Text) * float.Parse(textBoxv.Text)) * (float.Parse(textBox2.Text) / 1000000)) / 2;
                //teR = (int)(i / 10) * 10;
                teR = (int)i ;

                R_tb.Text = Convert.ToString(teR);
                RPmax_lab.Content = (float.Parse(textBoxv.Text) * float.Parse(textBoxv.Text)) / float.Parse(R_tb.Text);
                RImax_lab.Content = float.Parse(textBoxv.Text) / float.Parse(R_tb.Text);
                RP_lab.Content = (int)(T1 * float.Parse(R_tb.Text) * float.Parse(textBox2.Text) / 1000);
            }
            catch (FormatException)
            {
                MessageBox.Show("请检查输入是否正确！");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                T1 = (float)-System.Math.Log(1 - (float.Parse(textBox1.Text) / 100));//根据2.2
                RPmax_lab.Content = (float.Parse(textBoxv.Text) * float.Parse(textBoxv.Text)) / float.Parse(R_tb.Text);
                RImax_lab.Content = float.Parse(textBoxv.Text) / float.Parse(R_tb.Text);
                RP_lab.Content = (int)(T1 * float.Parse(R_tb.Text) * float.Parse(textBox2.Text) / 1000);
            }
            catch (FormatException)
            {
                MessageBox.Show("请检查输入是否正确！");
            }

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"声明：本软件计算结果仅供参考，不能作为判断依据，因使用本软件出现任何问题与开发者无关
本程序在算法引用自：陈培哲,王薪强.动力电池预充电电阻选型设计[J].客车技术与研究,2018,40(1):30-33.
开源地址：https://github.com/CharlieForC/Precharge-Resistor-Selection",
               "关于" );

        }
    }
}
