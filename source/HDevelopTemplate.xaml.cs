using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

using HalconDotNet;

namespace LiveCAMProject
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class HDevelopTemplate : Window
  {
    // The class HDevelopExport will be defined in the HALCON program
    // exported from HDevelop for 'C# - HALCON/.NET' and the Template
    // Window Export.
    private HDevelopExport HDevExp;

    public HDevelopTemplate() // Constructor
    {
      InitializeComponent();

      HDevExp = new HDevelopExport();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        HDevExp.InitHalcon();
    }

    private void RunExport1()
    {
        HTuple WindowID = hWindowControlWPF1.HalconID;
        HDevExp.RunCAM1(WindowID);

        this.Dispatcher.Invoke(new Action(() => {
        labelStatus.Content = "Finished.";
        buttonCAM1.IsEnabled = true;
        }));
    }

    private void RunExport2()
    {
        HTuple WindowID = hWindowControlWPF1.HalconID;
        HDevExp.RunCAM2(WindowID);

        this.Dispatcher.Invoke(new Action(() => {
        labelStatus.Content = "Finished.";
        buttonCAM1.IsEnabled = true;
        }));
    }

    private void RunExport3()
    {
        HTuple WindowID = hWindowControlWPF1.HalconID;
        HDevExp.RunCAM3(WindowID);

        this.Dispatcher.Invoke(new Action(() => {
        labelStatus.Content = "Finished.";
        buttonCAM1.IsEnabled = true;
        }));
    }

    private void RunExport4()
    {
        HTuple WindowID = hWindowControlWPF1.HalconID;
        HDevExp.RunCAM4(WindowID);

        this.Dispatcher.Invoke(new Action(() => {
        labelStatus.Content = "Finished.";
        buttonCAM1.IsEnabled = true;
        }));
    }
    
    // Button Control
    
    private void buttonCAM1_Click(object sender, RoutedEventArgs e)
    {
        buttonCAM1.IsEnabled = false;
        buttonCAM2.IsEnabled = true;
        buttonCAM3.IsEnabled = true;
        buttonCAM4.IsEnabled = true;

        HDevExp.Exitloop1 = false;
        HDevExp.Exitloop2 = true;
        HDevExp.Exitloop3 = true;
        HDevExp.Exitloop4 = true;

        hWindowControlWPF1.ImagePart = new Rect(0, 0, 1500, 300); 

        labelStatus.Content = "Running...";
        labelStatus.UpdateLayout();

        Thread exportThread = new Thread(new ThreadStart(this.RunExport1));
        exportThread.Start();
    }

    private void buttonCAM2_Click(object sender, RoutedEventArgs e)
    {
        buttonCAM1.IsEnabled = true;
        buttonCAM2.IsEnabled = false;
        buttonCAM3.IsEnabled = true;
        buttonCAM4.IsEnabled = true;

        HDevExp.Exitloop1 = true;
        HDevExp.Exitloop2 = false;
        HDevExp.Exitloop3 = true;
        HDevExp.Exitloop4 = true;

        hWindowControlWPF1.ImagePart = new Rect(0, 0, 1500, 300);

        labelStatus.Content = "Running...";
        labelStatus.UpdateLayout();

        Thread exportThread = new Thread(new ThreadStart(this.RunExport2));
        exportThread.Start();
    }

    private void buttonCAM3_Click(object sender, RoutedEventArgs e)
    {
        buttonCAM1.IsEnabled = true;
        buttonCAM2.IsEnabled = true;
        buttonCAM3.IsEnabled = false;
        buttonCAM4.IsEnabled = true;

        HDevExp.Exitloop1 = true;
        HDevExp.Exitloop2 = true;
        HDevExp.Exitloop3 = false;
        HDevExp.Exitloop4 = true;

        hWindowControlWPF1.ImagePart = new Rect(0, 0, 1500, 300);

        labelStatus.Content = "Running...";
        labelStatus.UpdateLayout();

        Thread exportThread = new Thread(new ThreadStart(this.RunExport3));
        exportThread.Start();
    }

    private void buttonCAM4_Click(object sender, RoutedEventArgs e)
    {
        buttonCAM1.IsEnabled = true;
        buttonCAM2.IsEnabled = true;
        buttonCAM3.IsEnabled = true;
        buttonCAM4.IsEnabled = false;

        HDevExp.Exitloop1 = true;
        HDevExp.Exitloop2 = true;
        HDevExp.Exitloop3 = true;
        HDevExp.Exitloop4 = false;

        hWindowControlWPF1.ImagePart = new Rect(0, 0, 1500, 300);

        labelStatus.Content = "Running...";
        labelStatus.UpdateLayout();

        Thread exportThread = new Thread(new ThreadStart(this.RunExport4));
        exportThread.Start();
    }

    private void buttonCloseAll_Click(object sender, RoutedEventArgs e)
    {
        HOperatorSet.CloseAllFramegrabbers();
    }

  }
}
