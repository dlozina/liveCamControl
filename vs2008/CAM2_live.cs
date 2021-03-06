using System;
using HalconDotNet;

public partial class HDevelopExport
{
    //public HTuple hv_ExpDefaultWinHandle;

    private bool exitloop2;
    public bool Exitloop2
    {
        get { return exitloop2; }
        set { exitloop2 = value; }
    }

    // Main procedure 
    private void action2()
    {


    // Local iconic variables 

    HObject ho_Image=null;

    // Local control variables 

    HTuple hv_AcqHandle = null;
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_Image);
    
    // CAM 2 Poroznost
    HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default", -1, 
        "default", -1, "false", "default", "GC3851MP_CAM_2", 0, -1, out hv_AcqHandle);

    HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
    //while ((int)(1) != 0)
    while (exitloop2 == false)
    {
        ho_Image.Dispose();
        HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
        //Image Acquisition 01: Do something
        HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
    }
    HOperatorSet.CloseFramegrabber(hv_AcqHandle);
    ho_Image.Dispose();
    HOperatorSet.ClearWindow(hv_ExpDefaultWinHandle);

    }

    //public void InitHalcon()
    //{
    //  // Default settings used in HDevelop 
    //  HOperatorSet.SetSystem("width", 512);
    //  HOperatorSet.SetSystem("height", 512);
    //}

    public void RunCAM2(HTuple Window)
    {
    hv_ExpDefaultWinHandle = Window;
    action2();
    }

}

